using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.FileIoLib;
using CLMS.Lang.Model.Expressions;
using System;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.FileIoLib
{
    public class FileDetailsRenderer : IFileDetailsRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public FileDetailsRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> FileDetailsLoad()
            => null;

        public string FileDetailsClassFullName()
            => _helper.NotImplementedHelper.GetNotImplementedCode($"FileDetailsClassFullName");

        public Func<FunctionOptions, string, bool, string> Name()
            => (options, parsed, isAssignment) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public Func<FunctionOptions, string, bool, string> DirectoryName()
            => (options, parsed, isAssignment) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public Func<FunctionOptions, string, bool, string> Extension()
            => (options, parsed, isAssignment) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public Func<FunctionOptions, string, bool, string> FullPath()
            => (options, parsed, isAssignment) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public Func<FunctionOptions, string, bool, string> IsReadOnly()
            => (options, parsed, isAssignment) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public Func<FunctionOptions, string, bool, string> Length()
            => (options, parsed, isAssignment) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public string FileDetailsInstatiationCode(string name)
        {
            return _helper.NotImplementedHelper.GetNotImplementedCode(name);
        }
    }
}
