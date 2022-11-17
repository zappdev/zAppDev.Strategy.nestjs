using CLMS.AppDev.MetaModels.Interface;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Renderer;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Structs;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.InterfacesLib
{
    public class InterfaceRenderer : IInterfaceRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public InterfaceRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _compiler = compiler;
            _helper = helper;
        }

        public string GetFullyQualifiedName(ClassContainer classContainer)
        {
            throw new System.NotImplementedException();
        }

        public string GetInstanceMember(TypeClass owner, string alreadyParsed, Identifier identifier, bool isAssignment)
        {
            return $"{alreadyParsed}.{identifier.IdName}";
        }

        public string GetInstanceMethod(FunctionCall call, FunctionOptions option, string parsed, string parameters)
        {
            return null;
        }

        public string GetInstantiationCode(TypeClass typeClass)
        {
            throw new System.NotImplementedException();
        }

        public string GetStaticMethod()
        {
            return null;
        }

        public bool IsStaticFunctionContained()
        {
            return false;
        }

        public string ParseClearCacheMethod(string api, string parameters, FunctionCall call)
        {
            throw new System.NotImplementedException();
        }

        public string ResolveDatabaseMethodCall(FunctionOptions option, string interfaceName, FunctionCall call, Interface model, string parameters)
        {
            throw new System.NotImplementedException();
        }

        public string ResolveInterfaceDllType(string interfaceName, Interface model)
        {
            throw new System.NotImplementedException();
        }

        public string ResolveInterfaceRestMethodCall(FunctionOptions option, string interfaceName, FunctionCall call, Interface model, string parameters)
        {
            throw new System.NotImplementedException();
        }

        public string ResolveInterfaceSoapMethodCall(FunctionOptions option, string interfaceName, FunctionCall call, Interface model, string parameters)
        {
            throw new System.NotImplementedException();
        }

        public string ResolveXsdMethodCall(string interfaceName, FunctionCall call, Interface model, string parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
