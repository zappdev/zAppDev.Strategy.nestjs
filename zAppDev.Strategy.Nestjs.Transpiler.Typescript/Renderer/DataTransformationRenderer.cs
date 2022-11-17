using CLMS.Lang.Model.Expressions;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer;
using zAppDev.Strategy.Transpiler.Base.Core;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer
{
    public class DataTransformationRenderer : IDataTransformationRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public DataTransformationRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }
        public string GetStaticMethod(FunctionCall call, string parsed, string parameters)
        {
            throw new NotImplementedException();
        }
    }
}
