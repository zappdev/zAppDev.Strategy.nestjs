using CLMS.Lang.Model.Expressions;
using System;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.AppLib;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.AppLib
{
    public class AppRenderer : IAppRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;
        public AppRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> ErrorGetFriendlyMessage()
        {
            return null;
        }

        public Func<FunctionOptions, string, bool, string> ErrorMessage()
        {
            return (options, parsed, isAssignment) => parsed + ".message";
        }

        public string ErrorName()
        {
            return "System.Error";
        }

        public Func<FunctionOptions, string, bool, string> ErrorStackTrace()
        {
            return (options, parsed, isAssignment) => parsed + ".stack";
        }

        public Func<FunctionOptions, string, bool, string> ExpiresIn()
        {
            return (options, parsed, isAssignment) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);
        }

        public string MessageTypeName()
        {
            return "";
        }

        public Func<FunctionOptions, string, bool, string> Token()
        {
            return (options, parsed, isAssignment) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);
        }

        public string TokenInfoTypeName()
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode("AppLib.TokenInfo");
        }
    }
}
