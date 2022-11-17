using CLMS.AppDev.MetaModels.WebForm;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Renderer;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Structs;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.FormModels
{
    public class FormModelsRenderer : IFormModelsRenderer
    {
        protected readonly ILibraryHelper _helper;
        protected readonly IFunctionTransformer _compiler;

        public FormModelsRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _compiler = compiler;
            _helper = helper;
        }

        public virtual string CloseForm(FunctionOptions options)
        {
            throw new NotImplementedException();
        }

        public string CommitAllFiles()
        {
            throw new NotImplementedException();
        }

        public string ExecuteJavascript(string parameters)
        {
            throw new NotImplementedException();
        }

        public virtual string ExportToPdf(FunctionCall call, FunctionOptions option, string formName, string actionName, string parameters)
        {
            throw new NotImplementedException();
        }

        public virtual string GetExecute(FunctionCall call, FunctionOptions option, string actionName, string formName, string parameters)
        {
            throw new NotImplementedException();
        }

        public virtual string GetLink(FunctionCall call, FunctionOptions option, string formName, string actionName)
        {
            throw new NotImplementedException();
        }

        public string IsActive(string actionName)
        {
            throw new NotImplementedException();
        }

        public string IsFormDirty()
        {
            throw new NotImplementedException();
        }

        public string IsInControllerAction(string parameters)
        {
            throw new NotImplementedException();
        }

        public string IsModal()
        {
            throw new NotImplementedException();
        }

        public virtual string SetDirtyState(string parameters)
        {
            throw new NotImplementedException();
        }

        public virtual string ShowMessage(string parameters)
        {
            throw new NotImplementedException();
        }

        protected bool HasPartial(WebFormView form, string partialForm)
        {
            throw new NotImplementedException();
        }

        public void InitFunctionContext(FunctionOptions options)
        {
            throw new NotImplementedException();
        }

        public virtual string ModelOrResponse(FunctionOptions options, string propertyName)
        {
            throw new NotImplementedException();
        }

        public virtual string LocalResourcesDefinition(FunctionOptions options, TypeClass owner, string propertyName)
        {
            throw new NotImplementedException();
        }

        public virtual string GlobalResourcesDefinition(FunctionOptions options, string propertyName)
        {
            throw new NotImplementedException();
        }

        public string DataValidationIsError(FunctionOptions options, string parsed)
        {
            throw new NotImplementedException();
        }

        public string DataValidationIsWarning(FunctionOptions options, string parsed)
        {
            throw new NotImplementedException();
        }

        public string DataValidationIsInfo(FunctionOptions options, string parsed)
        {
            throw new NotImplementedException();
        }

        public virtual string CurrentFormDataValidations(FunctionOptions options)
        {
            throw new NotImplementedException();
        }

        public string MasterFormDataValidations(FunctionOptions options)
        {
            throw new NotImplementedException();
        }

        public string DataValidationEntry(FunctionOptions options, string parsed, string propertyName)
        {
            throw new NotImplementedException();
        }

        public string TriggeredDataValidationEntry(FunctionOptions options, string parsed)
        {
            throw new NotImplementedException();
        }

        public virtual string SummaryDataValidations(FunctionOptions options, string parsed)
        {
            throw new NotImplementedException();
        }

        public string GetUploadedFilePath()
        {
            return null;
        }

        public string GenerateListExport(FunctionCall call, FunctionOptions option, bool forPdf = false)
        {
            throw new NotImplementedException();
        }

        public string SendFileToClient(FunctionCall call, FunctionOptions option)
        {
            throw new NotImplementedException();
        }

        public string Resources(TypeClass owner, string parsed)
        {
            throw new NotImplementedException();
        }

        public string Property(FunctionOptions options, TypeClass owner, string parsed, string propertyName, string postFix)
        {
            throw new NotImplementedException();
        }
    }
}
