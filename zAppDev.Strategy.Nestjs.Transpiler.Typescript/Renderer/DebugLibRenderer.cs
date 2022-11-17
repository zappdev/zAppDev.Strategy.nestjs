using CLMS.Lang.Model.Expressions;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Models;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer
{
    public class DebugLibRenderer : IDebugLibRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public DebugLibRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _compiler = compiler;
            _helper = helper;
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> Assert()
        {
            return (options, parsed, parameters, fcall) => {
                return _helper.NotImplementedHelper.GetNotImplementedCode(parsed, parameters, fcall);
            };
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Write()
        {
            return GetLogFunctionInvocation("Debug");
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> WriteErrorLine()
        {
            return GetLogFunctionInvocation("Error");
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> WriteInfoLine()
        {
            return GetLogFunctionInvocation("Info");
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> WriteLine()
        {
            return GetLogFunctionInvocation("Debug");
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> WriteWarnLine()
        {
            return GetLogFunctionInvocation("Warning");
        }

        protected virtual Func<FunctionOptions, string, string, FunctionCall, string> GetLogFunctionInvocation(string debugEvent)
        {
            return (options, parsed, parameters, fcall) => {
                return _helper.NotImplementedHelper.GetNotImplementedCode($"DebugLib.{debugEvent}");
            };
        }


    }
}
