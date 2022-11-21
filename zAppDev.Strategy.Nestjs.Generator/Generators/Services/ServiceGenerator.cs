using CLMS.AppDev.MetaModels.Interface;
using zAppDev.Strategy.Transpiler.Base.Core;
using System.Text;
using zAppDev.Strategy.Utilities.Transformer;
using zAppDev.Strategy.Nestjs.Transpiler.Typescript.Factory;

namespace zAppDev.Strategy.Nestjs.Generator.Generators.Services
{
    internal class ServiceGenerator : TypescriptGenerator<Interface>
    {
        private IFunctionTransformer _codeTransformer;

        public ServiceGenerator(EngineSession session)
        {
            _codeTransformer = new TypescriptTranspilerFactory().BuildCompiler(session.Config.Solution, new Strategy.Transpiler.Base.Models.CompilerOptions
            {

            });
        }

        public override string GetFilename(Interface model)
        {
            return $"{model.Name}.service.ts";
        }

        protected override string RenderImports(Interface model)
        {
            return @"import { Injectable } from '@nestjs/common';
import * as Domain from '@entity/index';
import { EntityRepository } from '@framework/service/entityRepository.service';";
        }

        protected override string RenderClass(Interface model)
        {
            var code = new StringBuilder();

            code.AppendLine($@"@Injectable()
export class {model.Name}Service {{

constructor(private repository: EntityRepository) {{}}
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
            var returnDatatype = "any";// _datatypeParser.Transform(op.Signature.DataType);
            var parameters = string.Join(", ", 
                op.Signature.Parameters.Select(p => $"{p.Name}: {_codeTransformer.DataTypeTransformer.Transform(p.DataType)}")
            );

            var temp = string.Join(", ",
                op.Signature.Parameters.Select(p => $"{p.Name}")
            );

            code.AppendLine($"async {op.Name}({parameters}): Promise<{returnDatatype}> {{");
            code.Append(
                _codeTransformer.GenerateBody(new zAppDev.Strategy.Transpiler.Base.Models.FunctionOptions(methodDetails.Implementation)
            ));
            code.AppendLine("}");
            code.AppendLine("");
        }
    }
}
