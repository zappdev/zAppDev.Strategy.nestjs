using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Renderer.FileIoLib;
using CLMS.Lang.Model.Expressions;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.FileIoLib
{
    public class PathRenderer : IPathRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public PathRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public string PathName()
            => _helper.NotImplementedHelper.GetNotImplementedCode($"PathName");

        public Func<FunctionOptions, string, string, FunctionCall, string> PathCombine()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> PathGetTempPath()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> PathGetFileName()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> PathGetFileNameWithoutExtension()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> PathGetFullPath()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> PathGetDirectoryName()
            => null;
    }
}
