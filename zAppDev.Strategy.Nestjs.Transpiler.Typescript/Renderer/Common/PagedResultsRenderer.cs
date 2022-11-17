using System;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.Common;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Common
{
    public class PagedResultsRenderer : IPagedResultsRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public PagedResultsRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public string PagedResultsName()
            => _helper.NotImplementedHelper.GetNotImplementedCode($"PagedResultsName");

        public Func<FunctionOptions, string, bool, string> Results()
            => (options, parsed, isAssignement) => $"{parsed}.Results";

        public Func<FunctionOptions, string, bool, string> TotalResults()
            => (options, parsed, isAssignement) => $"{parsed}.TotalResults";
    }
}
