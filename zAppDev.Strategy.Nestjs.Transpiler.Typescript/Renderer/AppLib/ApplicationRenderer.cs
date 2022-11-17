using CLMS.Lang.Model.Expressions;
using System;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.AppLib;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.AppLib
{
    public class ApplicationRenderer : IApplicationRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;
        public ApplicationRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> ApplicationGetLastError()
        {
            return null;
        }

        public Func<FunctionOptions, string, bool, string> ApplicationMajorVersion()
        {
            return (options, parsed, isAssignment) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, bool, string> ApplicationMinorVersion()
        {
            return (options, parsed, isAssignment) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, bool, string> ApplicationName()
        {
            return (options, parsed, isAssignment) => _helper.NotImplementedHelper.GetNotImplementedCode("AppLib.Session");
        }

        public Func<FunctionOptions, string, bool, string> ApplicationPatchVersion()
        {
            return (options, parsed, isAssignment) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, bool, string> ApplicationSemanticVersion()
        {
            return (options, parsed, isAssignment) => throw new NotImplementedException();
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> GetConfigurationKey()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> GetTypes()
            => null;
    }
}
