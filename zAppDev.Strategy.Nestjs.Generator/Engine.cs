using zAppDev.Strategy.Nestjs.Generator.Generators.DomainModel;
using zAppDev.Strategy.Nestjs.Generator.Generators.Services;
using zAppDev.Strategy.Utilities;

namespace zAppDev.Strategy.Nestjs.Generator
{
    public class Engine
    {
        
        private readonly EngineSession session;

        public Engine(EngineConfiguration config)
        {
            session = new EngineSession
            {
                Config = config,
                OutputPath = Path.Combine(config.OutputPath, config.User, config.AppName)
            };
        }

        public void Generate()
        {
            PrepareGeneration();
            SyncStaticFiles();

            new DomainModelService(session).Generate();
            new ExposedService(session).Generate();
        }

        private void PrepareGeneration()
        {
            if (!Directory.Exists(session.OutputPath))
            {
                Directory.CreateDirectory(session.OutputPath);
            }
        }

        private void SyncStaticFiles()
        {
            if (File.Exists(Path.Combine(session.OutputPath, "package.json")))
            {
                return;
            }

            //TODO: not hardcoded directory!!
            FileSystem.SyncronizePaths("D:\\DEV\\cfs\\zAppDev.Strategy.nestjs\\StaticFiles", session.OutputPath, "*.*");
        }
    }
}