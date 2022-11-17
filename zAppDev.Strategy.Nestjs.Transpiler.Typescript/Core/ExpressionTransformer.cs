using CLMS.AppDev.MetaModels.WebForm;
using zAppDev.Strategy.Transpiler.Base.Common;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Statement;
using CLMS.Lang.Model.Structs;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System;

using Action = CLMS.AppDev.MetaModels.WebForm.Action;
using Math = CLMS.Lang.Model.Expressions.Math;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Core
{
    public class ExpressionTransformer : IExpressionTransformer
    {
        protected readonly IDataTypeTransformer _dataTypeTransformer;

        protected readonly IFunctionTransformer _functionTransformer;

        protected readonly INullSafeTransformer _nullSafeTransformer;

        protected readonly INullExpressionParserHelper _nullExpressionParserHelper;

        protected readonly ILibraryHelper _libraryHelper;

        public bool AsyncCheck { get; set; }
        public Dictionary<string, string> ExtraVariablesDeclaration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ExpressionTransformer(ILibraryHelper libraryHelper,
                                     CompilerOptions options,
                                     INullExpressionParserHelper nullExpressionParserHelper,
                                     IDataTypeTransformer dataTypeTransformer,
                                     IFunctionTransformer functionTransformer,
                                     INullSafeTransformer nullSafeTransformer)
        {
            AsyncCheck = true;

            _nullExpressionParserHelper = nullExpressionParserHelper;
            _dataTypeTransformer = dataTypeTransformer;
            _functionTransformer = functionTransformer;
            _libraryHelper = libraryHelper;
            _nullSafeTransformer = nullSafeTransformer;
        }
       
        public string Transform(FunctionOptions options, Expression expression)
            => Visit(options, expression);

        public string Parse(FunctionOptions options, Expression expression)
            => Visit(options, expression);

        public string Visit(FunctionOptions options, Expression exp)
        {
            if (exp == null)
                throw new ArgumentOutOfRangeException($"You have provided null expression");

            return exp switch
            {
                BooleanOperand stm => Visit(options, stm),
                Cast stm => Visit(options, stm),
                CharacterOperand stm => Visit(options, stm),
                Conditional stm => Visit(options, stm),
                Constructor stm => Visit(options, stm),
                DecimalOperand stm => Visit(options, stm),
                FunctionCall stm => Visit(options, stm),
                Identifier stm => Visit(options, stm),
                InlineCollectionInitializer stm => Visit(options, stm),
                IntegerOperand stm => Visit(options, stm),
                Lambda stm => Visit(options, stm),
                Logical stm => Visit(options, stm),
                LogicalComparison stm => Visit(options, stm),
                LogicalNot stm => Visit(options, stm),
                Math stm => Visit(options, stm),
                Member stm => VisitMemberNullishCoalescing(options, stm),
                MemberWithExpression stm => Visit(options, stm),
                Null stm => Visit(options, stm),
                Parenthesis stm => Visit(options, stm),
                StaticIdentifier stm => Visit(options, stm),
                StringOperand stm => Visit(options, stm),
                _ => throw new ArgumentOutOfRangeException($"Expression '{exp.GetType().FullName}' not implemented"),
            };            
        }

        public string Visit(FunctionOptions options, BooleanOperand exp)
        {
            return exp.Value.ToLowerInvariant();
        }

        public virtual string Visit(FunctionOptions options, Cast exp)
        {
            string code;

            if (exp.Expression.DataType.IsDecimal()
                && exp.DataType.IsInteger())
            {
                code = $"parseInt(({Transform(options, exp.Expression)}) as any)";
            }
            else if (exp.Expression.DataType.IsInteger() && exp.DataType.IsDecimal())
            {
                code = $"parseFloat(({Transform(options, exp.Expression)}) as any)";
            }
            else if (exp.Expression.DataType.IsString())
            {
                code = $"{Transform(options, exp.Expression)}.toString()";
            }
            else if (exp.Expression.DataType.IsBool())
            {
                code = $"Boolean({Transform(options, exp.Expression)})";
            }
            else if (exp.Expression.DataType.IsDate())
            {
                code = $"Date.parse({Transform(options, exp.Expression)})";
            }
            else
            {
                var dt = _dataTypeTransformer.GetDataTypeName(exp.DataType);
                code = $"({Transform(options, exp.Expression)} as {dt})";
            }

            return code;
        }

        public string Visit(FunctionOptions options, CharacterOperand exp)
        {
            return $"'{exp.Value.ToString(CultureInfo.InvariantCulture)}'";
        }

        public string Visit(FunctionOptions options, Conditional exp)
        {
            var condition = Transform(options, exp.Condition);
            var evaluatedFalse = Transform(options, exp.FalseExpression);
            var evaluatedTrue = Transform(options, exp.TrueExpression);

            return $"({condition} ? {evaluatedTrue} : {evaluatedFalse})";
        }

        public string Visit(FunctionOptions options, DecimalOperand exp)
        {
            return $"{exp.IntPart}.{exp.DecPart}";
        }

        public string Visit(FunctionOptions options, Identifier exp)
        {
            return exp.IdName == "this" ? "$this" : GetMemberName(options, null, exp, exp, true, string.Empty, true);
        }

        public string Visit(FunctionOptions options, IntegerOperand exp)
        {
            int.TryParse(exp.Value.Replace(" ", ""), out int numb);
            return numb.ToString();
        }

        public string Visit(FunctionOptions options, Lambda exp)
        {
            var statementTransformer = 
                new StatementTransformer(_libraryHelper, this, new CompilerOptions { GenerateNullCheckCode = options.GenerateNullCheckCode });
            var omitDeclaration = false;

            var statements = "{}";
            if (exp.Exp != null)
            {
                statements = exp.Statements?.Count > 1
                    ? string.Join(" ", exp.Statements.Select(stmt => statementTransformer.Visit(options, stmt)))
                    : Transform(options, exp.Exp);
            }
            else
            {
                statements = string.Join(" ", exp.Statements.Select(stmt => statementTransformer.Visit(options, stmt)));
            }

            var bodyCode = exp.Statements?.Count > 1
                ? $"{{{statements}}}"
                : statements;

            var parameters = string.Join(",", exp.Parameters.Select(p => VariableNameConverter.Convert(p.Name)));

            return omitDeclaration ? bodyCode : $"({parameters}) => {bodyCode}";
        }

        public string Visit(FunctionOptions options, LogicalComparison exp)
        {
            var atLeastOneNumber = exp.Left.DataType.IsNumber() || exp.Right.DataType.IsNumber();

            var prevNullSafe = options.GenerateNullCheckCode;
            if (atLeastOneNumber)
            {
                options.GenerateNullCheckCode = false;
            }
            var left = Transform(options, exp.Left);
            var right = Transform(options, exp.Right);
            if (atLeastOneNumber)
            {
                options.GenerateNullCheckCode = prevNullSafe;
            }

            string op;

            if (exp.Left.DataType.IsNumber())
            {
                // left = ConvertToSafeNumericExpression(left);
            }
            else if (exp.Left.DataType.IsDate() && !(exp.Right is Null))
            {
                left = $"(new Date({left}).getTime())";
            }

            if (exp.Right.DataType.IsNumber())
            {
                // right = ConvertToSafeNumericExpression(right);
            }
            else if (exp.Right.DataType.IsDate() && !(exp.Left is Null))
            {
                right = $"(new Date({right}).getTime())";
            }

            if (Equals(exp.Operator, Operator.EQUALITY))
                op = "==";
            else if (Equals(exp.Operator, Operator.INEQUALITY))
                op = "!=";
            else if (Equals(exp.Operator, Operator.LESS_THAN))
                op = "<";
            else if (Equals(exp.Operator, Operator.LESS_THAN_OR_EQUAL))
                op = "<=";
            else if (Equals(exp.Operator, Operator.GREATER_THAN))
                op = ">";
            else if (Equals(exp.Operator, Operator.GREATER_THAN_OR_EQUAL))
                op = ">=";
            else
                throw new ArgumentOutOfRangeException(
                    $"Operator {exp.Operator} is not implemented for LogicalComparison expression");

            return $"{left} {op} {right}";
        }

        public string Visit(FunctionOptions options, Logical exp)
        {
            var left = Transform(options, exp.Left);
            var right = Transform(options, exp.Right);
            string op;

            if (Equals(exp.Operator, Operator.LOGICAL_AND))
                op = "&&";
            else if (Equals(exp.Operator, Operator.LOGICAL_OR))
                op = "||";
            else
                throw new ArgumentOutOfRangeException(
                    $"Operator {exp.Operator} is not implemented for Logical expressions");

            return $"{left} {op} {right}";
        }

        public string Visit(FunctionOptions options, LogicalNot exp)
        {
            return $"!({Transform(options, exp.Expression)})";
        }

        public string Visit(FunctionOptions options, Math exp)
        {
            var left = Transform(options, exp.Left);
            var right = Transform(options, exp.Right);
            string op;

            if (exp.Left.DataType.IsNumber())
            {
                left = _nullSafeTransformer.SafeNumberTransform(left);
            }

            if (exp.Right.DataType.IsNumber())
            {
                right = _nullSafeTransformer.SafeNumberTransform(right);
            }

            if (Equals(exp.Operator, Operator.PLUS)) op = "+";
            else if (Equals(exp.Operator, Operator.MINUS)) op = "-";
            else if (Equals(exp.Operator, Operator.MULTIPLICITY)) op = "*";
            else if (Equals(exp.Operator, Operator.DIVISION)) op = "/";
            else if (Equals(exp.Operator, Operator.REMAINDER)) op = "%";
            else if (Equals(exp.Operator, Operator.POWER))
            {
                return $"Math.pow({left}, {right})";
            }
            else
                throw new ArgumentOutOfRangeException("Operator " + exp.Operator +
                                                      " is not implemented for Math expression");

            return $"{left} {op} {right}";
        }

        public string Visit(FunctionOptions options, Member member, Expression toMember = null, bool forNextPart = false)
        {
            AsyncCheck = true;

            var memberString = "";
            ClassContainer ctx = null;
            ClassContainer oldContext = null;
            Expression oldMember = null;
            var firstParsed = string.Empty;
            var isFirst = true;

            for (var index = 0; index < member.Members.Count; index++)
            {
                var currentExp = member.Members[index];

                if (toMember != null && currentExp == toMember) break;

                memberString = TransformMember(options, member, currentExp, ctx, oldMember, oldContext, memberString,
                    index == member.Members.Count - 1, isFirst);

                firstParsed = isFirst ? memberString : firstParsed;

                isFirst = false;
                oldMember = member;
                oldContext = ctx;
                ctx = currentExp.DataType;
            }
            return ClosePartialRuleMember(options, member, memberString);
        }

        public string Visit(FunctionOptions options, Null exp)
        {
            return "null";
        }

        public string Visit(FunctionOptions options, Parenthesis exp)
        {
            return $"({Transform(options, exp.InnerExpression)})";
        }

        public string Visit(FunctionOptions options, StaticIdentifier exp)
        {
            return _libraryHelper.FindFullName(exp.DataType);
        }

        public string Visit(FunctionOptions options, StringOperand exp)
        {
            return exp.Value;
        }

        public string Visit(FunctionOptions options, InlineCollectionInitializer exp)
        {
            var parsedExpressions = "";
            foreach (var expression in exp.Expressions)
            {
                if (!string.IsNullOrEmpty(parsedExpressions)) parsedExpressions += ", ";
                parsedExpressions += Transform(options, expression);
            }

            switch (exp.DataType.Name)
            {
                case "Collection":
                case "Array":
                    return $"[{parsedExpressions}]";

                default:
                    throw new NotImplementedException($"InLine Assignment for '{exp.DataType.Name}' not implemented");
            }
        }

        public string Visit(FunctionOptions options, MemberWithExpression exp)
        {
            if (!(exp.EndExpression is FunctionCall))
                return Transform(options, exp.StartExpression) + Transform(options, exp.EndExpression);

            var alreadyParsed = Transform(options, exp.StartExpression);

            return TransformFunctionCall(options, exp.EndExpression as FunctionCall,
                alreadyParsed, null);
        }

        public string Visit(FunctionOptions options, FunctionCall exp)
        {
            return TransformFunctionCall(options, exp, "", null);
        }

        public string Visit(FunctionOptions options, Constructor ctr)
        {
            var code = new StringBuilder(100 + ctr.Assigments.Count * 100);
            code.AppendLine($"{{");
            foreach (var item in ctr.Assigments)
            {
                code.Append($"{item.Property.Name}: {Parse(options, item.Value)},");
            }
            code.AppendLine("}");
            return code.ToString();
        }

        public static List<Expression> GetMemberAndIdentifierExpressionsUsedInFormFunctions(Function f, bool deep = true)
        {
            var memberExpressions = f.AllExpressions.Where(e => e is Member || e is Identifier).ToList();
            return memberExpressions;
        }

        public static string GetExecuteControllerActionExpression(WebFormView currentForm, Action controllerAction, string postParameters,
            string getParameters,
            string callbackName = "", WebFormView ownerView = null)
        {
            throw new NotImplementedException();
        }

        public string GetExecuteControllerAction(
            WebFormView currentForm,
            Action controllerAction,
            string callbackName = "",
            WebFormView ownerView = null,
            string parameters = "")
        {
            throw new NotImplementedException();
        }
        
        public bool IsConstant(Expression expression)
        {
            return expression is BooleanOperand || expression is DecimalOperand
                || expression is StringOperand || expression is CharacterOperand
                || expression is IntegerOperand || expression is Null;
        }

        public string GetInjectValueToViewCode(FunctionOptions options, Expression injectionCode)
        {
            if (injectionCode == null) return "''";

            var expression = Transform(options, injectionCode);

            if (IsConstant(injectionCode))
            {
                return expression.Replace("\"", "'");
            }
            else
            {
                expression = expression
                    .Replace("$scope.", "")
                    .Replace("_CurrentItem", "Item");

                return injectionCode.DataType.IsString() ?
                    $"'{{{{{expression}}}}}'" :
                    $"{{{{{expression}}}}}";
            }
        }

        public string GetExpressionInjectValueToViewCode(FunctionOptions options, Expression injectionCode)
        {
            if (injectionCode == null) return "''";

            var expression = Transform(options, injectionCode);

            if (IsConstant(injectionCode))
            {
                var constantCode = expression.Replace("\"", "'");

                if (injectionCode is StringOperand)
                {
                    return $"'{expression.Replace("\"", "\\'")}'";
                }

                return constantCode;
            }
            else
            {
                expression = expression
                    .Replace("_CurrentItem", "Item");

                if (injectionCode.DataType.IsString())
                {
                    return $"'\'{expression}\''";
                }
                else if (injectionCode.DataType.IsDate())
                {
                    return $"`'${{{expression}.toJSON()}}'`";
                }
                else
                {
                    return $"{expression}";
                }
            }
        }

        public bool MethodResultMustBeQueryable(FunctionOptions options, FunctionCall call)
        {
            throw new NotImplementedException();
        }

        public string ResolveControllerActionFunction(FunctionCall call, string formName, string actionName)
        {
            throw new NotImplementedException();
        }

        public string ParseFunctionParameter(FunctionOptions options, FunctionCall fcall, Expression parameter)
        {
            throw new NotImplementedException();
        }

        private string VisitMemberNullishCoalescing(FunctionOptions options, Member member)
        {
            if (options.GenerateNullCheckCode)
            {
                return _nullSafeTransformer
                    .NullSafeMemberWrapping(options, member, (options, member) => Visit(options, member));
            }
            else
            {
                return Visit(options, member);
            }
        }

        private string ClosePartialRuleMember(FunctionOptions options, Member exp, string memberString)
        {
            if (exp.Members.Count <= 0) return memberString;

            if (options.Scope != CompilerScope.Rule) return memberString;

            if (!(exp.Members[0] is Identifier firstMemberDataType)) return memberString;

            var isInFormLib = _libraryHelper
                    .GetOwnerModule(firstMemberDataType.Variable.DataType)
                    .Equals(ModuleNames.FormModelsLib);

            return memberString;
        }

        protected virtual string TransformFunctionCall(FunctionOptions options,
                                                       FunctionCall fcall,
                                                       string alreadyParsed,
                                                       Member previousMember)
        {
            var parameters = string.Join(", ", fcall.Parameters.Select(param => Transform(options, param)));
            return fcall.Function.IsStatic
                ? _libraryHelper.GetStaticMethod(options, fcall, alreadyParsed, parameters, previousMember)
                : _libraryHelper.GetInstanceMethod(options, fcall, alreadyParsed, parameters, previousMember);
        }

        protected virtual string TransformMember(FunctionOptions options,
                                                 Member expressionMember,
                                                 Expression member,
                                                 ClassContainer context,
                                                 Expression prevMember,
                                                 ClassContainer oldContext,
                                                 string alreadyParsed,
                                                 bool isLast,
                                                 bool isFirst = true)
        {
            var fullNamesRequiringConcat = new List<string>()
            {
                "Repeater",
                "select",
                "radioButtons",
                "Grid",
                "List"
            };

            var idNode = member as Identifier;

            if (idNode != null)
            {
                if (alreadyParsed == "" 
                    && idNode.IdName == "this")
                {
                    return "$this";
                }
            }

            // e.g. repeater.item must be concated with repeater name as "Item" to return "repeaterNameItem" string            
            if (idNode != null && idNode.IdName == "item" &&
                fullNamesRequiringConcat.Contains(idNode.Variable.GetParent().FullName))
            {
                var repeaterItemIndex = ((Member)prevMember).Members.IndexOf(idNode) - 1;
                var repeaterItemNode = ((Member)prevMember).Members[repeaterItemIndex] as Identifier;
                // FormHelper.GetContextControlItemName(repeaterItemNode.IdName);
                return alreadyParsed + "Item";
            }

            if (idNode != null)
            {
                return GetMemberName(options, context, expressionMember, idNode, isLast, alreadyParsed, isFirst);
            }
            else if (member is StaticIdentifier staticIdNode)
            {
                //if (options.GenerateNullCheckCode)
                return _nullSafeTransformer.ConcatMembers(options, alreadyParsed, Visit(options, staticIdNode));
                //return (string.IsNullOrEmpty(alreadyParsed) ? "" : $"{alreadyParsed}.") + Visit(options, staticIdNode);
            }

            if (member is FunctionCall fcall)
            {
                return TransformFunctionCall(options, fcall, alreadyParsed, prevMember as Member);
            }

            if (member is EnumerationIdentifier enumCall)
            {
                var isInterfacesEnum = context.GetParent()?.GetParent()?.Name == "Interfaces";
                if (isInterfacesEnum == true)
                {
                    var val = (context as Enumeration)?.Values?.FirstOrDefault(v => v.Name == enumCall.LiteralName)?.Value;
                    return $"{val} /* Interfaces.{context.GetParent().Name}.{context.Name}.{enumCall.LiteralName} */";

                }
                return $"{_dataTypeTransformer.Transform(context as TypeClass)}.{enumCall.LiteralName}";
            }

            return "";
        }

        protected virtual string GetMemberName(FunctionOptions options,
                                               ClassContainer type,
                                               Expression parentExpression,
                                               Identifier idNode,
                                               bool isLastMember,
                                               string parsed,
                                               bool isFirst)
        {
            if (idNode?.IdName == "$root") return "model";

            if (isFirst && type == null && idNode.Variable != null)
            {
                type = idNode.Variable.GetParent() as TypeClass;

                if (type == null)
                {
                    if (idNode.IdName.EndsWith("_CurrentItem")) //todo: more sophisticated
                    {
                        if (options.ContextItemResolutionCallback != null)
                        {
                            return
                                options.ContextItemResolutionCallback(idNode.IdName.Replace("_CurrentItem", ""));
                        }
                    }

                    return VariableNameConverter.Convert(idNode.IdName);
                }
            }

            var assign = idNode.ParentStatement as Assign;
            var result = _libraryHelper.GetMemberName(options, type as TypeClass, idNode, parsed, assign != null && parentExpression == assign.LeftHandPart); //edwedwedw
            return VariableNameConverter.Convert(result);
        }

        public string ParseExpressionWithGetValueOrDefault(FunctionOptions options, Expression assignTo, Expression expression)
        {
            throw new NotImplementedException();
        }

        public void Init()
        {
            throw new NotImplementedException();
        }
    }
}
