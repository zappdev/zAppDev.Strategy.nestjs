using zAppDev.Strategy.Transpiler.Base.Common;
using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Factory;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Metadata;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Modules;
using zAppDev.Strategy.Transpiler.Base.Renderer.Domain;
using zAppDev.Strategy.Transpiler.Base.Renderer.StandardLib;
using zAppDev.Strategy.Transpiler.Base.Renderer;
using zAppDev.Strategy.Nestjs.Transpiler.Typescript.Core;
using zAppDev.Strategy.Nestjs.Transpiler.Typescript.Metadata;
using zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Domain;
using zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Standard;
using zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer;
using System.Collections.Generic;
using zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.FormModels;
using zAppDev.Strategy.Transpiler.Base.Renderer.AppLib;
using zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.AppLib;
using zAppDev.Strategy.Nestjs.Transpiler.Typescript.LibraryRenderer;
using zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.InterfacesLib;
using zAppDev.Strategy.Transpiler.Base.Renderer.Common;
using zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Common;
using zAppDev.Strategy.Transpiler.Base.Renderer.DeviceLib;
using zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.DeviceLib;
using CLMS.AppDev.MetaModels;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Factory
{
    public class TypescriptTranspilerFactory : ITranspilerFactory
    {
        public virtual IFunctionTransformer BuildCompiler(SolutionModel engine,
                                                          CompilerOptions options)
        {
            var compiler = new FunctionTransformer();

            var libraryHelper = BuildLibraryHelper(engine, compiler);
            compiler.LibraryHelper = libraryHelper;

            var dataTypeTransformer = BuildDataTypeTransformer(engine, libraryHelper, options);
            compiler.DataTypeTransformer = dataTypeTransformer;

            var nullSafeTransformer = BuildNullSafeTransformer(dataTypeTransformer);

            var expressionTransformer =
                BuildExpressionTransformer(engine, libraryHelper, dataTypeTransformer, compiler, nullSafeTransformer, options);
            compiler.ExpressionTransformer = expressionTransformer;

            var statementTransformer = BuildStatementTransformer(engine, libraryHelper, expressionTransformer, compiler, options);
            compiler.StatementTransformer = statementTransformer;

            var metadata = new FunctionMetadataHelper(libraryHelper);
            metadata.DomainModelFunctionMetadata =
                new DomainModelFunctionMetadataHelper(metadata);

            compiler.MetadataService = BuildMetadataService(engine, libraryHelper);
            compiler.NullSafeTransformer = nullSafeTransformer;

            return compiler;
        }

        public virtual ILibraryHelper BuildLibraryHelper(SolutionModel engine, IFunctionTransformer transpiler)
        {
            RendererFactory rendererFactory = BuildRenderFactory();

            // Per engine
            var libraryHelper = new LibraryHelper
            {
                Engine = engine,
                NotImplementedHelper = new TypescriptNotImplementedHelper(),
                RendererFactory = rendererFactory
            };

            libraryHelper.Modules = new List<Module>
            {
                new StdLib(libraryHelper, transpiler),
                new DebugLib(libraryHelper, transpiler),
                new DomainModelLib(libraryHelper, transpiler),
                new FormModelsLib(libraryHelper, transpiler),
                new AppLib(libraryHelper, transpiler),
                new RegExpLibModule(libraryHelper, transpiler),
                new InterfacesLib(libraryHelper, transpiler),
                new ServiceLib(libraryHelper, transpiler),
                new CommonLib(libraryHelper, transpiler),
                new DeviceLib(libraryHelper, transpiler),
                new WebLib(libraryHelper, transpiler),
            };
            return libraryHelper;
        }

        public virtual RendererFactory BuildRenderFactory()
        {
            var rendererFactory = new RendererFactory();

            // For StdLib
            rendererFactory.AddRenderer<IStandardRenderer, StandardRenderer>();
            rendererFactory.AddRenderer<IStringRenderer, StringRenderer>();
            rendererFactory.AddRenderer<INumberRenderer, NumberRenderer>();
            rendererFactory.AddRenderer<IGuidRenderer, GuidRenderer>();
            rendererFactory.AddRenderer<IDateTimeRenderer, DateTimeRenderer>();
            rendererFactory.AddRenderer<IDictionaryRenderer, DictionaryRenderer>();
            rendererFactory.AddRenderer<ICollectionRenderer, CollectionRenderer>();
            rendererFactory.AddRenderer<IRuntimeRenderer, RuntimeRenderer>();

            // For DeviceLib
            rendererFactory.AddRenderer<ISensorRenderer, SensorRenderer>();
            rendererFactory.AddRenderer<ILocationInfoRender, LocationInfoRenderer>();

            // For DebugLib
            rendererFactory.AddRenderer<IDebugLibRenderer, DebugLibRenderer>();

            // For DomainModelLib
            rendererFactory.AddRenderer<IUserRenderer, UserRenderer>();
            rendererFactory.AddRenderer<IRoleRenderer, RoleRenderer>();
            rendererFactory.AddRenderer<IPermissionRenderer, PermissionRenderer>();
            rendererFactory.AddRenderer<IDomainClassRenderer, DomainClassRenderer>();
            rendererFactory.AddRenderer<ISystemModelRenderer, SystemModelRenderer>();
            rendererFactory.AddRenderer<IDomainModelRenderer, DomainModelRenderer>();

            // For FormModelsLib
            rendererFactory.AddRenderer<IControlRenderer, ControlRenderer>();
            rendererFactory.AddRenderer<IFormModelsRenderer, FormModelsRenderer>();

            // For AppLib
            rendererFactory.AddRenderer<ISessionRenderer, SessionRenderer>();
            rendererFactory.AddRenderer<ISecurityRenderer, SecurityRenderer>();
            rendererFactory.AddRenderer<IGlobalizationRenderer, GlobalizationRenderer>();
            rendererFactory.AddRenderer<IAppRenderer, AppRenderer>();
            rendererFactory.AddRenderer<IApplicationRenderer, Renderer.AppLib.ApplicationRenderer>();
            rendererFactory.AddRenderer<IApplicationCacheRenderer, ApplicationCacheRenderer>();
            rendererFactory.AddRenderer<IThreadLocalStorageRenderer, ThreadLocalStorageRenderer>();

            // For RegExpLib
            rendererFactory.AddRenderer<IVerbalExpressionsRenderer, VerbalExpressionsRenderer>();

            // For InterfacesLib
            rendererFactory.AddRenderer<IInterfaceRenderer, InterfaceRenderer>();
            rendererFactory.AddRenderer<IServiceRenderer, ServiceRenderer>();

            // For CommonLib
            rendererFactory.AddRenderer<IUtilitiesRenderer, UtilitiesRenderer>();
            rendererFactory.AddRenderer<IDataAccessContextRenderer, DataAccessContextRenderer>();
            rendererFactory.AddRenderer<IEmailRenderer, EmailRenderer>();
            rendererFactory.AddRenderer<IMathRenderer, MathRenderer>();
            rendererFactory.AddRenderer<IPagedResultsRenderer, PagedResultsRenderer>();
            rendererFactory.AddRenderer<ISerializerRenderer, SerializerRenderer>();
            rendererFactory.AddRenderer<IServiceResponseRenderer, ServiceResponseRenderer>();
            rendererFactory.AddRenderer<IStopwatchRenderer, StopwatchRenderer>();

            // For WebLib
            rendererFactory.AddRenderer<IWebLibRenderer, WebLibRenderer>();

            return rendererFactory;
        }

        public virtual IExpressionTransformer BuildExpressionTransformer(SolutionModel engine,
                                                                         ILibraryHelper helper,
                                                                         IDataTypeTransformer dataTypeTransformer,
                                                                         IFunctionTransformer functionTransformer,
                                                                         INullSafeTransformer nullSafeTransformer,
                                                                         CompilerOptions options)
        {

            var nullParserHelper = BuildNullExpressionParserHelper(engine, helper, dataTypeTransformer, options);
            return new ExpressionTransformer(helper, options, nullParserHelper, dataTypeTransformer, functionTransformer, nullSafeTransformer);
        }

        public virtual IStatementTransformer BuildStatementTransformer(SolutionModel engine,
                                                                       ILibraryHelper helper,
                                                                       IExpressionTransformer expressionTransformer,
                                                                       IFunctionTransformer functionTransformer,
                                                                       CompilerOptions options)
            => new StatementTransformer(helper, expressionTransformer, options);

        public virtual IDataTypeTransformer BuildDataTypeTransformer(SolutionModel engine,
                                                                     ILibraryHelper helper,
                                                                     CompilerOptions options)
            => new DataTypeTransformer(helper);

        public virtual INullSafeTransformer BuildNullSafeTransformer(IDataTypeTransformer dataTypeTransformer)
            => new NullSafeTransformer(dataTypeTransformer);

        public virtual INullExpressionParserHelper BuildNullExpressionParserHelper(SolutionModel engine,
                                                                                   ILibraryHelper helper,
                                                                                   IDataTypeTransformer transformer,
                                                                                   CompilerOptions options)
            => new NullExpressionParserHelper(engine, helper, transformer);

        public IExpressionMetadata BuildExpressionMedatata(SolutionModel engine,
                                                           ILibraryHelper libraryHelper)
            => new ExpressionMedatata(engine, libraryHelper);

        public IStatementMetadata BuildStatementMetadata(SolutionModel engine,
                                                         IExpressionMetadata expressionMetadata,
                                                         ILibraryHelper libraryHelper)
            => new StatementMetadata(expressionMetadata, libraryHelper);

        public IMetadataService BuildMetadataService(SolutionModel engine,
                                                     ILibraryHelper libraryHelper)
        {
            var expressionMetadata = BuildExpressionMedatata(engine, libraryHelper);
            var statementMetadata = BuildStatementMetadata(engine, expressionMetadata, libraryHelper);

            return new MetadataService(expressionMetadata, statementMetadata, engine);
        }
    }
}
