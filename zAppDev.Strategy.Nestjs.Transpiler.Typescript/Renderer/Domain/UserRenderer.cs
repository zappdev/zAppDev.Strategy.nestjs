using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.Domain;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Domain
{
    public class UserRenderer : IUserRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public UserRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
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
            return _helper.NotImplementedHelper.GetNotImplementedCode($"AddPermissionByName");
        }

        public string AddToRole(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"AddToRole");
        }

        public string Delete(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"Delete");
        }

        public string HasPermission(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"HasPermission");
        }

        public string ReadExternalProfile()
        {
            throw new NotImplementedException();
        }

        public string Register(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"Register");
        }

        public string RemoveFromRole(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"RemoveFromRole");
        }

        public string RemovePermission(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"RemovePermission");
        }

        public string Save(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"Save");
        }

        public string Unregister(string parsed, string parameters)
        {
            throw new NotImplementedException();
        }
    }
}
