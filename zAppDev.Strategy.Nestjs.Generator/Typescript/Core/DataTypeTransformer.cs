using CLMS.Lang.Model.Structs;

namespace zAppDev.Strategy.Nestjs.Generator.Language.Core
{
    internal class DataTypeTransformer
    {
        public ICollection<string> ReservedWords => new List<string>
        {
            "return", "class", "for", "async", "interface", "public", "private", "internal", "eval"
        };

        public string Transform(TypeClass typeClass)
        {
            if (typeClass.IsPrimitive())
            {
                if (typeClass.IsString() || typeClass.IsChar())
                {
                    return "string";
                }
                if (typeClass.IsBool())
                {
                    return "boolean";
                }
                if (typeClass.IsNumber())
                {
                    return "number";
                }
                if (typeClass.IsDate())
                {
                    return "Date";
                }
                if (typeClass.IsVoid())
                {
                    return "void";
                }
            }

            if (typeClass.GetParent().Name == "Domain")
            {
                return $"Domain.{typeClass.Name}";
            }

            return "any";
        }
    }
}
