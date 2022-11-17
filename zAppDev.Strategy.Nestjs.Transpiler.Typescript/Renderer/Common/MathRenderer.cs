using CLMS.Lang.Model.Expressions;
using System;
using System.Linq;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.Common;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Common
{
    public class MathRenderer : IMathRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public MathRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> Abs()
            => (options, parsed, @params, fcall) => $"Math.abs({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> Acos()
            => (options, parsed, @params, fcall) => $"Math.acos({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> Asin()
            => (options, parsed, @params, fcall) => $"Math.asin({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> Atan()
            => (options, parsed, @params, fcall) => $"Math.atan({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> Atan2()
            => (options, parsed, @params, fcall) => $"Math.atan2({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> Ceil()
            => (options, parsed, @params, fcall) => $"Math.ceil({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> Cos()
            => (options, parsed, @params, fcall) => $"Math.cos({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> Floor()
            => (options, parsed, @params, fcall) => $"Math.floor({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> Max()
            => (options, parsed, @params, fcall) => $"Math.max({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> Min()
            => (options, parsed, @params, fcall) => $"Math.min({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> Pi()
            => (options, parsed, @params, fcall) => "Math.PI";

        public Func<FunctionOptions, string, string, FunctionCall, string> Pow()
            => (options, parsed, @params, fcall) => $"Math.pow({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> Round()
        {
            return (options, parsed, @params, fcall) =>
            {
                if (Equals(fcall.Parameters.Last().DataType.Name, "CommonLib.MidpointRounding"))
                {
                    throw new ApplicationException("The Math.Round() with CommonLib.MidpointRounding parameter is not available for client side execution");
                }

                return $"Math.round10({@params})";
            };
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> Sin()
            => (options, parsed, @params, fcall) => $"Math.sin({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> Sqrt()
            => (options, parsed, @params, fcall) => $"Math.sqrt({@params})";

        public Func<FunctionOptions, string, string, FunctionCall, string> Tan()
            => (options, parsed, @params, fcall) => $"Math.tan({@params})";
    }
}
