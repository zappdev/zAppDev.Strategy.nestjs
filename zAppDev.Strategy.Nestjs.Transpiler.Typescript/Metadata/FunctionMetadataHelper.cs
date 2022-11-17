using CLMS.Lang.Model.Structs;
using CLMS.Lang.Model.Expressions;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Metadata;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using CLMS.AppDev.MetaModels;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Metadata
{
    public class FunctionMetadataHelper : IFunctionMetadataHelper
    {
        private readonly SolutionModel _engine;

        private readonly ILibraryHelper _libraryHelper;

        public IDomainModelFunctionMetadataHelper DomainModelFunctionMetadata { get; set; }

        public FunctionMetadataHelper(ILibraryHelper libraryHelper)
        {
            _engine = libraryHelper.Engine;
            _libraryHelper = libraryHelper;
        }

        public ClientSideExecutionCheckEvaluation CanFunctionBeExecutedOnClient(Function function, string uniqueName)
        {
            throw new NotImplementedException();
        }

        public Expression GetNextMember(Expression expression)
        {
            if (!(expression.ParentExpression is Member parent))
                return null;

            var currentMemberPosition = parent.Members.IndexOf(expression);
            if (currentMemberPosition > -1 &&
                parent.Members.Count > currentMemberPosition + 1)
            {
                return parent.Members[currentMemberPosition + 1];
            }

            return null;
        }

        public bool HasNextMember(Expression exp) => GetNextMember(exp) != null;

        public bool HasParentTypeOf<T>(Expression exp) => exp.ParentExpression is T;

    }
}
