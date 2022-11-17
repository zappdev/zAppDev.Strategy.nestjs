using CLMS.Lang.Model.Expressions;
using System;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.Common;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Common
{
    public class StopwatchRenderer : IStopwatchRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public StopwatchRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> GetElapsed()
        => (options, parsed, @params, fcall) => $"{parsed}.elapsed";

        public Func<FunctionOptions, string, string, FunctionCall, string> GetElapsedMilliseconds()
            => (options, parsed, @params, fcall) => $"{parsed}.elapsedMilliseconds";

        public Func<FunctionOptions, string, string, FunctionCall, string> Reset()
            => (options, parsed, @params, fcall) => $"{parsed}.reset()";

        public Func<FunctionOptions, string, string, FunctionCall, string> Restart()
            => (options, parsed, @params, fcall) => $"{parsed}.restart()";

        public Func<FunctionOptions, string, string, FunctionCall, string> Start()
            => (options, parsed, @params, fcall) => $"{parsed}.start()";

        public Func<FunctionOptions, string, string, FunctionCall, string> Stop()
            => (options, parsed, @params, fcall) => $"{parsed}.stop()";

        public string StopwatchName()
            => "System.Diagnostics.Stopwatch";
    }
}
