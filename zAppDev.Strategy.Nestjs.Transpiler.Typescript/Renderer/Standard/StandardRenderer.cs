using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.StandardLib;
using CLMS.Lang.Model.Expressions;
using System;
using zAppDev.Strategy.Transpiler.Base.Models;
using CLMS.Lang.Model.Structs;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Standard
{
    public class StandardRenderer : IStandardRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public StandardRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> ArrayContains()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, $".contains({@params})");

        public Func<FunctionOptions, string, string, FunctionCall, string> ArrayGet()
            => (options, parsed, @params, fcall) => $"{@parsed}[{@params}]";

        public Func<FunctionOptions, string, string, FunctionCall, string> ArrayIndexOf()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, $"indexOf({@params})");

        public Func<FunctionOptions, string, string, FunctionCall, string> ArraySet()
            => (options, parsed, @params, fcall) => $"{parsed}[{_compiler.ExpressionTransformer.Transform(options, fcall.Parameters[0])}] = {_compiler.ExpressionTransformer.Transform(options, fcall.Parameters[1])}";

        public Func<FunctionOptions, string, string, FunctionCall, string> ArrayToCollection()
            => (options, parsed, @params, fcall) => parsed;

        public string BoolName()
            => "boolean";

        public Func<FunctionOptions, string, string, FunctionCall, string> BoolParse()
            => (options, parsed, @params, fcall) => $"({parsed} == true)";

        public Func<FunctionOptions, string, string, FunctionCall, string> BoolToString()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, $"({parsed})", "toString()");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> BuisessExceptionCreate()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, bool, string> BusinessExceptionCustomData()
            => (options, parsed, isAssignment) => null;

        public Func<FunctionOptions, string, bool, string> BusinessExceptionMessage()
            => (options, parsed, isAssignment) => null;

        public string BusinessExceptionName()
            => "";

        public Func<FunctionOptions, string, bool, string> BusinessExceptionStackTrace()
            => (options, parsed, isAssignment) => null;

        public string ByteName()
            => "number";

        public Func<FunctionOptions, string, string, FunctionCall, string> ByteParse()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> ByteToString()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, $"numeral({parsed})", $"format({@params})");

        public string CharName()
            => "string";

        public string CollectionBaseName()
            => "";

        public virtual string CollectionName()
            => "";

        public string DataTimeName()
            => "Date";

        public string DecimalName()
            => "number";

        public string DictionaryName()
            => "Map";

        public string DoubleName()
            => "number";

        public Func<FunctionOptions, string, bool, string> ExceptionMessage()
        => (options, parsed, isAssignment) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "message");

        public string ExceptionName()
            => "";

        public Func<FunctionOptions, string, bool, string> ExceptionStackTrace()
            => (options, parsed, isAssignment) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "stack");

        public string FloatName()
            => "number";

        public string FuncName()
            => "";

        public string GetBoolInstantiationCode(TypeClass typeClass)
        {
            return "false";
        }

        public string GetPredicateInstantiationCode(TypeClass typeClass)
        {
            return _compiler.DataTypeTransformer.GetInstantiationCode(typeClass);
        }

        public string GuidName()
            => "string";

        public string IndexedCollectionName()
            => null;

        public Func<FunctionOptions, string, bool, string> InnerException()
            => (options, parsed, isAssignment) => null;

        public string IntName()
            => "number";

        public string LongName()
            => "number";

        public Func<FunctionOptions, string, string, FunctionCall, string> ObjectEquals()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> ObjectGetType()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "GetType()");

        public string ObjectName()
            => "object";

        public Func<FunctionOptions, string, string, FunctionCall, string> ObjectToString()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, $"toString({@params})");

        public Func<FunctionOptions, string, string, FunctionCall, string> PredicateAnd()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> PredicateCreate()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> PredicateOr()
            => null;


        public string StringName()
            => "string";

        public Func<FunctionOptions, string, bool, string> TimeSpanDays()
            => (options, parsed, isAssignment) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "days");

        public Func<FunctionOptions, string, bool, string> TimeSpanHours()
            => (options, parsed, isAssignment) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "hours");

        public Func<FunctionOptions, string, bool, string> TimeSpanMilliseconds()
            => (options, parsed, isAssignment) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "milliseconds");

        public Func<FunctionOptions, string, bool, string> TimeSpanMinutes()
            => (options, parsed, isAssignment) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "minutes");

        public string TimeSpanName()
            => "";

        public Func<FunctionOptions, string, string, FunctionCall, string> TimeSpanParse()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, bool, string> TimeSpanSeconds()
            => (options, parsed, isAssignment) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "seconds");

        public Func<FunctionOptions, string, bool, string> TimeSpanTotalDays()
            => (options, parsed, isAssignment) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "days");

        public Func<FunctionOptions, string, bool, string> TimeSpanTotalHours()
            => (options, parsed, isAssignment) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "hours");

        public Func<FunctionOptions, string, bool, string> TimeSpanTotalMilliseconds()
            => (options, parsed, isAssignment) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "milliseconds");

        public Func<FunctionOptions, string, bool, string> TimeSpanTotalMinutes()
            => (options, parsed, isAssignment) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "minutes");

        public Func<FunctionOptions, string, bool, string> TimeSpanTotalSeconds()
            => (options, parsed, isAssignment) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "seconds");

        public Func<FunctionOptions, string, string, FunctionCall, string> ValidationExceptionCreate()
            => (options, parsed, @params, fcall) => null;

        public Func<FunctionOptions, string, bool, string> ValidationExceptionCustomData()
            => (options, parsed, isAssignment) => null;

        public Func<FunctionOptions, string, bool, string> ValidationExceptionMessage()
            => (options, parsed, isAssignment) => null;

        public string ValidationExceptionName()
            => null;

        public Func<FunctionOptions, string, bool, string> ValidationExceptionStackTrace()
            => (options, parsed, isAssignment) => null;
    }
}
