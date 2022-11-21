using CLMS.Lang.Model.Structs;
using System.Text;
using zAppDev.Strategy.Utilities;
using zAppDev.Strategy.Utilities.Transformer;

namespace zAppDev.Strategy.Nestjs.Generator.Generators.DomainModel
{
    internal class DomainModelService
    {
        private EngineSession _session;
        protected TypescriptGenerator<TypeClass> _entityGenerator { get; set; }

        public DomainModelService(EngineSession session)
        {
            _session = session;
            _entityGenerator = new EntityGenerator(_session);
        }

        public void Generate()
        {
            var basePath = Path.Combine(_session.OutputPath, "src", "entity");

            var entities = _session.Config.Solution.DomainModel.Library.GetClasses()
                .Where(c => c.Persisted && !c.IsSystemic)
                .ToList();

            foreach (var entity in entities)
            {
                var (fileName, contents) = _entityGenerator.RenderFile(entity);
                FileSystem.SaveFile(basePath, fileName, contents);
            }

            GenerateIndexFile(basePath, entities);
        }

        private void GenerateIndexFile(string basePath, List<TypeClass> entities)
        {
            var indexFileImports = new StringBuilder();
            var indexFileContents = new StringBuilder();
            var persistedEntiries = new StringBuilder();

            persistedEntiries.Append("export const persistedEntities = [");
            foreach (var entity in entities)
            {
                var filePath = Path.GetFileNameWithoutExtension(_entityGenerator.GetFilename(entity));
                indexFileImports.AppendLine($"import {{ {entity.Name} }} from './{filePath}';");
                indexFileContents.AppendLine($"export * from './{filePath}';");
                persistedEntiries.Append($"{entity.Name},");
            }
            persistedEntiries.AppendLine("];");

            indexFileImports.Append(indexFileContents.ToString());
            indexFileImports.Append(persistedEntiries);

            FileSystem.SaveFile(basePath, "index.ts", indexFileImports.ToString());
        }

    }
}
