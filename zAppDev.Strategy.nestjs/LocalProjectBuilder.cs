using System.Configuration;

namespace zAppDev.Strategy.Νestjs.Server
{
    internal class LocalProjectBuilder : IProjectBuilder
    {
        public void Init(string email, string appName, int appId, string generationPath)
        {
            if (string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["zappdev:applicationsPath"]))
            {
                CLMS.AppDev.Testing.Utilities.UpdateSetting("zappdev:applicationsPath",
                    Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "Data", "Applications"));
            }
            
            CLMS.AppDev.Testing.Utilities.InitializeLocalDAL();
        }

        public void Dispose()
        {
            
        }        
    }
}
