using CLMS.AppDev.MetaModels.Interface;
using System.Text;
using zAppDev.Strategy.Utilities;
using zAppDev.Strategy.Utilities.Transformer;

namespace zAppDev.Strategy.Nestjs.Generator.Generators.Services
{
    internal class ExposedService
    {
        private EngineSession _session;

        protected TypescriptGenerator<Interface> _apiGenerator;
        protected TypescriptGenerator<Interface> _serviceGenerator;
        protected TypescriptGenerator<Interface> _dtoGenerator;

        public ExposedService(EngineSession session)
        {
            _session = session;
            _apiGenerator = new APIGenerator(session);
            _serviceGenerator = new ServiceGenerator(session);
            _dtoGenerator = new DTOGenerator(session);
        }

        public void Generate()
        {
            var models = _session.Config.Solution.Interfaces
                .Where(c => c.Type == Interface.InterfaceImplementationTypes.EXPOSE_REST)
                .ToList();

            foreach (var exposedAPI in models)
            {
                GenerateFile(Path.Combine(_session.OutputPath, "src", "api", "exposed"), _apiGenerator, exposedAPI);
                GenerateFile(Path.Combine(_session.OutputPath, "src", "service", "exposed"), _serviceGenerator, exposedAPI);
                GenerateFile(Path.Combine(_session.OutputPath, "src", "dto", "exposed"), _dtoGenerator, exposedAPI);
            }

            GenerateApiIndexFile(Path.Combine(_session.OutputPath, "src", "api", "exposed"), models);
            GenerateServiceIndexFile(Path.Combine(_session.OutputPath, "src", "service", "exposed"), models);
        }

        private void GenerateFile(string basePath, TypescriptGenerator<Interface> generator, Interface model)
        {
            var (fileName, contents) = generator.RenderFile(model);
            FileSystem.SaveFile(basePath, fileName, contents);
        }

        private void GenerateApiIndexFile(string basePath, List<Interface> services)
        {
            var indexFileImports = new StringBuilder();
            var indexFileContents = new StringBuilder();
            var exported = new StringBuilder();

            exported.Append("export const serviceControllers = [");
            foreach (var entity in services)
            {
                var filePath = Path.GetFileNameWithoutExtension(_apiGenerator.GetFilename(entity));
                indexFileImports.AppendLine($"import {{ {entity.Name}Controller }} from './{filePath}';");
                indexFileContents.AppendLine($"export * from './{filePath}';");
                exported.Append($"{entity.Name}Controller,");
            }
            exported.AppendLine("];");

            indexFileImports.Append(indexFileContents.ToString());
            indexFileImports.Append(exported);

            FileSystem.SaveFile(basePath, "index.ts", indexFileImports.ToString());
        }

        private void GenerateServiceIndexFile(string basePath, List<Interface> services)
        {
            var indexFileImports = new StringBuilder();
            var indexFileContents = new StringBuilder();
            var exported = new StringBuilder();

            exported.Append("export const serviceServices = [");
            foreach (var entity in services)
            {
                var filePath = Path.GetFileNameWithoutExtension(_serviceGenerator.GetFilename(entity));
                indexFileImports.AppendLine($"import {{ {entity.Name}Service }} from './{filePath}';");
                indexFileContents.AppendLine($"export * from './{filePath}';");
                exported.Append($"{entity.Name}Service,");
            }
            exported.AppendLine("];");

            indexFileImports.Append(indexFileContents.ToString());
            indexFileImports.Append(exported);

            FileSystem.SaveFile(basePath, "index.ts", indexFileImports.ToString());
        }
    }
}
