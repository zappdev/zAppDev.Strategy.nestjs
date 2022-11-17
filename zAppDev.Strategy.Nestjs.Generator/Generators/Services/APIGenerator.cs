using CLMS.AppDev.MetaModels.Interface;
using System.Text;
using zAppDev.Strategy.Nestjs.Generator.Language.Core;
using zAppDev.Strategy.Utilities.Transformer;

namespace zAppDev.Strategy.Nestjs.Generator.Generators.Services
{
    internal class APIGenerator : TypescriptGenerator<Interface>
    {
        private DataTypeTransformer _datatypeParser;

        public APIGenerator()
        {
            _datatypeParser = new DataTypeTransformer();
        }

        public override string GetFilename(Interface model)
        {
            return $"{model.Name}.api.ts";
        }

        protected override string RenderImports(Interface model)
        {
            return $@"import {{ Controller, Get, Post, Put, Delete, Req }} from '@nestjs/common';
import {{ Request }} from 'express';
import {{ {model.Name}Service }} from '@service/exposed/{model.Name}.service'";
        }

        protected override string RenderClass(Interface model)
        {
            var code = new StringBuilder();

            code.AppendLine(@$"@Controller('api/{model.Name}')
export class {model.Name}Controller {{

constructor(private service: {model.Name}Service) {{ }}
");

            foreach (var op in model.Methods)
            {
                RenderOperation(code, op);
            }

            code.AppendLine("}");

            return code.ToString();
        }

        private void RenderOperation(StringBuilder code, InterfaceMethod op)
        {
            var methodDetails = op.ImplementationDetails as ExposeInterfaceMethodDetails;
            var verb = methodDetails.HttpVerb switch
            {
                RestHTTPVerb.GET => "Get",
                RestHTTPVerb.POST => "Post",
                RestHTTPVerb.PUT => "Put",
                RestHTTPVerb.DELETE => "Delete",
                _ => throw new NotImplementedException($"Http Verb {methodDetails.HttpVerb} is not implemented")
            };

            var returnDatatype = "any";
            var parameters = "";
            if (methodDetails.HttpVerb == RestHTTPVerb.GET)
            {
                parameters = string.Join(", ", op.Signature.Parameters.Select(p => $"request.query.{p.Name} as any"));
            }
            else
            {
                parameters = "request.body";
            }

            code.AppendLine($"@{verb}('{op.Name}')");
            code.AppendLine($"{op.Name}(@Req() request: Request): {returnDatatype} {{");
            code.AppendLine($"return this.service.{op.Name}({parameters});");
            code.AppendLine("}");
            code.AppendLine("");
        }
    }
}
