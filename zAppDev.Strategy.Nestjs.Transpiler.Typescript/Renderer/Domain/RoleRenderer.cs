using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.Domain;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Domain
{
    public class RoleRenderer : IRoleRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;
        public RoleRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }
        public string AddPermission(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"AddPermission");
        }

        public string AddPermissionByName(string parsed, string parameters)
        {
            throw new NotImplementedException();
        }

        public string AddUser(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"AddUser");
        }

        public string HasPermission(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"HasPermission");
        }

        public string RemovePermission(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"RemovePermission");
        }

        public string RemovePermissionByName(string parsed, string parameters)
        {
            throw new NotImplementedException();
        }

        public string RemoveUser(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"RemoveUser");
        }

        public string Save(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"Save");
        }
    }
}
