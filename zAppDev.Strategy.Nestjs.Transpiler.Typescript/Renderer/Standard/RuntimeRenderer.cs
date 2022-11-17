using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.StandardLib;
using CLMS.Lang.Model.Expressions;
using System;
using zAppDev.Strategy.Transpiler.Base.Models;
using CLMS.Lang.Model.Structs;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Standard
{
    public class RuntimeRenderer : IRuntimeRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public RuntimeRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public string GetRuntimeInstantiationCode(TypeClass typeClass)
        {
            return _compiler.DataTypeTransformer.GetInstantiationCode(typeClass);
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> RuntimePropertyGetRuntimeType()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> RuntimePropertyGetValue()
            => null;

        public Func<FunctionOptions, string, bool, string> RuntimePropertyIsCollection()
            => (options, parsed, isAssignment) => throw new NotImplementedException();

        public Func<FunctionOptions, string, bool, string> RuntimePropertyIsPrimitive()
            => (options, parsed, isAssignment) => throw new NotImplementedException();

        public string RuntimePropertyName()
            => "";

        public Func<FunctionOptions, string, bool, string> RuntimePropertyNameInit()
            => (options, parsed, isAssignment) => $"{parsed}.Name";

        public Func<FunctionOptions, string, string, FunctionCall, string> RuntimePropertySetValue()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> RuntimeTypeContainsGenericParameters()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> RuntimeTypeCreateInstance()
            => (options, parsed, @params, fcall) => throw new NotImplementedException();

        public Func<FunctionOptions, string, bool, string> RuntimeTypeFullName()
            => (options, parsed, isAssignment) => _helper.NotImplementedHelper.GetNotImplementedCode("StdLib.RuntimeType.FullName");

        public Func<FunctionOptions, string, string, FunctionCall, string> RuntimeTypeGetGenericTypeArguments()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> RuntimeTypeGetProperties()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> RuntimeTypeGetProperty()
            => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> RuntimeTypeGetTypeOf()
            => (options, parsed, @params, fcall) => $"{@params}.GetType()";

        public Func<FunctionOptions, string, bool, string> RuntimeTypeIsCollection()
            => (options, parsed, isAssignment) => throw new NotImplementedException();

        public Func<FunctionOptions, string, bool, string> RuntimeTypeIsPrimitive()
            => (options, parsed, isAssignment) => throw new NotImplementedException();

        public Func<FunctionOptions, string, string, FunctionCall, string> RuntimeTypeIsSystemType()
            => null;

        public Func<FunctionOptions, string, bool, string> RuntimeTypeName()
            => (options, parsed, isAssignment) => _helper.NotImplementedHelper.GetNotImplementedCode("StdLib.RuntimeType.Name");

        public string RyntimeTypeName()
            => "";
    }
}
