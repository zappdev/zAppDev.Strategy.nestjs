using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.StandardLib;
using CLMS.Lang.Model.Expressions;
using System;
using zAppDev.Strategy.Transpiler.Base.Models;
using CLMS.Lang.Model.Structs;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Standard
{
    public class StringRenderer : IStringRenderer
    {
        protected readonly ILibraryHelper _helper;
        protected readonly IFunctionTransformer _compiler;

        public StringRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> CharAt()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, $"[{@params}]");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> CharToString()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, $"({parsed})", $"toString({@params})");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Compare()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Concat()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Contains()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> EndsWith()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> FillWith()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Format()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public string GetCharInstantiationCode(TypeClass typeClass)
        {
            return GetStringInstantiationCode();
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> GetEmpty()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public string GetStringInstantiationCode()
        {
            return "\"\"";
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> HasValue()
            => (options, parsed, @params, fcall) => $"({parsed} != null)";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> IndexOf()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, $"indexOf(" + @params + ")");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> IsNullOrEmptyInstanceMethod()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> IsNullOrEmptyStaticMethod()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();
        
        public virtual Func<FunctionOptions, string, string, FunctionCall, string> IsNullOrWhiteSpace()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> IsPlurar()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();
        
        public virtual Func<FunctionOptions, string, string, FunctionCall, string> IsSingular()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();
        
        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Join()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();
        
        public virtual Func<FunctionOptions, string, string, FunctionCall, string> LastIndexOf()
            => null;

        public virtual Func<FunctionOptions, string, bool, string> Length()
            => (options, parsed, isAssignment) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "length");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Pluralize()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();
        
        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Replace()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> ReplaceFirst()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, $"replace({@params})");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> ReplaceWithRegex()
        {
            return (options, parsed, @params, fcall) =>
            {
                throw new NotImplementedException();
            };
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Singularize()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();
        
        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Split()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();


        public virtual Func<FunctionOptions, string, string, FunctionCall, string> SplitCamelCase()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> StartsWith()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, $"indexOf({@params}) === 0");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> SubString()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "substring(" + @params + ")");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> ToLower()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "toLowerCase()");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> toString()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "toString(" + @params + ")");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> ToTitleCase()
            => null;

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> ToUpper()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "toUpperCase()");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Trim()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "trim()");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> TrimEnd()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "replace(/\\s+$/,'')");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> TrimStart()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "replace(/^\\s+/,'')");
    }
}
