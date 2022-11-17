using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.Domain;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Domain
{
    public class PermissionRenderer : IPermissionRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;
        public PermissionRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public string AddRole(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"AddRole");
        }

        public string AddUser(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"AddUser");
        }

        public string RemoveRole(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"RemoveRole");
        }

        public string RemoveUser(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"RemoveUser");
        }
    }
}
