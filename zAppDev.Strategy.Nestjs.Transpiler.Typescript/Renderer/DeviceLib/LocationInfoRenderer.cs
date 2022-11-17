
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Renderer.DeviceLib;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.DeviceLib
{
    public class LocationInfoRenderer : ILocationInfoRender
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public LocationInfoRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _compiler = compiler;
            _helper = helper;
        }

        public Func<FunctionOptions, string, bool, string> Accuracy() => null;

        public Func<FunctionOptions, string, bool, string> Altitude() => null;

        public Func<FunctionOptions, string, bool, string> AltitudeAccuracy() => null;

        public string ClassName() => null;

        public Func<FunctionOptions, string, bool, string> Heading() => null;

        public Func<FunctionOptions, string, bool, string> Latitude() => null;

        public Func<FunctionOptions, string, bool, string> Longitude() => null;

        public Func<FunctionOptions, string, bool, string> Speed() => null;
    }
}
