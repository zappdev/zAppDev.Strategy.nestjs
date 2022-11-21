using CLMS.AppDev.MetaModels.Interface;
using System.Text;
using zAppDev.Strategy.Nestjs.Transpiler.Typescript.Factory;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Utilities.Transformer;

namespace zAppDev.Strategy.Nestjs.Generator.Generators.Services
{
    internal class DTOGenerator : TypescriptGenerator<Interface>
    {
        private IDataTypeTransformer _datatypeTransformer;

        public DTOGenerator(EngineSession session)
        {
            _datatypeTransformer = new TypescriptTranspilerFactory()
                    .BuildCompiler(session.Config.Solution, new Strategy.Transpiler.Base.Models.CompilerOptions
                    {
                        
                    }).DataTypeTransformer;
        }

        public override string GetFilename(Interface model)
        {
            return $"{model.Name}.dto.ts";
        }

        protected override string RenderImports(Interface model)
        {
            return $"";
        }

        protected override string RenderClass(Interface model)
        {
            var code = new StringBuilder();

            
            return code.ToString();
        }
    }
}
