using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Renderer.StandardLib;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Structs;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Standard
{
    public class NumberRenderer : INumberRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public NumberRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> DecimalGetRandom()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> DecimalParse()
            => (options, parsed, @params, fcall) => $"parseFloat({@params})";
        
        public Func<FunctionOptions, string, string, FunctionCall, string> DecimalToString()
            => (options, parsed, @params, fcall) => parsed;

        public Func<FunctionOptions, string, string, FunctionCall, string> DoubleParse()
            => (options, parsed, @params, fcall) => $"parseFloat({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> DoubleToString()
            => (options, parsed, @params, fcall) => parsed;

        public Func<FunctionOptions, string, string, FunctionCall, string> FloatParse()
            => (options, parsed, @params, fcall) => $"parseFloat({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> FloatToString()
            => (options, parsed, @params, fcall) => parsed;

        public string GetInstantiationCode(TypeClass typeClass)
        {
            return "null";
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> IntGetRandom()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> IntParse()
            => (options, parsed, @params, fcall) => $"parseInt({@params})";
        

        public Func<FunctionOptions, string, string, FunctionCall, string> IntToString()
            => (options, parsed, @params, fcall) => @params;

        public Func<FunctionOptions, string, string, FunctionCall, string> LongParse()
            => (options, parsed, @params, fcall) => $"parseFloat({@params})";


        public Func<FunctionOptions, string, string, FunctionCall, string> LongToString()
            => (options, parsed, @params, fcall) => parsed;
    }
}
