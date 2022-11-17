using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.AppLib;
using CLMS.Lang.Model.Expressions;
using System;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.AppLib
{
    public class SecurityRenderer : ISecurityRenderer
    {
        protected readonly ILibraryHelper _helper;
        protected readonly IFunctionTransformer _compiler;
        public SecurityRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> AESDecrypt()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> AESEncrypt()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> FacebookAccountIsLinked()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> GoogleAccountIsLinked()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> InvalidateUserSecurityData()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> RegisterUser()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ResetPasswordOfUserAsAdmin()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SecuityCurrentUserHasPermission()
        {
            return (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode("AppLib.SecuityCurrentUserHasPermission");
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> SecurityChangePasswordOfUser()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SecurityConfirmEmail()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SecurityGenerateEmailConfirmationToken()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SecurityGeneratePasswordResetToken()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SecurityGetAdminCanSetPasswordSetting()
        {
            return (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode("AppLib.SecurityGetAdminCanSetPasswordSetting");
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> SecurityGetAllConnectedUsers()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SecurityGetToken()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SecurityIsAuthenticatedByOS()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SecurityPasswordIsValid()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SecurityRegisterFormsOrOSUser()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SecurityRegisterOSUser()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SecurityResetPasswordOfUser()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SecuritySignInOnlyWithUserName()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SecuritySignInUser()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SecuritySignOutUserFromAllSessions()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SecurityValidateUser()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SignOutUser()
            => null;
    }
}
