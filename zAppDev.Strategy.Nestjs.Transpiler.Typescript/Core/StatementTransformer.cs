using zAppDev.Strategy.Transpiler.Base.Common;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Shim;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Statement;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using FunctionCall = CLMS.Lang.Model.Expressions.FunctionCall;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Core
{
    public class StatementTransformer : IStatementTransformer
    {
        private readonly IExpressionTransformer _expressionTransformer;

        private readonly ILibraryHelper _libraryHelper;

        public string BeforeStatementCode { get; set; }

        public readonly bool GenerateNullCheckCode;

        public StatementTransformer(ILibraryHelper libraryHelper,
                                    IExpressionTransformer expressionTransformer,
                                    CompilerOptions options)
        {
            GenerateNullCheckCode = options.GenerateNullCheckCode;
            _libraryHelper = libraryHelper;
            _expressionTransformer = expressionTransformer;
        }


        public StatementParseResult Visit(FunctionOptions options, Statement statement, bool isParsingLambdaExpression = false)
        {
            StatementParseResult res = statement switch
            {
                Assign stm => Visit(options, stm),
                Break stm => Visit(options, stm),
                Call stm => Visit(options, stm),
                Catch stm => Visit(options, stm),
                Comment stm => Visit(options, stm),
                Continue stm => Visit(options, stm),
                Define stm => Visit(options, stm),
                Else stm => Visit(options, stm),
                ElseIf stm => Visit(options, stm),
                Finally stm => Visit(options, stm),
                For stm => Visit(options, stm),
                Foreach stm => Visit(options, stm),
                If stm => Visit(options, stm),
                Return stm => Visit(options, stm),
                Switch stm => Visit(options, stm),
                SwitchCase stm => Visit(options, stm),
                SwitchDefaultCase stm => Visit(options, stm),
                Throw stm => Visit(options, stm),
                Try stm => Visit(options, stm),
                While stm => Visit(options, stm),
                _ => throw new ArgumentOutOfRangeException($"Statement '{statement.GetType().FullName}' not implemented"),
            };

            if (res == null)
            {
                throw new ArgumentOutOfRangeException(
                    $"Statement {statement?.GetType().FullName} interpretation not implemented");
            }

            return res;
        }

        public static bool IsAsynchronousExpression(Expression exp)
        {
            var member = exp as Member;
            var firstId = member?.Members[0] as StaticIdentifier;
            if (firstId == null) return false;

            return firstId.IdName == ModuleNames.ServiceLib && member.Members.Last() is FunctionCall;
        }

        public StatementParseResult Visit(FunctionOptions options, Assign statement)
        {
            var result = new StatementParseResult();

            // No null check for left hand part
            var originalNullCheckCodeConfiguration = options.GenerateNullCheckCode;
            options.GenerateNullCheckCode = false;
            var left = _expressionTransformer.Transform(options, statement.LeftHandPart);

            // Restore the null check code configuration of the expression transformer
            options.GenerateNullCheckCode = originalNullCheckCodeConfiguration;
            var right = _expressionTransformer.Transform(options, statement.RightHandPart);

            result.Code = (left.EndsWith(",") || left.EndsWith("(")) ? $"{left} {right});" : $"{left} = {right};";
            return result;
        }

        public StatementParseResult Visit(FunctionOptions options, Break statement)
        {
            return new StatementParseResult { Code = "break;" };
        }

        public StatementParseResult Visit(FunctionOptions options, For forStatement)
        {

            StringBuilder code = new StringBuilder(128);

            code
                .AppendFormat("for (var {0} = {1}; {2}; {0} = {3}) {{",
                    forStatement.VariableName,
                    _expressionTransformer.Transform(options, forStatement.InitExpression),
                    _expressionTransformer.Transform(options, forStatement.Condition),
                    _expressionTransformer.Transform(options, forStatement.Assigment)
                )
                .AppendLine();

            code.Append(TransformChildStatements(options, forStatement));

            code.AppendLine("}");

            return new StatementParseResult { Code = code.ToString() };
        }

        public StatementParseResult Visit(FunctionOptions options, Call statement)
        {
            var result = new StatementParseResult();

            var toWrite = _expressionTransformer.Transform(options, statement.Expression);

            // TODO Problem here, quick fix
            if (toWrite.Contains('(') || toWrite.Contains('='))
            {
                result.Code = $"{toWrite};";
                return result;
            }

            result.Code = $"{_expressionTransformer.Transform(options, statement.Expression)};";
            return result;
        }

        public StatementParseResult Visit(FunctionOptions options, Catch statement)
        {
            StringBuilder code = new StringBuilder(128);

            var catchExpression = statement.ExceptionType == null
                ? "(e)"
                : $"({VariableNameConverter.Convert(statement.VariableName)})";

            code.Append($"catch {catchExpression} {{");
            code.Append(TransformChildStatements(options, statement));
            code.Append('}');
            return new StatementParseResult { Code = code.ToString() };
        }

        public StatementParseResult Visit(FunctionOptions options, Finally @finally)
        {
            var code = new StringBuilder(128);
            code.AppendLine("finally {");
            code.Append(TransformChildStatements(options, @finally));
            code.AppendLine("}");
            return new StatementParseResult { Code = code.ToString() };
        }

        public StatementParseResult Visit(FunctionOptions options, Continue statement)
        {
            return new StatementParseResult { Code = "continue;" };
        }

        public StatementParseResult Visit(FunctionOptions options, Define statement)
        {
            var assigment = "";
            if (statement.AssigmentExpression != null)
            {
                assigment = $" = {_expressionTransformer.Transform(options, statement.AssigmentExpression)}";
            }
            else
            {
                var instantiation = _libraryHelper.GetInstantiationExpression(statement.Property.DataType);
                if (!string.IsNullOrEmpty(instantiation))
                {
                    assigment = $" = {instantiation}";
                }
            }

            var varName = VariableNameConverter.Convert(statement.VariableName);
            return new StatementParseResult { Code = $"let {varName}{assigment};" };
        }

        public StatementParseResult Visit(FunctionOptions options, Else statement)
        {
            StringBuilder code = new StringBuilder(128);
            code.Append("else {");
            code.Append(TransformChildStatements(options, statement));
            code.Append('}');
            return new StatementParseResult { Code = code.ToString() };
        }

        public StatementParseResult Visit(FunctionOptions options, ElseIf statement)
        {

            var code = new StringBuilder(128);
            code.Append($"else if ({_expressionTransformer.Transform(options, statement.Expression)}) {{");
            code.Append(TransformChildStatements(options, statement));
            code.Append('}');
            return new StatementParseResult { Code = code.ToString() };
        }

        public StatementParseResult Visit(FunctionOptions options, Foreach statement)
        {
            var collection = VariableNameConverter.Convert(_expressionTransformer.Transform(options, statement.Collection));

            var variableName = VariableNameConverter.Convert(statement.VariableName);
            var counterVar = $"_i{variableName}";
            var code = new StringBuilder(128);

            code.Append($"for (let {counterVar} = 0; {counterVar} < ({collection} == null ? 0 : {collection}.length); {counterVar}++) {{");

            code.Append($"let {variableName} = {collection}[{counterVar}];");

            code.Append(TransformChildStatements(options, statement));

            code.Append('}');

            return new StatementParseResult { Code = code.ToString() };
        }

        public StatementParseResult Visit(FunctionOptions options, If statement)
        {
            var code = new StringBuilder(128);

            code.Append($"if ({_expressionTransformer.Transform(options, statement.Expression)}) {{");

            code.Append(TransformChildStatements(options, statement));

            code.Append('}');

            string preCode = code.ToString();

            code = new StringBuilder(128);

            code.Append(statement.ElseIfStmt.Aggregate(preCode, (current, elseif) => current + Visit(options, elseif)));

            if (statement.ElseStmt != null)
            {
                code.Append(Visit(options, statement.ElseStmt));
            }

            return new StatementParseResult { Code = code.ToString() };
        }

        public StatementParseResult Visit(FunctionOptions options, Return statement)
        {
            if (options.ReturnStatementOverride != null)
            {
                var customResult = options.ReturnStatementOverride(statement, _expressionTransformer);
                if (customResult != null)
                {
                    return customResult;
                }
            }

            var result = new StatementParseResult
            {
                Code = statement.Expression == null
                ? "return;"
                : $"return {_expressionTransformer.Transform(options, statement.Expression)};"
            };
            return result;
        }

        public StatementParseResult Visit(FunctionOptions options, Throw statement)
        {
            var result = new StatementParseResult
            {
                Code = $"throw {_expressionTransformer.Transform(options, statement.StringExpression)};"
            };
            return result;
        }

        public StatementParseResult Visit(FunctionOptions options, SwitchCase statement)
        {
            StringBuilder code = new StringBuilder(128);

            code.AppendFormat($"case {_expressionTransformer.Visit(options, statement.Expression)}:");
            code.AppendLine();

            var hasChildStatements = statement.ChildStatements?.Any() == true;

            if (hasChildStatements)
            {
                code.AppendLine("{");
            }

            code.Append(TransformChildStatements(options, statement));

            if (ShouldGenerateSwitchBreak(statement))
            {
                code.AppendLine("break;");
            }

            if (hasChildStatements)
            {
                code.AppendLine("}");
            }

            return new StatementParseResult { Code = code.ToString() };
        }

        public StatementParseResult Visit(FunctionOptions options, Switch statement)
        {
            var code = $"switch ({_expressionTransformer.Transform(options, statement.Expression)}) {{";

            foreach (var s in statement.ChildStatements)
            {
                if (s is SwitchCase switchCase)
                {
                    code += Visit(options, switchCase);
                }
                else
                {
                    code += Visit(options, (SwitchDefaultCase)s);
                }
            }

            code += "}";

            return new StatementParseResult { Code = code };
        }

        public StatementParseResult Visit(FunctionOptions options, SwitchDefaultCase statement)
        {
            StringBuilder code = new StringBuilder(128);

            code.AppendLine("default:");

            var hasChildStatements = statement.ChildStatements?.Any() == true;

            if (hasChildStatements)
            {
                code.AppendLine("{");
            }

            code.Append(TransformChildStatements(options, statement));

            if (ShouldGenerateSwitchBreak(statement))
            {
                code.AppendLine("break;");
            }

            if (hasChildStatements)
            {
                code.AppendLine("}");
            }

            return new StatementParseResult { Code = code.ToString() };
        }

        public StatementParseResult Visit(FunctionOptions options, Try statement)
        {
            var code = new StringBuilder(128);
            code.Append("try {");

            code.Append(TransformChildStatements(options, statement));

            code.Append('}');

            return new StatementParseResult { Code = code.ToString() };
        }

        public StatementParseResult Visit(FunctionOptions options, While statement)
        {
            var code = new StringBuilder(128);
            code.Append($"while ({_expressionTransformer.Transform(options, statement.Expression)}) {{");

            code.Append(TransformChildStatements(options, statement));

            code.Append('}');

            return new StatementParseResult { Code = code.ToString() };
        }

        public StatementParseResult Visit(FunctionOptions options, Comment statement)
        {
            return new StatementParseResult() { Code = $"/* {statement.Text} */" };
        }

        public StatementParseResult ParseStatements(FunctionOptions options, List<Statement> statements)
        {
            var result = new StatementParseResult() { Code = "" };

            if (!statements.Any()) return result;

            result.Code = statements.Aggregate("", (current, s) => current + Visit(options, s));
            return result;
        }

        private StatementParseResult TransformChildStatements(FunctionOptions options, StatementWithChildren statement)
        {
            var result = new StatementParseResult() { Code = "" };

            if (statement.ChildStatements == null || !statement.ChildStatements.Any()) return result;

            result.Code = statement.ChildStatements.Aggregate("", (current, s) => current + Visit(options, s));
            return result;
        }

        private bool ShouldGenerateSwitchBreak(StatementWithChildren statement)
        {
            var isLastLabel = (statement.GetParent() as Switch).ChildStatements.LastOrDefault() == statement;
            var hasStatements = statement.ChildStatements.Any();

            if (!isLastLabel && !hasStatements)
            {
                return false;
            }

            if (hasStatements)
            {
                var lastStatement = statement.ChildStatements?.Last();

                if (lastStatement is Break || lastStatement is Return || lastStatement is Throw)
                {
                    return false;
                }
            }

            return true;
        }
    }
}