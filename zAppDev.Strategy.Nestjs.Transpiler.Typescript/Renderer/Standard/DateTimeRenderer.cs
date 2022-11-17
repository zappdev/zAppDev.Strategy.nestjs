using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.StandardLib;
using CLMS.Lang.Model.Expressions;
using System;
using zAppDev.Strategy.Transpiler.Base.Models;
using CLMS.Lang.Model.Structs;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Standard
{
    public class DateTimeRenderer : IDateTimeRenderer
    {
        protected readonly ILibraryHelper _helper;
        protected readonly IFunctionTransformer _compiler;
        public DateTimeRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Add()
            => (options, parsed, @params, fcall) => $"(moment({parsed}).add({@params})).toDate()";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> AddDays()
            => (options, parsed, @params, fcall) => $"(moment({parsed}).add({@params}, \"d\")).toDate()";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> AddHours()
            => (options, parsed, @params, fcall) => $"(moment({parsed}).add({@params}, \"h\")).toDate()";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> AddMinutes()
            => (options, parsed, @params, fcall) => $"(moment({parsed}).add({@params}, \"m\")).toDate()";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> AddMonths()
            => (options, parsed, @params, fcall) => $"(moment({parsed}).add({@params}, \"M\")).toDate()";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> AddSeconds()
            => (options, parsed, @params, fcall) => $"(moment({parsed}).add({@params}, \"s\")).toDate()";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> AddYears()
            => (options, parsed, @params, fcall) => $"(moment({parsed}).add({@params}, \"y\")).toDate()";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Compare()
            => (options, parsed, @params, fcall) => $"CLMS.Framework.DateTime.Compare({@params})";
        
        public virtual Func<FunctionOptions, string, string, FunctionCall, string> CompareTo()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Create()
            => (options, parsed, @params, fcall) => $"moment([{@params}]).toDate()";
        
        public virtual Func<FunctionOptions, string, bool, string> Date()
            => (options, parsed, isAssignment) => $"new Date({_compiler.NullSafeTransformer.ConcatMembers(options, $"new Date({parsed})", "setHours(0, 0, 0, 0)")})";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> DateTimeToString()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Day()
            => (options, parsed, @params, fcall) => $"moment({parsed}).date()";

        public virtual Func<FunctionOptions, string, bool, string> DayOfTheWeek()
            => (options, parsed, isAssignment) => $"moment({parsed}).day()";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> DaysInMonth()
        {
            return (options, parsed, @params, fcall) =>
            {
                @params = @params.Replace(" ", "").Replace(",", "-");
                return $"moment(\"{@params}\", \"YYYY-MM\").daysInMonth()";
            };
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> FromUnixTime()
            => (options, parsed, @params, fcall) => $"moment({@params}).toDate()";

        public string GetDateTimeInstantiationCode(TypeClass typeClass)
        {
            return "new Date()";
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> GetDiff()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> GetMaxValue()
            => (options, parsed, @params, fcall) => $"moment(8640000000000000).toDate()";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> GetMinSqlValue()
            => (options, parsed, @params, fcall) => null;

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> GetMinValue()
            => (options, parsed, @params, fcall) => $"moment(-8640000000000000).toDate()";
        
        public virtual Func<FunctionOptions, string, string, FunctionCall, string> HasValue()
            => (options, parsed, @params, fcall) => $"({parsed} != null)";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Hour()
            => (options, parsed, @params, fcall) => $"moment({parsed}).hours()";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Minute()
            => (options, parsed, @params, fcall) => $"moment({parsed}).minutes()";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Month()
            => (options, parsed, @params, fcall) => $"moment({parsed}).month()";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Now()
            => (options, parsed, @params, fcall) => "moment().toDate()";
        
        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Parse()
            => (options, parsed, @params, fcall) => $"moment({@params}).toDate()";
        
        public virtual Func<FunctionOptions, string, string, FunctionCall, string> ParseExact()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Second()
            => null;

        public string TimeSpanInstantiationCode()
        {
            throw new NotImplementedException();
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Today()
            => (options, parsed, @params, fcall) => "moment().startOf('day').toDate()";
        
        public virtual Func<FunctionOptions, string, string, FunctionCall, string> ToUnixTime()
            => (options, parsed, @params, fcall) => $"moment({parsed}).unix()";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> ToUTC()
            => (options, parsed, @params, fcall) => $"moment({parsed}).utc().toDate()";

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Year()
            => (options, parsed, @params, fcall) => $"moment({parsed}).year()";
    }
}
