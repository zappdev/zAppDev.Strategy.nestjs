using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer;
using CLMS.Lang.Model.Expressions;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer
{
    public class EventsLibRenderer : IEventsRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public EventsLibRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _compiler = compiler;
            _helper = helper;
        }

        public string GetRaiseImplementation(FunctionCall call, string parsed, string parameters)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode($"EventsLib.${call.FName}");
        }
    }
}
