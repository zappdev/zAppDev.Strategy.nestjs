using System;
using CLMS.Lang.Model.Statement;
using zAppDev.Strategy.Transpiler.Base.Models;
using zAppDev.Strategy.Transpiler.Base.Metadata;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using System.Linq;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Metadata
{
    public class StatementMetadata : IStatementMetadata
    {
        private readonly IExpressionMetadata _expressionMetadata;

        private ILibraryHelper _libraryHelper;

        public StatementMetadata(IExpressionMetadata expressionMetadata,
                                 ILibraryHelper libraryHelper)
        {
            _libraryHelper = libraryHelper;
            _expressionMetadata = expressionMetadata;
            _expressionMetadata.SetStatementMetadata(this);
        }

        public MetadataResult Visit(Statement statement, FunctionOptions options, MetadataResult metadata = null)
        {
            if (statement == null)
                throw new ArgumentOutOfRangeException($"You have provided null statement");

            return statement switch
            {
                Assign stm => Visit(stm, options),
                Break stm => Visit(stm, options),
                Call stm => Visit(stm, options),
                Catch stm => Visit(stm, options),
                Comment stm => Visit(stm, options),
                Continue stm => Visit(stm, options),
                Define stm => Visit(stm, options),
                Else stm => Visit(stm, options),
                ElseIf stm => Visit(stm, options),
                Finally stm => Visit(stm, options),
                For stm => Visit(stm, options),
                Foreach stm => Visit(stm, options),
                If stm => Visit(stm, options),
                Return stm => Visit(stm, options),
                Switch stm => Visit(stm, options),
                SwitchCase stm => Visit(stm, options),
                SwitchDefaultCase stm => Visit(stm, options),
                Throw stm => Visit(stm, options),
                Try stm => Visit(stm, options),
                While stm => Visit(stm, options),
                _ => throw new ArgumentOutOfRangeException($"Statement '{statement.GetType().FullName}' not implemented"),
            };
        }

        public MetadataResult Visit(Finally statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            var childsMetadata = VisitChilds(statement, options, metadata);
            metadata.IsRenderable = childsMetadata.IsRenderable;

            return metadata;
        }

        public MetadataResult Visit(Assign statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            var leftPartMetadata = _expressionMetadata.Visit(statement.LeftHandPart, options, metadata);
            metadata.IsRenderable = leftPartMetadata.IsRenderable;

            var rightPartMetadata = _expressionMetadata.Visit(statement.RightHandPart, options, metadata);
            metadata.IsRenderable &= rightPartMetadata.IsRenderable;

            return metadata;
        }

        public MetadataResult Visit(Break statement, FunctionOptions options, MetadataResult metadata = null)
        {
            return new MetadataResult();
        }

        public MetadataResult Visit(Call statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            var expressionMetadata = _expressionMetadata.Visit(statement.Expression, options, metadata);
            metadata.IsRenderable = expressionMetadata.IsRenderable;

            return metadata;
        }

        public MetadataResult Visit(Catch statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();
            var childsMetadata = VisitChilds(statement, options, metadata);
            metadata.IsRenderable = childsMetadata.IsRenderable;
            return metadata;
        }

        public MetadataResult Visit(Comment statement, FunctionOptions options, MetadataResult metadata = null)
        {
            return new MetadataResult();
        }

        public MetadataResult Visit(Continue statement, FunctionOptions options, MetadataResult metadata = null)
        {
            return new MetadataResult();
        }

        public MetadataResult Visit(Define statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            if (statement.AssigmentExpression != null)
            {
                var assigmentMetadata = _expressionMetadata.Visit(statement.AssigmentExpression, options, metadata);
                metadata.IsRenderable = assigmentMetadata.IsRenderable;
            }

            return metadata;
        }

        public MetadataResult Visit(Else statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            if (metadata.IsRenderable)
            {
                var childsMetadata = VisitChilds(statement, options, metadata);
                metadata.IsRenderable = childsMetadata.IsRenderable;
            }

            return metadata;
        }

        public MetadataResult Visit(ElseIf statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();


            var ifMetadata = _expressionMetadata.Visit(statement.Expression, options, metadata);
            metadata.IsRenderable = ifMetadata.IsRenderable;

            if (metadata.IsRenderable)
            {
                var childsMetadata = VisitChilds(statement, options, metadata);
                metadata.IsRenderable = childsMetadata.IsRenderable;
            }

            return metadata;
        }

        public MetadataResult Visit(For statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            var ifMetadata = _expressionMetadata.Visit(statement.InitExpression, options, metadata);
            metadata.IsRenderable = ifMetadata.IsRenderable;

            var conditionMetadata = _expressionMetadata.Visit(statement.Condition, options, metadata);
            metadata.IsRenderable = conditionMetadata.IsRenderable;

            var assignMetadata = _expressionMetadata.Visit(statement.Assigment, options, metadata);
            metadata.IsRenderable = assignMetadata.IsRenderable;

            if (metadata.IsRenderable)
            {
                var childsMetadata = VisitChilds(statement, options, metadata);
                metadata.IsRenderable = childsMetadata.IsRenderable;
            }

            return metadata;
        }

        public MetadataResult Visit(Foreach statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            var collectionMetadata = _expressionMetadata.Visit(statement.Collection, options, metadata);
            metadata.IsRenderable = collectionMetadata.IsRenderable;

            if (metadata.IsRenderable)
            {
                var childsMetadata = VisitChilds(statement, options, metadata);
                metadata.IsRenderable = childsMetadata.IsRenderable;
            }

            return metadata;
        }

        public MetadataResult Visit(If statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            var ifMetadata = _expressionMetadata.Visit(statement.Expression, options, metadata);
            metadata.IsRenderable = ifMetadata.IsRenderable;

            if (metadata.IsRenderable)
            {
                var childsMetadata = VisitChilds(statement, options, metadata);
                metadata.IsRenderable = childsMetadata.IsRenderable;
            }

            if (!metadata.IsRenderable) return metadata;

            if (statement.ElseIfStmt != null && statement.ElseIfStmt.Any())
            {
                foreach (var elseIf in statement.ElseIfStmt)
                {
                    var elseIfMetadata = Visit(elseIf, options, metadata);
                    if (elseIfMetadata.IsRenderable == false)
                    {
                        metadata.IsRenderable = false;
                        return metadata;
                    }
                }
            }

            if (statement.ElseStmt != null)
            {
                var elseMetadata = Visit(statement.ElseStmt, options, metadata);
                metadata.IsRenderable = elseMetadata.IsRenderable;
            }

            return metadata;
        }

        public MetadataResult Visit(Return statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            var childMetadata = statement.Expression == null ? metadata : _expressionMetadata.Visit(statement.Expression, options, metadata);

            metadata.IsRenderable = childMetadata.IsRenderable;
            return metadata;
        }

        public MetadataResult Visit(Switch statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            var expressionMetadata = _expressionMetadata.Visit(statement.Expression, options);
            metadata.IsRenderable = expressionMetadata.IsRenderable;

            if (metadata.IsRenderable)
            {
                foreach (var s in statement.ChildStatements)
                {
                    MetadataResult caseMetadata;
                    if (s is SwitchCase switchCase)
                    {
                        caseMetadata = Visit(switchCase, options);
                    }
                    else
                    {
                        caseMetadata = Visit((SwitchDefaultCase)s, options);
                    }

                    if (caseMetadata.IsRenderable == false)
                    {
                        metadata.IsRenderable = false;
                        return metadata;
                    }
                }
            }

            return metadata;
        }

        public MetadataResult Visit(SwitchCase statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            var expressionMetadata = _expressionMetadata.Visit(statement.Expression, options);
            metadata.IsRenderable = expressionMetadata.IsRenderable;

            if (metadata.IsRenderable)
            {
                var childsMetadata = VisitChilds(statement, options, metadata);
                metadata.IsRenderable = childsMetadata.IsRenderable;
            }

            return metadata;
        }

        public MetadataResult Visit(SwitchDefaultCase statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            if (metadata.IsRenderable)
            {
                var childsMetadata = VisitChilds(statement, options, metadata);
                metadata.IsRenderable = childsMetadata.IsRenderable;
            }

            return metadata;
        }

        public MetadataResult Visit(Throw statement, FunctionOptions options, MetadataResult metadata = null)
        {
            return new MetadataResult();
        }

        public MetadataResult Visit(Try statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            if (metadata.IsRenderable)
            {
                var childsMetadata = VisitChilds(statement, options, metadata);
                metadata.IsRenderable = childsMetadata.IsRenderable;
            }

            return metadata;
        }

        public MetadataResult Visit(While statement, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            var expressionMetadata = _expressionMetadata.Visit(statement.Expression, options);
            metadata.IsRenderable = expressionMetadata.IsRenderable;

            if (metadata.IsRenderable)
            {
                var childsMetadata = VisitChilds(statement, options, metadata);
                metadata.IsRenderable = childsMetadata.IsRenderable;
            }

            return metadata;
        }

        private MetadataResult VisitChilds(StatementWithChildren childs, FunctionOptions options, MetadataResult metadata = null)
        {
            metadata ??= new MetadataResult();

            if (childs.ChildStatements == null || !childs.ChildStatements.Any()) return metadata;

            foreach(var statement in childs.ChildStatements)
            {
                var childMetadata = Visit(statement, options, metadata);

                if(childMetadata.IsRenderable == false)
                {
                    metadata.IsRenderable = false;
                    return metadata;
                }
            }

            return metadata;
        }
    }
}
