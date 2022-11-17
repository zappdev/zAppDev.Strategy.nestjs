using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Metadata;
using zAppDev.Strategy.Transpiler.Base.Models;
using CLMS.Lang.Model.Structs;
using System.Linq;
using System.Text;
using System;
using CLMS.Lang.Model.Expressions;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Core
{
    public class FunctionTransformer : IFunctionTransformer
    {

        public INullSafeTransformer NullSafeTransformer { get; set; }

        public IMetadataService MetadataService { get; set; }

        public IStatementTransformer StatementTransformer { get; set; }

        public IExpressionTransformer ExpressionTransformer { get; set; }

        public IDataTypeTransformer DataTypeTransformer { get; set; }

        public ITypeHelpers TypeHelper { get; set; }

        public ILibraryHelper LibraryHelper { get; set; }

        public INullExpressionParserHelper NullExpressionParserHelper { get; set; }

        public Func<CLMS.Lang.Model.Statement.Assign, string, string, string> OnAssigment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Func<Cast, string, string> OnCast { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Func<Lambda, string, string> OnLambdaExpression { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Func<Member, string, string> OnMemberExpression { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public FunctionTransformer()
        {

        }

        public FunctionResults Transform(FunctionOptions options)
        {
            options = MetadataService.GetMetadata(options);

            if (!options.Metadata.IsRenderable) return new FunctionResults("", false);

            var code = new StringBuilder(128);

            var func = options.Function;
            var needsHeader = func != null && options.OmmitHeader == false;

            if (needsHeader)
            {
                code.Append(GenerateDeclaration(func, options.Type, "", "", options.IsAsync));
                code.Append('{');
            }

            code.Append(GenerateBody(options));

            if (needsHeader)
            {
                code.Append('}');
            }

            return new FunctionResults(code.ToString());
        }

        private static string GenerateDeclaration(Function function, FunctionType type,
            string name = "", string paramCode = "", bool isAsync = false)
        {
            if (string.IsNullOrEmpty(paramCode))
            {
                paramCode = string.Join(",",
                    function.Parameters.Select(c => $"{VariableNameConverter.Convert(c.Name)}: any"));

                if (!function.IsStatic &&
                    function.GetParent() is TypeClass @class &&
                    !@class.IsSystemic)
                {
                    paramCode = "$this: any" + (string.IsNullOrEmpty(paramCode) ? "" : ", ") + paramCode;
                }
            }

            var asyncKeyword = isAsync ? "async " : "";
            var dt = isAsync ? "Promise<any> " : "any";

            name = string.IsNullOrEmpty(name) ? function.Name : name;

            return type switch
            {
                FunctionType.Assigment => $"{name} = ({paramCode}): {dt} => ",
                FunctionType.ControllerAction => $"{name}({paramCode}): {dt}",
                FunctionType.Member => $"{asyncKeyword}{name}({paramCode}): {dt}",
                FunctionType.Static => $"static {asyncKeyword}{name}({paramCode}): {dt}",
                _ => $"{asyncKeyword}function {name}({paramCode}): {dt}",
            };
        }

        public string GenerateBody(FunctionOptions options)
        {
            if (options.Function == null) return "";

            var body = new StringBuilder();

            foreach (var statement in options.Function.Statements)
            {
                body.AppendLine(StatementTransformer.Visit(options, statement).Code);
            }
            return body.ToString();
        }

        public string ParseDataType(TypeClass typeClass)
            => DataTypeTransformer.Transform(typeClass);

        public string GetSafeIdentifierName(string identifier)
        {
            return VariableNameConverter.Convert(identifier);
        }
    }
}
