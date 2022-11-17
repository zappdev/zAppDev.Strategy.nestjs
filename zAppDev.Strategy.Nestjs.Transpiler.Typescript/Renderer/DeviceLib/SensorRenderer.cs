
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Renderer.DeviceLib;
using CLMS.Lang.Model.Expressions;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.DeviceLib
{
    public class SensorRenderer : ISensorRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public SensorRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _compiler = compiler;
            _helper = helper;
        }

        public string ClassName()
        {
            return null;
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> GetLocationInfo()
        {
            return null;
        }
    }
}
