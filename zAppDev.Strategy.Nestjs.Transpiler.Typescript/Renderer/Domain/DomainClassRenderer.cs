using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Renderer.Domain;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Structs;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Domain
{
    public class DomainClassRenderer : IDomainClassRenderer
    {
        protected readonly ILibraryHelper _helper;
        protected readonly IFunctionTransformer _compiler;

        public DomainClassRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _compiler = compiler;
            _helper = helper;
        }

        public virtual string Create(FunctionOptions option, FunctionCall call, string parsed, string parameters, bool isStatic = false)
        {
            return $"new {_compiler.DataTypeTransformer.GetDataTypeName(call.Function.GetParent() as ClassContainer)}({parameters})";
        }

        public virtual string DeleteAll(FunctionOptions option, FunctionCall call, string parsed, string parameters)
        {
            throw new NotImplementedException();
        }

        public virtual string Find(FunctionOptions option, FunctionCall call, string parsed, string parameters, bool isStatic)
        {
            return $"{parsed}.{call.FName}({parameters})";
        }

        public virtual string First(FunctionOptions option, FunctionCall call, string parsed, string parameters, bool isStatic)
        {
            return $"{parsed}.{call.FName}({parameters})";
        }

        public virtual string GetAll(FunctionOptions option, FunctionCall call, string parsed, string parameters, bool isStatic)
        {
            return $"(await this.repository.getAll(Domain.{call.Function.GetParent().Name}, {parameters}))";
        }

        public virtual string GetByKey(FunctionOptions option, FunctionCall call, string parsed, string parameters, bool v)
        {
            var classType = call.Function.GetParent() as TypeClass;
            return $"(await this.repository.getByKey(Domain.{classType.Name}, '{classType.Key.Name}', {parameters}))";
        }

        public virtual string GetInstanceMember(FunctionOptions option, TypeClass owner, Identifier identifier, string parsed, bool isAssignment)
        {
            return $"{parsed}.{identifier.IdName}";
        }

        public virtual string GetInstanceMethod(FunctionOptions option, TypeClass classType, FunctionCall call, string parsed, string parameters)
        {
            return call.FName switch
            {
                "Save" => $"await this.repository.save(Domain.{classType.Name}, {parsed})",
                "Delete" => $"await this.repository.delete(Domain.{classType.Name}, {parsed})",
                _ => $"{parsed}.{call.FName}({parameters})"
            };
        }

        public virtual string GetStaticMethod(FunctionOptions option, TypeClass classType, FunctionCall call, string parsed, string parameters)
        {
            var ns = _compiler.DataTypeTransformer.GetTypeNameFromDomainClass(classType);
            return ns + classType.Name + (ns.EndsWith(".BO.") ? "Extensions" : "") + "." + call.FName + '(' + parameters + ')';
        }

        public virtual string IsNew(FunctionOptions option, FunctionCall call, string parsed, string parameters)
        {
            var dtName = call.Function.GetParent().Name;
            return $"Domain.{dtName}.{call.FName}({parsed})";
        }
     
        public string GetInstanceInsertCallExpression(string parsed, FunctionCall call, string datatype, string parameters)
        {
            return null;
        }

        public string GetInstanceRefreshCallExpression(string parsed, FunctionCall call, string datatype, string parameters)
        {
            throw new NotImplementedException();
        }

        public string GetInstanceCopyCallExpression(string parsed, FunctionCall call, string datatype, string parameters)
        {
            throw new NotImplementedException();
        }

        public bool IsStaticFunctionContained(FunctionCall call)
        {
            if(call.Function.Type == FunctionTypes.SystemMethod && call.FName != "Create")
            {
                return false;
            }
            return true;
        }

        public bool IsInstanceFunctionContained(FunctionCall call)
        {
            if (call.Function.Type == FunctionTypes.SystemMethod && call.FName != "IsNew")
            {
                return false;
            }
            return true;
        }
    }
}
