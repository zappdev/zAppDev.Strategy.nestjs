using System;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.Common;
using CLMS.Lang.Model.Expressions;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Common
{
    public class EmailRenderer : IEmailRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public EmailRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, bool, string> Attachments() => null;

        public Func<FunctionOptions, string, bool, string> BCC()
            => (options, parsed, isAssignement) => $"{parsed}.BCC";

        public Func<FunctionOptions, string, bool, string> Body()
            => (options, parsed, isAssignement) => $"{parsed}.Body";

        public Func<FunctionOptions, string, bool, string> CC()
            => (options, parsed, isAssignement) => $"{parsed}.CC";

        public Func<FunctionOptions, string, string, FunctionCall, string> EmailAttachmentCreateFromBytes()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> EmailAttachmentCreateFromFile()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> EmailAttachmentCreateFromString()
            => null;

        public Func<FunctionOptions, string, bool, string> EmailAttachmentName()
            => (options, parsed, isAssignement) => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> EmailAttachmentSaveAttachmentToFile()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> EmailMessageGet()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> EmailMessageGetAll()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> EmailMessageGetAttachment()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> EmailMessageGetCount()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> EmailMessageGetIDs()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> EmailMessageHasUnreadEmails()
            => null;

        public string EmailMessageInstatiationCode()
            => _helper.NotImplementedHelper.GetNotImplementedCode($"EmailMessageInstatiationCode");

        public Func<FunctionOptions, string, string, FunctionCall, string> EmailMessageMarkAsRead()
            => null;

        public string EmailMessageName()
            => _helper.NotImplementedHelper.GetNotImplementedCode($"EmailMessageName");

        public Func<FunctionOptions, string, bool, string> From()
            => (options, parsed, isAssignement) => $"{parsed}.From";

        public Func<FunctionOptions, string, bool, string> Id()
            => (options, parsed, isAssignement) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public Func<FunctionOptions, string, bool, string> IsBodyHtml()
            => (options, parsed, isAssignement) => $"{parsed}.IsBodyHtml";

        public Func<FunctionOptions, string, bool, string> Subject()
            => (options, parsed, isAssignement) => $"{parsed}.Subject";

        public Func<FunctionOptions, string, bool, string> To()
            => (options, parsed, isAssignement) => $"{parsed}.To";
    }
}
