using CLMS.AppDev.MetaModels.Interface;
using zAppDev.Strategy.Utilities.Transformer;

namespace zAppDev.Strategy.Nestjs.Generator.Generators.Services
{
    internal class DTOGenerator : TypescriptGenerator<Interface>
    {
        public override string GetFilename(Interface model)
        {
            return $"{model.Name}.dto.ts";
        }

        protected override string RenderImports(Interface model)
        {
            return "";
        }

        protected override string RenderClass(Interface model)
        {
            return "";
        }
    }
}
