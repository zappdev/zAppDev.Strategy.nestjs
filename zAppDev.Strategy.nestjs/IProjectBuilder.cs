namespace zAppDev.Strategy.Νestjs.Server
{
    internal interface IProjectBuilder : IDisposable
    {
        void Init(string email, string appName, int appId, string generationPath);
    }
}
