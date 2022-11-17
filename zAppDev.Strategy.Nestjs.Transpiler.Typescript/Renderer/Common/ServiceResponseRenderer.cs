using System;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.Common;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Common
{
    public class ServiceResponseRenderer : IServiceResponseRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public ServiceResponseRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, bool, string> Config()
            => (options, parsed, isAssignement) => $"{parsed}.config";

        public Func<FunctionOptions, string, bool, string> Data()
            => (options, parsed, isAssignement) => $"{parsed}.data";

        public Func<FunctionOptions, string, bool, string> Headers()
            => (options, parsed, isAssignement) => $"{parsed}.headers";

        public string ServiceResponseName()
            => "Axios.AxiosXHR<any>";

        public Func<FunctionOptions, string, bool, string> Status()
            => (options, parsed, isAssignement) => $"{parsed}.status";

        public Func<FunctionOptions, string, bool, string> StatusText()
            => (options, parsed, isAssignement) => $"{parsed}.statusText";
    }
}
