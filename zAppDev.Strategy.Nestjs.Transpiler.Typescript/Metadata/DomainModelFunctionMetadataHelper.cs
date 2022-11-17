using zAppDev.Strategy.Transpiler.Base.Metadata;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Modules;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Structs;
using System.Collections.Generic;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Metadata
{
    public class DomainModelFunctionMetadataHelper : IDomainModelFunctionMetadataHelper
    {
        private readonly IFunctionMetadataHelper _functionMetadata;

        public DomainModelFunctionMetadataHelper(IFunctionMetadataHelper functionMetadata)
        {
            _functionMetadata = functionMetadata;
        }

        private static readonly HashSet<string> AllowedSystemMethods =
            new HashSet<string> { "IsNew", "Create" };

        private static readonly HashSet<string> OnlyBackendType =
            new HashSet<string> { "Domain_LocalResourcesDefinition" };

        private static readonly HashSet<string> MethodReferCurrentUser =
            new HashSet<string> {
                "Domain.ApplicationUser.IsInRole",
                "Domain.ApplicationUser.HasPermission",
            };

        protected bool SystemicFunctionCanBeGeneratedClientSide(Function func, FunctionCall fcall)
        {
            var parent = func.GetParent() as TypeClass;

            if ((!parent?.IsSystemic).Value) return true;

            // allow current user IsInRole and HasPermission calls
            if ((fcall != null) && MethodReferCurrentUser.Contains(func.FullName))
            {
                return DomainModelLib.UserIsInRoleCallRefersToCurrentUser(fcall);
            }

            return false;
        }

        public ClientSideExecutionCheckEvaluation CanTypeBeExecutedOnClient(TypeClass typeClass)
        {
            if (OnlyBackendType.Contains(typeClass.Name))
            {
                return ClientSideExecutionCheckEvaluation.GetNegativeResult(ClientSideExecutionCheckInfo.FunctionNeedsBackEnd);
            }
            return ClientSideExecutionCheckEvaluation.PositiveResult;
        }

        public ClientSideExecutionCheckEvaluation CanBeExecutedOnClient(Function func, FunctionCall fcall = null)
        {
            if (OnlyBackendType.Contains(func.GetParent().Name))
            {
                return ClientSideExecutionCheckEvaluation.GetNegativeResult(ClientSideExecutionCheckInfo.FunctionNeedsBackEnd);
            }

            if (fcall != null && func.Type == FunctionTypes.SystemMethod)
            {
                return AllowedSystemMethods.Contains(func.Name)
                    ? ClientSideExecutionCheckEvaluation.PositiveResult
                    : ClientSideExecutionCheckEvaluation.GetNegativeResult(ClientSideExecutionCheckInfo.FunctionNeedsBackEnd);
            }

            if (func.Type != FunctionTypes.Method)
            {
                return ClientSideExecutionCheckEvaluation.GetNegativeResult(ClientSideExecutionCheckInfo.FunctionNeedsBackEnd);
            }

            var parent = func.GetParent() as TypeClass;

            return ((!parent?.IsSystemic).Value || SystemicFunctionCanBeGeneratedClientSide(func, fcall))
                        && _functionMetadata.CanFunctionBeExecutedOnClient(func, "").CanBeExecuted
                ? ClientSideExecutionCheckEvaluation.PositiveResult
                : ClientSideExecutionCheckEvaluation.GetNegativeResult(ClientSideExecutionCheckInfo.FunctionNeedsBackEnd);
        }

    }
}
