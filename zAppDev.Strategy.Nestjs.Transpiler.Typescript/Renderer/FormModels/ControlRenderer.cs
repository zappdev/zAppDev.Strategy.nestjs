using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Renderer;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Structs;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.FormModels
{
    public class ControlRenderer : IControlRenderer
    {
        protected readonly ILibraryHelper _helper;
        protected readonly IFunctionTransformer _compiler;

        public ControlRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _compiler = compiler;
            _helper = helper;
        }

        public string CalendarControlRefresh()
        {
            throw new NotImplementedException();
        }

        public string CalendarControlSetLast(FunctionOptions option, string propertyName)
        {
            throw new NotImplementedException();
        }

        public string ChartControlRefresh()
        {
            throw new NotImplementedException();
        }

        public string ChartControlSelectedDataSetIndex()
        {
            throw new NotImplementedException();
        }

        public string ChartControlSetLast(FunctionOptions option, string propertyName)
        {
            throw new NotImplementedException();
        }

        public string ContextHide()
        {
            throw new NotImplementedException();
        }

        public string ContextShow()
        {
            throw new NotImplementedException();
        }

        public string DropdownControlRefresh()
        {
            throw new NotImplementedException();
        }

        public string DropdownControlSetLast(FunctionOptions option, string propertyName)
        {
            throw new NotImplementedException();
        }

        public string FileUploadControlRefresh()
        {
            throw new NotImplementedException();
        }

        public string FileUploadControlSetLast(FunctionOptions option, string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GridControlSetLast(FunctionOptions option, string propertyName)
        {
            throw new NotImplementedException();
        }

        public string ListControlClearSelectedItems()
        {
            throw new NotImplementedException();
        }

        public string ListControlCurrentItem()
        {
            throw new NotImplementedException();
        }

        public string ListControlItemsCount(FunctionOptions options)
        {
            throw new NotImplementedException();
        }

        public string ListControlRefresh()
        {
            throw new NotImplementedException();
        }

        public string ListControlSetLast(FunctionOptions option, string propertyName)
        {
            throw new NotImplementedException();
        }

        public string ListControlUpdateSize()
        {
            throw new NotImplementedException();
        }

        public string MapControl(FunctionCall call, string parameters)
        {
            throw new NotImplementedException();
        }

        public string MapControlSetLast(FunctionOptions option, string propertyName)
        {
            throw new NotImplementedException();
        }

        public string MenuSetLast(FunctionOptions option, string propertyName)
        {
            throw new NotImplementedException();
        }

        public string ModalHide()
        {
            throw new NotImplementedException();
        }

        public string ModalSetLast(FunctionOptions option, string propertyName)
        {
            throw new NotImplementedException();
        }

        public string ModalShow()
        {
            throw new NotImplementedException();
        }

        public string PageGridControl(FunctionCall call, string parameters)
        {
            throw new NotImplementedException();
        }

        public string SelectedItem(FunctionOptions option)
        {
            throw new NotImplementedException();
        }

        public string SelectedItems(FunctionOptions option)
        {
            throw new NotImplementedException();
        }

        public string TotalItems(TypeClass owner)
        {
            throw new NotImplementedException();
        }
    }
}
