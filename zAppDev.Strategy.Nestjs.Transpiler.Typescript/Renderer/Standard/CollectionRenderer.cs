using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using zAppDev.Strategy.Transpiler.Base.Renderer.StandardLib;
using CLMS.Lang.Model.Expressions;
using CLMS.Lang.Model.Structs;
using System;
using zAppDev.Strategy.Transpiler.Base.Models;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Renderer.Standard
{
    public class CollectionRenderer : ICollectionRenderer
    {
        protected readonly ILibraryHelper _helper;
        protected readonly IFunctionTransformer _compiler;

        public CollectionRenderer(ILibraryHelper helper, IFunctionTransformer compiler)
        {
            _helper = helper;
            _compiler = compiler;
        }

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Add()
            => (options, parsed, @params, fcall) => CollectionWrapperMethod(options, parsed, @params, fcall, "add"); // TODO

        public Func<FunctionOptions, string, string, FunctionCall, string> AddAt()
            => (options, parsed, @params, fcall) => CollectionWrapperMethod(options, parsed, @params, fcall, "insert");

        public Func<FunctionOptions, string, string, FunctionCall, string> AddManyNew()
            => (options, parsed, @params, fcall) => CollectionWrapperMethod(options, parsed, @params, fcall, "addManyNew"); // TODO

        public Func<FunctionOptions, string, string, FunctionCall, string> AddNew()
            => (options, parsed, @params, fcall) => AddNewCall(options, parsed, @params, fcall, "add"); // TODO

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> AddRange()
            => (options, parsed, @params, fcall) => CollectionWrapperMethod(options, parsed, @params, fcall, "addRange"); // TODO

        public Func<FunctionOptions, string, string, FunctionCall, string> All()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"all({@params})");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Any()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"any({@params})");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Clear()
            => (options, parsed, @params, fcall) => CollectionWrapperMethod(options, parsed, @params, fcall, "clear"); // TODO

        public Func<FunctionOptions, string, string, FunctionCall, string> Concat()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed + "concat(" + @params + ")", "toArray()");

        public Func<FunctionOptions, string, string, FunctionCall, string> Contains()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"contains({@params})");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Count()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", "count(" + @params + ")");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Distinct()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"distinct({@params})", "toArray()");

        public Func<FunctionOptions, string, string, FunctionCall, string> Except()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"except({@params})", "toArray()");

        public Func<FunctionOptions, string, string, FunctionCall, string> FindLastIndex()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "lastIndexOf(" + @params + ")");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> First()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"where({@params})", "firstOrDefault(null)");

        public Func<FunctionOptions, string, string, FunctionCall, string> FindIndex()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed + "indexOf(" + @params + ")");

        public Func<FunctionOptions, string, string, FunctionCall, string> Get()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, $"{parsed}[{@params}]");

        public Func<FunctionOptions, string, string, FunctionCall, string> IndexOf()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, $"{parsed}", $"indexOf({@params})");

        public Func<FunctionOptions, string, string, FunctionCall, string> Intersect()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"intersect({@params})", "toArray()");

        public Func<FunctionOptions, string, string, FunctionCall, string> Last()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"lastOrDefault({@params})");

        public Func<FunctionOptions, string, string, FunctionCall, string> LastIndexOf()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"lastIndexOf({@params})");

        public Func<FunctionOptions, string, string, FunctionCall, string> Max()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"select({@params})", "max()");

        public Func<FunctionOptions, string, string, FunctionCall, string> Min()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"select({@params})", "min()");

        public Func<FunctionOptions, string, string, FunctionCall, string> OrdeByDescending()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"orderByDescending({@params})", "toArray()");

        public Func<FunctionOptions, string, string, FunctionCall, string> OrderBy()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"orderBy({@params})", "toArray()");

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Remove()
            => (options, parsed, @params, fcall) => CollectionWrapperMethod(options, parsed, @params, fcall, "remove"); // TODO

        public Func<FunctionOptions, string, string, FunctionCall, string> Reverse()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "reverse(" + @params + ")");

        public Func<FunctionOptions, string, string, FunctionCall, string> Select()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"select({@params})", "toArray()");

        public Func<FunctionOptions, string, string, FunctionCall, string> Set()
        {
            return (options, parsed, @params, fcall) =>
            {
                var index = _compiler.ExpressionTransformer.Transform(options, fcall.Parameters[0]);
                var value = _compiler.ExpressionTransformer.Transform(options, fcall.Parameters[1]);

                return $"{parsed}[{index}] = {value}";
            };
        }

        public Func<FunctionOptions, string, string, FunctionCall, string> Single()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"single({@params})");

        public Func<FunctionOptions, string, string, FunctionCall, string> Skip()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(
                options, OmmitToListCalling(parsed), "linq", $"skip({@params})", "toArray()");

        public Func<FunctionOptions, string, string, FunctionCall, string> Sum()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(
                options, parsed, "linq", $"sum({@params})");

        public Func<FunctionOptions, string, string, FunctionCall, string> Take()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(
                options, OmmitToListCalling(parsed), "linq", $"take({@params})", "toArray()");

        public Func<FunctionOptions, string, string, FunctionCall, string> ThenBy()
            => (options, parsed, @params, fcall) => !parsed.Contains("orderBy") ? "" : _compiler.NullSafeTransformer.ConcatMembers(
                options, OmmitToListCalling(parsed), $"thenBy({@params})", "toArray()");

        public Func<FunctionOptions, string, string, FunctionCall, string> ToArray()
            => (options, parsed, @params, fcall) => parsed;

        public virtual Func<FunctionOptions, string, string, FunctionCall, string> Where()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"where({@params})", "toArray()");

        private string AddNewCall(FunctionOptions options, string parsed, string @params, FunctionCall fcall, string methodName)
        {
            var collectionDT = fcall.Function.GetParent() as GenericTypeClassInstance;
            return CollectionWrapperMethod(options, parsed, $"{GetInstantiationCode(collectionDT?.GenericParameters[0])}", fcall, methodName);
        }

        private static string OmmitToListCalling(string parsed)
        {
            if (parsed.EndsWith("?.toList()")) parsed = parsed.Substring(0, parsed.Length - 10);
            else if (parsed.EndsWith(".toList()")) parsed = parsed.Substring(0, parsed.Length - 9);
            return parsed;
        }

        protected string CollectionWrapperMethod(FunctionOptions options, string parsed, string @params, FunctionCall fcall, string methodName)
        {
            var collectionDT = fcall.Function.GetParent() as GenericTypeClassInstance;
            var lastDotPosition = parsed.LastIndexOf(".", StringComparison.Ordinal);
            //var memberName = parsed.Substring(lastDotPosition + 1);
            var unprocessedCode = $"{_compiler.NullSafeTransformer.ConcatMembers(options, parsed, methodName)}({@params})";

            return methodName switch
            {
                "addManyNew" => $"{_compiler.NullSafeTransformer.ConcatMembers(options, parsed, methodName)}({@params}, () => {GetInstantiationCode(collectionDT?.GenericParameters[0])})",
                _ => unprocessedCode,
            };
        }

        public string GetInstantiationCode(TypeClass typeClass) //TODO move method to a more proper class
        {
            switch (typeClass.Name)
            {
                case "Collection":
                case "CollectionBase":
                case "Array":
                    return "[]"; //"new System.Collections.List<any>()";

                case "Dictionary":
                    return "new window['Map']()";

                case "string":
                case "char":
                    return "\"\"";

                case "DateTime":
                    return "new Date()";

                case "bool":
                    return "false";
                case "Guid":
                    return "new System.Guid('')";
                case "TimeSpan":
                    return "new System.Time.TimeSpan(0)";
                case "int":
                case "float":
                case "long":
                case "byte":
                case "double":
                case "decimal":
                    return "null";

                default:
                    return _compiler.DataTypeTransformer.GetInstantiationCode(typeClass);
            }
        }


        public Func<FunctionOptions, string, bool, string> CollectionBaseLength()
            => (options, parsed, isAssignment) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "length");

        public Func<FunctionOptions, string, bool, string> IndexedCollectionLength()
            => (options, parsed, @params) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "length");

        public Func<FunctionOptions, string, string, FunctionCall, string> IndexedCollectionSetKeyExpression()
            => (options, parsed, @params, fcall) => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> IndexedCollectionAdd()
            => (options, parsed, @params, fcall) => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> IndexedCollectionAddRange()
            => (options, parsed, @params, fcall) => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> IndexedCollectionGet()
            => (options, parsed, @params, fcall) => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> IndexedCollectionRemove()
            => (options, parsed, @params, fcall) => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> IndexedCollectionRemoveByKey()
            => (options, parsed, @params, fcall) => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> IndexedCollectionClear()
            => (options, parsed, @params, fcall) => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> IndexedCollectionContainsKey()
            => (options, parsed, @params, fcall) => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> IndexedCollectionContainsValue()
            => (options, parsed, @params, fcall) => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> IndexedCollectionGetKeys()
            => (options, parsed, @params, fcall) => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> IndexedCollectionGetItems()
            => (options, parsed, @params, fcall) => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> SelectMany()
            => (options, parsed, @params, fcall) => _compiler.NullSafeTransformer.ConcatMembers(options, parsed, "linq", $"selectMany({@params})", "toArray()");

        public Func<FunctionOptions, string, string, FunctionCall, string> Average()
            => (options, parsed, @params, fcall) => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> Sort()
            => (options, parsed, @params, fcall) => null;

        public Func<FunctionOptions, string, string, FunctionCall, string> Fetch()
            => (options, parsed, @params, fcall) => _helper.NotImplementedHelper.GetNotImplementedCode(parsed,@params, fcall);

        public Func<FunctionOptions, string, bool, string> ArrayLength()
        {
            return CollectionBaseLength();
        }

        public virtual string GetArrayInstantiationCode()
        {
            return "[]";
        }
    }
}
