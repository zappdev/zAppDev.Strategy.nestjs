using CLMS.AppDev.MetaModels.Application;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.ApplicationLib;
using CLMS.Lang.Model.Expressions;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer
{
    public class ApplicationRenderer : IApplicationRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public ApplicationRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _compiler = compiler;
            _helper = helper;
        }

        public string GetApplicationSettingMember(Identifier identifier)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode("");
        }

        public string GetDefaultPagesMember()
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode("");
        }

        public string GetPermisionOrRoleMember(Identifier identifier)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode("");
        }

        public string GetPermission(string parsed, bool isAssignement, string permission)
            => $"\"{permission}\"";

        public string GetRole(string parsed, bool isAssignement, string role)
            => $"\"{role}\"";

        public string GetStaticMethod(FunctionCall call, DefaultAction action)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode("");
        }
    }
}
