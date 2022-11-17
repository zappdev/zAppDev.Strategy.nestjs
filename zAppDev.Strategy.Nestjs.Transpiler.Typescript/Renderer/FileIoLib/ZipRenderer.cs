using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Renderer.FileIoLib;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Structs;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.FileIoLib
{
    public class ZipRenderer : IZipRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public ZipRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public string ZipFileName()
            => _helper.NotImplementedHelper.GetNotImplementedCode($"PathName");

        public Func<FunctionOptions, string, string, FunctionCall, string> ZipAddFile()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ZipExtractAll()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ZipExtractAllAndOverwrite()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ZipRead()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ZipSave()
            => null;

        public string ZipFileInstatiationCode(TypeClass typeClass)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode(typeClass.Name);
        }
    }
}
