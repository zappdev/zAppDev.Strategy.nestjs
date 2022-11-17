using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Renderer.StandardLib;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Structs;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Standard
{
    public class GuidRenderer : IGuidRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public GuidRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> CreateNew()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();
        
        public Func<FunctionOptions, string, string, FunctionCall, string> GetEmppty()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public string GetInstantiationCode(TypeClass typeClass)
        {
            return "";
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> GuidToString()
            => (options, parsed, @params, fcall) => $"{parsed}.toString({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> IsEmpty()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> IsNullOrEmpty()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> Parse()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }
    }
}
