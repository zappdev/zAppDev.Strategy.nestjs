using System.Configuration;
using zAppDev.Strategy.Nestjs.Generator;
using zAppDev.Strategy.Νestjs.Server;

namespace zAppDev.Strategy.nestjs
{
    internal class Program
    {
        static void Main()
        {
            string userEmail = "nest@zappdev.com";
            string appName = "NestSample";
            int appId = 23354;

            var generationPath = ConfigurationManager.AppSettings["zappdev:outputpath"];
            if (string.IsNullOrWhiteSpace(generationPath))
            {
                generationPath = Path.Combine(Directory.GetCurrentDirectory(), "Generated");
            }

            using var builder = new LocalProjectBuilder(); //new RemoteProjectBuilder();
            builder.Init(userEmail, appName, appId, generationPath);

            Console.WriteLine($"Generate was called for AppId: {appId}, User: {userEmail}");
            Console.WriteLine($"Generation Path: {generationPath}");
            Console.WriteLine("Requesting Solution Metamodel...");
            var solution = CLMS.AppDev.Testing.Utilities.GetSolution(appId, userEmail);
            if (solution == null)
            {
                Console.WriteLine("Could not get Solution Metamodel! Please Validate to see the error list");
                return;
            }

            var engine = new Engine(new EngineConfiguration
            {
                AppId = appId,
                AppName = appName,
                User = userEmail,
                Solution = solution,
                OutputPath = generationPath
            });

            engine.Generate();

            Console.WriteLine("Generate finished. Press Enter to Exit.");
            Console.ReadLine();
        }
    }
}