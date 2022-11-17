using CLMS.Lang.Model.Expressions;
using System;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.AppLib;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.AppLib
{
    public class SessionRenderer : ISessionRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public SessionRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> SessionAbandon()
        {
            return (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode("AppLib.SessionAbandon");
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> SessionClearAuditTrailCache()
        {
            return null;
        }

        public Func<FunctionOptions, string, bool, string> SessionCurentLanguage()
        {
            return (options, parsed, isAssignement) => _helper.NotImplementedHelper.GetNotImplementedCode("AppLib.SessionCurentLanguage");
        }

        public Func<FunctionOptions, string, bool, string> SessionCurrentLocale()
        {
            return (options, parsed, isAssignement) => _helper.NotImplementedHelper.GetNotImplementedCode("AppLib.SessionCurrentLocale");
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> SessionGetCurrentUser()
        {
            return (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode("AppLib.SessionGetCurrentUser");
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> SessionGetCurrentUserName()
        {
            return (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode("AppLib.SessionGetCurrentUserName");
        }

        public string SessionName()
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode("AppLib.Session");
        }

        public virtual Func<FunctionOptions, string, bool, string> Storage()
        {
            return (options, parsed, isAssignement) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);
        }
    }
}
