using CLMS.Lang.Model;
using CLMS.Lang.Model.Structs;
using System.Text;
using zAppDev.Strategy.Nestjs.Generator.Language.Core;
using zAppDev.Strategy.Utilities.Transformer;

namespace zAppDev.Strategy.Nestjs.Generator.Generators.DomainModel
{
    internal class EntityGenerator : TypescriptGenerator<TypeClass>
    {
        public override string GetFilename(TypeClass model)
        {
            return $"{model.Name}.entity.ts";
        }

        protected override string RenderImports(TypeClass model)
        {
            return $@"import {{ Column, Entity, PrimaryGeneratedColumn, ManyToOne, OneToMany }} from 'typeorm';
import * as Domain from '@entity/index';";
        }

        protected override string RenderClass(TypeClass model)
        {
            var tableName = !string.IsNullOrWhiteSpace(model.TableName) ? 
                model.TableName.ToLower() : model.Name.ToLower();

            return $@"
@Entity('{tableName}')
export class {model.Name} {{

{GenerateProperties(model)}
}}";
        }

        private string GenerateProperties(TypeClass model)
        {
            var datatypeTransformer = new DataTypeTransformer();

            var propertiesCode = new StringBuilder();

            foreach (var property in model.GetPrimitiveProperties())
            {
                if (property == model.Key)
                {
                    propertiesCode.AppendLine($"@PrimaryGeneratedColumn()");
                }
                else
                {
                    propertiesCode.AppendLine($"@Column()");
                }

                propertiesCode.AppendLine($"{property.Name}?: {datatypeTransformer.Transform(property.DataType)};");
                propertiesCode.AppendLine();
            }

            foreach (var property in model.GetComplexProperties())
            {
                GenerateAssotiation(propertiesCode, property);
            }

            return propertiesCode.ToString();
        }

        private void GenerateAssotiation(StringBuilder code, Property property)
        {
            if (!property.DataType.IsCollection())
            {
                CreateOnePartOfAssociation(code, property);
            }
            else
            {
                CreateManyPartOfAssociation(code, property);
            }
        }

        private void CreateOnePartOfAssociation(StringBuilder code, Property property)
        {
            var otherEndType = "Domain." + property.DataType.Name;
            var propName = property.Name;

            code.AppendLine($"@ManyToOne(() => {otherEndType})"); //, ({propName}) => user.photos

            code.AppendLine($"{propName}: {otherEndType};");
            code.AppendLine();
        }

        private void CreateManyPartOfAssociation(StringBuilder code, Property property)
        {
            var otherEndEntity = PrimitiveDatatypes.GetCollectionContainingDT(property.DataType).Name;
            var otherEndType = "Domain." + otherEndEntity;
            var propName = property.Name;

            code.AppendLine($"@OneToMany(() => {otherEndType}, ({otherEndEntity}) => {otherEndEntity}.{property.OtherEnd.Name})"); //, ({propName}) => user.photos

            code.AppendLine($"{propName}: {otherEndType}[];");
            code.AppendLine();
        }
    }
}
