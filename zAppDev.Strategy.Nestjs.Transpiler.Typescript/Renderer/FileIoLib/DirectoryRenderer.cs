using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Renderer.FileIoLib;
using CLMS.Lang.Model.Expressions;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.FileIoLib
{
    public class DirectoryRenderer : IDirectoryRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public DirectoryRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public string DirectoryName()
            => _helper.NotImplementedHelper.GetNotImplementedCode($"DirectoryName");

        public Func<FunctionOptions, string, string, FunctionCall, string> DirectoryCreate()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> DirectoryDelete()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> DirectoryExists()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> DirectoryGetDirectories()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> DirectoryGetFiles()
            => null;

    }
}
