using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Renderer;
using CLMS.Lang.Model.Expressions;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.LibraryRenderer
{
    public class VerbalExpressionsRenderer : IVerbalExpressionsRenderer
    {
        private readonly ILibraryHelper _helper;

        private readonly IFunctionTransformer _compiler;

        public VerbalExpressionsRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _compiler = compiler;
            _helper = helper;
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> StartOfLine()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> EndOfLine()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> Then()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> Maybe()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> AnythingBut()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> IsMatch()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> Anything()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> Something()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> Or()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> SomethingBut()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> LineBreak()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> Tab()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> Word()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> Replace()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();


        public Func<FunctionOptions, string, string, FunctionCall, string> IsEmail()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> IsUrl()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public string Name()
        {
            return "VerEx";
        }

        public string InitCode()
        {
            throw new NotImplementedException();
        }

        public string GetMatch(string parsed, string input)
        {
            throw new NotImplementedException();
        }

        public string GetMatch(string parsed, string input, string defaultValue)
        {
            throw new NotImplementedException();
        }

        public string GetMatches(string parsed, string input)
        {
            throw new NotImplementedException();
        }

        public string GetMatches(string parsed, string input, string defaultValue)
        {
            throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> StringMatchesPattern()
           => (options, parsed, @params, fcall) =>
           {
               throw new NotImplementedException();
           };
    }
}
