using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.Domain;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Structs;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Domain
{
    public class DomainModelRenderer : IDomainModelRenderer
    {
        protected readonly ILibraryHelper _helper;
        protected readonly IFunctionTransformer _compiler;

        public DomainModelRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _compiler = compiler;
            _helper = helper;
        }
        public string GetInstanceDomainLocalResourcesDefinitionCallExpression(string parsed, FunctionCall call, string datatype, string parameters)
        {
            throw new NotImplementedException();
        }

        public void SetLastPrimitiveIsNullable(TypeClass dataType)
        {
            
        }
    }
}
