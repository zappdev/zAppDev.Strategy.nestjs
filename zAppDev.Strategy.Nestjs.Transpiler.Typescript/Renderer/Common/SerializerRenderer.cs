using CLMS.Lang.Model.Expressions;
using System;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.Common;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Models;
using CLMS.Lang.Model.Structs;
using CLMS.Lang.Model.Statement;
using CLMS.AppDev.MetaModels.WebForm;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Common
{
    public class SerializerRenderer : ISerializerRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public SerializerRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> EnumToString()
         => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> FromJson()
            => (options, parsed, @params, fcall) => $"{parsed}.FromJson({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> FromXml()
            => (options, parsed, @params, fcall) => $"{parsed}.FromXml({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> ParseEnum()
            => (options, parsed, @params, fcall) => $"{parsed}.ParseEnum({@params})";

        public string SerializerInstatiationCode(TypeClass typeClass)
            => _helper.NotImplementedHelper.GetNotImplementedCode($"SerializerInstatiationCode");

        public string SerializerName()
            => _helper.NotImplementedHelper.GetNotImplementedCode($"SerializerName");

        public Func<FunctionOptions, string, string, FunctionCall, string> ToJson()
            => (options, parsed, @params, fcall) => $"{parsed}.ToJson({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> ToXml()
            => (options, parsed, @params, fcall) => $"{parsed}.ToXml({@params})";
    }
}
