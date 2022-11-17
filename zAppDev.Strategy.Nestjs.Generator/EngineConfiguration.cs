using CLMS.AppDev.MetaModels;

namespace zAppDev.Strategy.Nestjs.Generator
{
    public class EngineConfiguration
    {
        public int AppId { get; set; }
        public string AppName { get; set; }
        public string User { get; set; }
        public SolutionModel Solution { get; set; }
        public string OutputPath { get; set; }
    }
}