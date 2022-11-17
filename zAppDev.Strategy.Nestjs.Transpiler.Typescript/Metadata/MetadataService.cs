using CLMS.AppDev.MetaModels;
using zAppDev.Strategy.Transpiler.Base.Metadata;
using zAppDev.Strategy.Transpiler.Base.Models;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Metadata
{
    public class MetadataService : IMetadataService
    {
        public IExpressionMetadata ExpressionMetadata { get; set; }
        public IStatementMetadata StatementMetadata { get; set; }
        private SolutionModel _engine;

        public MetadataService(IExpressionMetadata expressionMetadata,
                               IStatementMetadata statementMetadata,
                               SolutionModel engine)
        {
            ExpressionMetadata = expressionMetadata;
            StatementMetadata = statementMetadata;
            _engine = engine;
        }
        public FunctionOptions GetMetadata(FunctionOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
