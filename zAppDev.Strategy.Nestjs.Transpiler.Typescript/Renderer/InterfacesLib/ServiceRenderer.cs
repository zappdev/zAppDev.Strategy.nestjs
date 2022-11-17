using CLMS.Lang.Model.Expressions;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer;
using zAppDev.Strategy.Transpiler.Base.Core;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.InterfacesLib
{
    public class ServiceRenderer : IServiceRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public ServiceRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _compiler = compiler;
            _helper = helper;
        }

        public string EmptyFullyQualifiedName()
        {
            return "";
        }

        public string GetStaticMethod(FunctionCall call, string parsed, string parameters)
        {
            return $"(await {GetServiceName(call, _helper)}({parameters})).data";
        }

        public bool IsStaticFunctionContained(FunctionCall call)
        {
            return true;
        }

        public string NullFullyQualifiedName()
        {
            return null;
        }

        private static string GetServiceName(FunctionCall call, ILibraryHelper _helper)
        {
            throw new NotImplementedException();
        }

        public string SendFile(string parameters)
        {
            throw new NotImplementedException();
        }

        public string RollbackTransaction(FunctionCall call)
        {
            throw new NotImplementedException();
        }
    }
}
