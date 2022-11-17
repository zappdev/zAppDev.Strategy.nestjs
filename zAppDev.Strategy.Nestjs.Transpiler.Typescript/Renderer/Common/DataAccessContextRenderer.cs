using System;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.Common;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Common
{
    public class DataAccessContextRenderer : IDataAccessContextRenderer
    {
        private readonly ILibraryHelper _helper;
        private readonly IFunctionTransformer _compiler;

        public DataAccessContextRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public Func<FunctionOptions, string, bool, string> Column()
             => (options, parsed, isAssignement) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public string DataAccessContextFilterColumnName()
            => _helper.NotImplementedHelper.GetNotImplementedCode("CommonLib.DataAccessContextFilterColumn");

        public Func<FunctionOptions, string, bool, string> Filter()
            => (options, parsed, isAssignement) => $"{parsed}.Filter";

        public Func<FunctionOptions, string, bool, string> FilterColumns()
            => (options, parsed, isAssignement) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public Func<FunctionOptions, string, bool, string> PageIndex()
            => (options, parsed, isAssignement) => $"{parsed}.PageIndex";

        public Func<FunctionOptions, string, bool, string> PageSize()
            => (options, parsed, isAssignement) => $"{parsed}.PageSize";

        public Func<FunctionOptions, string, bool, string> SortByColumnName()
            => (options, parsed, isAssignement) => $"{parsed}.SortByColumnName";

        public Func<FunctionOptions, string, bool, string> SortByColumns()
            => (options, parsed, isAssignement) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);

        public Func<FunctionOptions, string, bool, string> Value()
             => (options, parsed, isAssignement) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed);
    }
}
