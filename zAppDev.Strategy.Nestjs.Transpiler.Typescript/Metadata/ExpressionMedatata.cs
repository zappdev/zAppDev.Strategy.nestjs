using CLMS.AppDev.MetaModels;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Metadata;
using zAppDev.Strategy.Transpiler.Base.Models;
using CLMS.Lang.Model.Expressions;
using System.Linq;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Metadata
{
    public class ExpressionMedatata : IExpressionMetadata
    {
        private SolutionModel _engine;

        private IStatementMetadata _statementMetadata;

        private ILibraryHelper _libraryHelper;

        public ExpressionMedatata(SolutionModel engine, ILibraryHelper libraryHelper)
        {
            _engine = engine;
            _libraryHelper = libraryHelper;
        }

        public MetadataResult Visit(Expression exp, FunctionOptions options, MetadataResult metadata = null)
        {
            if (exp == null)
                throw new System.ArgumentOutOfRangeException($"You have provided null expression");

            return exp switch
            {
                BooleanOperand stm => Visit(stm, options),
                Cast stm => Visit(stm, options),
                CharacterOperand stm => Visit(stm, options),
                Conditional stm => Visit(stm, options),
                Constructor stm => Visit(stm, options),
                DecimalOperand stm => Visit(stm, options),
                EnumerationIdentifier stm => Visit(stm, options),
                FunctionCall stm => Visit(stm, options),
                Identifier stm => Visit(stm, options),
                InlineCollectionInitializer stm => Visit(stm, options),
                IntegerOperand stm => Visit(stm, options),
                Lambda stm => Visit(stm, options),
                Logical stm => Visit(stm, options),
                LogicalComparison stm => Visit(stm, options),
                LogicalNot stm => Visit(stm, options),
                Math stm => Visit(stm, options),
                Member stm => Visit(stm, options),
                MemberWithExpression stm => Visit(stm, options),
                Null stm => Visit(stm, options),
                Parenthesis stm => Visit(stm, options),
                StaticIdentifier stm => Visit(stm, options),
                StringOperand stm => Visit(stm, options),
                _ => throw new System.ArgumentOutOfRangeException($"Expression '{exp.GetType().FullName}' not implemented"),
            };
        }

        public MetadataResult Visit(BooleanOperand exp, FunctionOptions options, MetadataResult metadata = null)
        {
            return new MetadataResult();
        }

        public MetadataResult Visit(EnumerationIdentifier exp, FunctionOptions options, MetadataResult metadata = null)
        {
            return new MetadataResult();
        }

        public MetadataResult Visit(Cast exp, FunctionOptions options, MetadataResult metadata = null)
        {
            return Visit(exp.Expression, options, metadata);
        }

        public MetadataResult Visit(CharacterOperand exp, FunctionOptions options, MetadataResult metadata = null)
        {
            return new MetadataResult();
        }

        public MetadataResult Visit(Conditional exp, FunctionOptions options, MetadataResult metadata = null)
        {
            return Visit(exp.Condition, options, metadata)
                .MergeWith(Visit(exp.FalseExpression, options, metadata))
                .MergeWith(Visit(exp.TrueExpression, options, metadata));
        }

        public MetadataResult Visit(Constructor ctr, FunctionOptions options, MetadataResult metadata = null)
        {
            return new MetadataResult();
        }

        public MetadataResult Visit(DecimalOperand exp, FunctionOptions options, MetadataResult metadata = null)
        {
            return new MetadataResult();
        }

        public MetadataResult Visit(FunctionCall exp, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata = metadata ?? new MetadataResult();
            var parentLib = exp.Function.GetParent().GetParent();

            foreach (var parameter in exp.Parameters)
            {
                metadata = metadata.MergeWith(Visit(parameter, options, metadata));
            }

            if (parentLib == _engine.DomainModel.Library)
            {
                if (exp.Function.Name == "Create")
                {
                    return metadata.MergeWith(new MetadataResult
                    {
                        IsRenderable = true,
                        IsAsync = false,
                    });
                }

                var metadataService = new Factory.TypescriptTranspilerFactory().BuildMetadataService(_engine, _libraryHelper);
                var fcallOptions = new FunctionOptions(exp.Function)
                {
                    DomainModel = options.DomainModel,
                    Scope = options.Scope,
                    Type = options.Type,
                };
                return metadata.MergeWith(metadataService.GetMetadata(fcallOptions).Metadata);
            }
            else if (parentLib.Name == "FormModels")
            {
                if (exp.Function.Name == "Export" || exp.Function.Name == "SendFileToClient")
                {
                    return metadata.MergeWith(new MetadataResult
                    {
                        IsRenderable = false,
                        IsAsync = _libraryHelper.IsAsyncMethod(exp),
                    });
                }

                if (exp.Function.Name != "CommitAllFiles")
                {
                    return metadata.MergeWith(new MetadataResult
                    {
                        IsRenderable = true,
                        IsAsync = _libraryHelper.IsAsyncMethod(exp),
                    });
                }
            }
            
            metadata = metadata.MergeWith(new MetadataResult
            {
                IsRenderable = _libraryHelper.CanTransformMethod(exp),
                IsAsync = _libraryHelper.IsAsyncMethod(exp),
            });

            return metadata;
        }

        public MetadataResult Visit(Identifier exp, FunctionOptions options, MetadataResult metadata = null)
        {
            return new MetadataResult
            {
                IsRenderable = true
            };
        }

        public MetadataResult Visit(InlineCollectionInitializer exp, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata = metadata ?? new MetadataResult();

            var items = exp.Expressions.Select(e => Visit(e, options, metadata)).ToList();

            foreach (var item in items)
            {
                metadata = metadata.MergeWith(item);
            }

            return metadata;
        }

        public MetadataResult Visit(IntegerOperand exp, FunctionOptions options, MetadataResult metadata = null)
        {
            return new MetadataResult();
        }

        public MetadataResult Visit(Lambda exp, FunctionOptions options, MetadataResult metadata = null)
        {
            var metadataResult = new MetadataResult();
            
            if (exp.Statements != null)
            {
                exp.Statements.ForEach(stmt => metadataResult = metadataResult.MergeWith(_statementMetadata.Visit(stmt, options)));
            }

            if (exp.Exp != null)
            {
                metadataResult = metadataResult.MergeWith(Visit(exp.Exp, options, metadataResult));
            }
            
            return metadataResult;
        }

        public MetadataResult Visit(Logical exp, FunctionOptions options, MetadataResult metadata = null)
        {
            var left = Visit(exp.Left, options, metadata);
            var right = Visit(exp.Right, options, metadata);

            return left.MergeWith(right);
        }

        public MetadataResult Visit(LogicalComparison exp, FunctionOptions options, MetadataResult metadata = null)
        {
            var left = Visit(exp.Left, options, metadata);
            var right = Visit(exp.Right, options, metadata);

            return left.MergeWith(right);
        }

        public MetadataResult Visit(LogicalNot exp, FunctionOptions options, MetadataResult metadata = null)
        {
            return Visit(exp.Expression, options, metadata);
        }

        public MetadataResult Visit(Math exp, FunctionOptions options, MetadataResult metadata = null)
        {
            var left = Visit(exp.Left, options, metadata);
            var right = Visit(exp.Right, options, metadata);

            return left.MergeWith(right);
        }

        public MetadataResult Visit(Member exp, FunctionOptions options, Expression stopTransformationOnThis = null)
        {
            var metadata = new MetadataResult();

            for (var index = 0; index < exp.Members.Count; index++)
            {
                metadata = metadata.MergeWith(Visit(exp.Members[index], options, metadata));  
            }

            return metadata;
        }

        public MetadataResult Visit(MemberWithExpression exp, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            if (exp.StartExpression != null)
            {
                metadata.MergeWith(Visit(exp.StartExpression, options, metadata));
            }

            if (exp.EndExpression != null)
            {
                metadata.MergeWith(Visit(exp.EndExpression, options, metadata));
            }

            return metadata;
        }

        public MetadataResult Visit(Null exp, FunctionOptions options, MetadataResult metadata = null)
        {
            return new MetadataResult();
        }

        public MetadataResult Visit(Parenthesis exp, FunctionOptions options, MetadataResult metadata = null)
        {
            return Visit(exp.InnerExpression, options, metadata);
        }

        public MetadataResult Visit(StaticIdentifier exp, FunctionOptions options, MetadataResult metadata = null)
        {
           var status = _libraryHelper.CanTransformMethod(exp);

            return new MetadataResult 
            { 
                IsRenderable = status,
            };
        }

        public MetadataResult Visit(StringOperand exp, FunctionOptions options, MetadataResult metadata = null)
        {
            return new MetadataResult();
        }

        public void SetStatementMetadata(IStatementMetadata statementMetadata)
        {
            _statementMetadata = statementMetadata;
        }
    }
}
