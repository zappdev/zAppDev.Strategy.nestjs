using zAppDev.Strategy.Transpiler.Base.Core;
using zAppDev.Strategy.Transpiler.Base.Helpers;
using CLMS.Lang.Model.Structs;
using CLMS.Lang.Model;
using System;

namespace zAppDev.Strategy.Nestjs.Transpiler.Typescript.Core
{
    public class DataTypeTransformer : IDataTypeTransformer
    {
        protected readonly ILibraryHelper _helper;

        public string DefaultDefaultValue { get; } = "null";

        public readonly string DefaultDataType = "any";

        public DataTypeTransformer(ILibraryHelper helper)
        {
            _helper = helper;
        }

        public virtual string Transform(TypeClass typeClass)
        {
            if (typeClass is GenericTypeClass)
            {
                throw new NotImplementedException("GenericTypeClass typeClass not implemented");
            }

            if (typeClass is GenericTypeClassInstance genericType)
            {
                switch (genericType.Name)
                {
                    case GenericDataTypeName.Array:
                        return GetDataTypeNameFromCollection(PrimitiveDatatypes.GetContainingDT(genericType));
                    case GenericDataTypeName.Collection:
                        return GetDataTypeNameFromCollection(PrimitiveDatatypes.GetCollectionContainingDT(genericType));
                    default:
                        break;
                }

                //return (CSharpModules.GetDataTypeName(typeClass) ?? typeClass.Name) + '<' +
                //       string.Join(",", genericTypeClassInsatnce.GenericParameters.Select(ParseDataType)) + '>';

                return DefaultDataType;
            }

            return GetDataTypeName(typeClass);
        }

        public virtual string GetDataTypeNameFromCollection(TypeClass dt)
        {
            return $"{Transform(dt)}[]";
        }

        public virtual string GetDataTypeName(ClassContainer typeClass, bool nonNullable = false)
        {
            var originalName = typeClass.GetParent().Name;
            if (originalName.EndsWith("Model")) 
            {
                string cleanWebFormsName = originalName.EndsWith("Model") ? 
                    originalName.Substring(0, originalName.Length - "Model".Length) :
                    originalName;
            }

            if (typeClass.GetParent().Name == "Domain")
            {
                return GetTypeNameFromDomainClass(typeClass);
            }

            string name = null;

            foreach (var module in _helper.Modules)
            {
                name = module.GetFullyQualifiedName(typeClass);
                if (name != null)
                {
                    break;
                }
            }

            if (name == null)
            {
                return DefaultDataType;
            }

            if (nonNullable)
            {
                name = name.Replace("?", "");
            }

            return name;
        }

        public virtual string GetTypeNameFromDomainClass(ClassContainer typeClass)
        {
            return $"{GetNameSpaceFromDomainClass(typeClass)}.{typeClass.Name}";
        }

        public virtual string GetNameSpaceFromDomainClass(ClassContainer typeClass)
        {
            return $"Domain";
        }

        public virtual string GetTypeNameFromWebForm(ClassContainer typeClass)
        {
            return typeClass.Name.Replace("#", "_");
        }

        public virtual string GetDefaultValue(TypeClass typeClass)
        {
            throw new NotImplementedException();
        }

        public virtual string GetDefaultValueOfType(TypeClass typeClass, bool dateAsNull = false)
        {
            if (!typeClass.IsPrimitive() && !(typeClass is Enumeration)) return "null";

            if (typeClass.IsString()) return "\"\"";
            if (typeClass.IsChar()) return "''";
            if (typeClass.IsNumber()) return "0";
            if (typeClass.IsBool()) return "false";
            if (typeClass.IsGuid()) return "null";
            if (typeClass.IsDate())
            {
                return dateAsNull
                    ? "null"
                    : "new Date('1753-01-01')";
            }
            //Here, i guess the enumeration must be... typescripted. 
            if (typeClass is Enumeration enumeration)
            {
                return GetDataTypeName(enumeration) + "." + enumeration.Values[0].Name;
            }

            return DefaultDefaultValue;
        }

        public virtual string GetInstantiationCode(TypeClass typeClass)
        {
            var parsedDt = Transform(typeClass);

            if (parsedDt.Equals(DefaultDataType))
            {
                return "{} as any";
            }
            else
            {
                var isEnum = typeClass is Enumeration;

                if (isEnum)
                {
                    return GetDefaultValueOfType(typeClass as Enumeration);
                }
                else
                {
                    return $"new {parsedDt}()";
                }

            }
        }

        public string FindInstantiationExpression(TypeClass typeClass)
        {
            throw new NotImplementedException();
        }
    }
}
