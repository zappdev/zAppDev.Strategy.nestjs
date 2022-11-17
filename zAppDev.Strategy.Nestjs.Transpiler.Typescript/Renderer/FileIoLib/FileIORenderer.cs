using CLMS.Lang.Model.Expressions;
using System;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Core;
using CLMS.Lang.Model.Structs;
using zAppDev.Strategy.Transpiler.Base.Renderer.FileIoLib;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer
{
    public class FileIORenderer : IFileIORenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public FileIORenderer(ILibraryHelper helper,IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public string FileName()
            => _helper.NotImplementedHelper.GetNotImplementedCode($"FileName");

        public Func<FunctionOptions, string, string, FunctionCall, string> FileCopy()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> FileCreateNew()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> FileDelete()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> FileExists()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> FileExtractLinesFrom()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> FileMove()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> FileReadAllFrom()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> FileReadLinesFrom()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> FileWriteAllTo()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> FileDetailsLoad()
            => null;

        public string FileNotImplementedCode(string name)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode(name);
        }

        public string GetDefaultInstantiationCode(TypeClass typeClass)
        {
            return _compiler.DataTypeTransformer.GetInstantiationCode(typeClass);
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> FileAppendAllTo()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> FileReadAllBytesFrom()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> FileReadAllFromUsed()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> ReadAllBytesFromUsed()
            => null;
    }
}
