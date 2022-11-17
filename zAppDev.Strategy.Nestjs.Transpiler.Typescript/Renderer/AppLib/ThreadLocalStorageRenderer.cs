﻿using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Renderer.AppLib;
using CLMS.Lang.Model.Expressions;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.AppLib
{
    public class ThreadLocalStorageRenderer : IThreadLocalStorageRenderer
    {
        protected readonly ILibraryHelper _helper;
        protected readonly IFunctionTransformer _compiler;

        public ThreadLocalStorageRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _compiler = compiler;
            _helper = helper;
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Get()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed, @params);

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Remove()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed, @params);

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Set()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed, @params);
    }
}
