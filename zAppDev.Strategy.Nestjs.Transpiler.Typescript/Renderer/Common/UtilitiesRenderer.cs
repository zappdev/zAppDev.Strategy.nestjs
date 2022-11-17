using CLMS.Lang.Model.Expressions;
using System;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.Common;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Models;
using CLMS.Lang.Model.Statement;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Common
{
    public class UtilitiesRenderer : IUtilitiesRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public UtilitiesRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Base64Decode()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> Base64DecodeAsByteArray()
            => null;

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Base64Encode()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ByteArrayToString()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ByteArrayToUnicode()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ByteArrayToUTF8()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> CreateThumbnail()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> CreateTimeSpan()
            => null;

        public string DateTimeFormatInistatiationCode()
            => null;

        public string DateTimeFormatName()
            => _helper.NotImplementedHelper.GetNotImplementedCode($"DateTimeFormatName");

        public Func<FunctionOptions, string, string, FunctionCall, string> DownloadData()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> DownloadFile()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> EncodeUrl()
            => null;

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> ExportControlToPdf()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> ExportExcelFile()
            => null;

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> ExportFormToPdf()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> GetCrontabDescription()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> GetCrontabNextExecutionTime()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> GetDataPath()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> GetExcelFileSheetNames()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> GetExcelFormat()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> GetExcelTableContents()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> GetMD5Hash()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> GetNextExecutionTime()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> GetServerPhysicalPath()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> GetSHA1Hash()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> GetSHA256Hash()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> GetUploadsPath()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> IsCronExpressionValid()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> IsPropertyDirty()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ResolveClientURL()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> RunExecutable()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SendEmail()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SendEmailAsync()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> Sleep()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> StringToByteArray()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ToDateTime()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ToDecimal()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ToGuid()
        {
            return (options, parsed, @params, fcall) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> ToInt()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ToLong()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> UnicodeToByteArray()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> UTF8ToByteArray()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ValidateXMLAgainstXSD()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> VirtualPathToAbsolute()
            => null;
    }
}
