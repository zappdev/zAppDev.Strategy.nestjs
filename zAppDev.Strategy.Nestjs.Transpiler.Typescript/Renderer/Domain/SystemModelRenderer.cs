using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.Domain;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Domain
{
    public class SystemModelRenderer : ISystemModelRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public SystemModelRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public string ApplicationLanguageGetAvailable(string parsed, string parameters, bool isStatic = false)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"ApplicationLanguageGetAvailable");
        }

        public string ApplicationThemeGetAvailable(string parsed, string parameters, bool isStatic = false)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"ApplicationThemeGetAvailable");
        }

        public string ApplicationTimezoneInfoGetAvailable(string parsed, string parameters, bool isStatic = false)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"ApplicationTimezoneInfoGetAvailable");
        }

        public string ApplicationTimezoneInfoGetBaseUtcOffset(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"ApplicationTimezoneInfoGetBaseUtcOffset");
        }

        public string ApplicationTimezoneInfoGetUtcOffset(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"ApplicationTimezoneInfoGetUtcOffset");
        }

        public string ApplicationUserHasPermission(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"ApplicationUserHasPermission");
        }

        public string ApplicationUserIsInRole(string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"ApplicationUserIsInRole");
        }
    }
}
