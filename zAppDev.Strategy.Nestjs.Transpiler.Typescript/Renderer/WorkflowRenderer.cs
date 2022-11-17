using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Renderer;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Structs;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer
{
    public class WorkflowRenderer : IWorkflowRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public WorkflowRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _compiler = compiler;
            _helper = helper;
        }

        public string CancelByKey(string parameters)
            => throw new NotImplementedException();

        public string ContinueByKey(string parameters)
            => throw new NotImplementedException();

        public string GetAllPending(FunctionOptions options, FunctionCall call)
            => throw new NotImplementedException();

        public string GetAllPendingByStep(FunctionOptions options, FunctionCall call, string parameters)
            => throw new NotImplementedException();

        public string GetInstanceMember(TypeClass owner, Identifier identifier, string parsed, bool isAssignment)
        {
            throw new NotImplementedException(); ; 
        }

        public string ManagerCancelInstance(string parameters)
            => throw new NotImplementedException();

        public string ManagerContinueInstance(string parameters)
            => throw new NotImplementedException();

        public string ManagerExecuteSchedule(string parameters)
            => throw new NotImplementedException();

        public string ManagerExpireInstance(string parameters)
            => throw new NotImplementedException();
        public string Run(FunctionCall call, string parameters)
            => throw new NotImplementedException();
    }
}
