using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Renderer.StandardLib;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Structs;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Standard
{
    public class DictionaryRenderer : IDictionaryRenderer
    {
        protected readonly ILibraryHelper _helper;
        protected readonly IFunctionTransformer _compiler;

        public DictionaryRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Add()
        {
            return (options, parsed, @params, fcall) =>
            {
                var parsedKey = _compiler.ExpressionTransformer.Transform(options, fcall.Parameters[0]);
                var parsedValue = _compiler.ExpressionTransformer.Transform(options, fcall.Parameters[1]);

                return $"{parsed}.set({parsedKey}, {parsedValue})";
            };
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> Clear()
            => (options, parsed, @params, fcall) => $"{parsed}.clear()";

        public Func<FunctionOptions, string, string, FunctionCall, string> First()
            => (options, parsed, @params, fcall) => null;

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Get()
            => (options, parsed, @params, fcall) => $"{parsed}.get({@params})";

        public string GetInstantiationCode(TypeClass typeClass)
        {
            return "new window['Map']()";
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> GetKeys()
            => (options, parsed, @params, fcall) => $"Array['from']({parsed}.keys())";

        public Func<FunctionOptions, string, string, FunctionCall, string> GetValues()
            => (options, parsed, @params, fcall) => $"Array['from']({parsed}.values())";

        public Func<FunctionOptions, string, string, FunctionCall, string> HasKey()
            => (options, parsed, @params, fcall) => $"{parsed}.has({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> OrdeByKeyDescending()
            => (options, parsed, @params, fcall) => $"new window['Map'](Array['from']({parsed}).sort((x, y) => x[0] < y[0]))";

        public Func<FunctionOptions, string, string, FunctionCall, string> OrdeByValue()
            => (options, parsed, @params, fcall) => $"new window['Map'](Array['from']({parsed}).sort((x, y) => x[1] > y[1]))";

        public Func<FunctionOptions, string, string, FunctionCall, string> Order()
        {
            return (options, parsed, @params, fcall) =>
            {
                return $"new window['Map'](Array['from']({parsed}).sort({@params}))";
            };
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> OrderByKey()
            => (options, parsed, @params, fcall) => $"new window['Map'](Array['from']({parsed}).sort((x, y) => x[0] > y[0]))";

        public Func<FunctionOptions, string, string, FunctionCall, string> OrderByValueDescending()
            => (options, parsed, @params, fcall) => $"new window['Map'](Array['from']({parsed}).sort((x, y) => x[1] < y[1]))";

        public Func<FunctionOptions, string, string, FunctionCall, string> Remove()
            => (options, parsed, @params, fcall) => $"{parsed}.delete({@params})";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Set()
        {
            return (options, parsed, @params, fcall) =>
            {
                var parsedKey = _compiler.ExpressionTransformer.Transform(options, fcall.Parameters[0]);
                var parsedValue = _compiler.ExpressionTransformer.Transform(options, fcall.Parameters[1]);

                return $"{parsed}.set({parsedKey}, {parsedValue})";
            };
        }
    }
}
