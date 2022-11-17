using CLMS.AppDev.Messaging.RequestProcessing;
using CLMS.AppDev.Messaging.Transport;
using CLMS.CodingFacility.CS.Server.ServiceProxies;
using CLMS.CodingFacility.ServerUtilities;
using System.Configuration;

namespace zAppDev.Strategy.Νestjs.Server
{
    internal class RemoteProjectBuilder : IProjectBuilder
    {
        public void Init(string email, string appName, int appId, string generationPath)
        {
            var topic = "NestJS";

            RequestServer.Instance.Register(topic, new ConsumerManager(), typeof(RequestServerBase), GetType().Assembly);

            AppDevServiceManager.Instance
                .Call(new AppDevServices.Model(), AppDevServices.Topic.SERVER, supportsPrivateCommunication: true);

            AppDevServiceManager.Instance.StartChannels();

            CLMS.AppDev.Testing.Utilities.UpdateSetting("zappdev:applicationsPath", 
                Path.Combine(Directory.GetCurrentDirectory(), "Temp"));
            LocalCopyModels(ConfigurationManager.AppSettings["zappdev:applicationsPath"] ?? "", email, appName, appId);

            CLMS.AppDev.Testing.Utilities.InitializeLocalDAL();
        }

        public void LocalCopyModels(string path, string email, string appName, int appId)
        {
            var task = new ModelServiceProxy(email,
                         Guid.NewGuid().ToString(),
                         Guid.NewGuid().ToString(),
                        appId).GetModelContents();

            var modelContents = task.Result;

            CLMS.AppDev.Testing.Utilities.LocalCopyModels(path, modelContents, email, appName, appId);
        }

        public void Dispose()
        {
            AppDevServiceManager.Instance.StopChannels();
        }

        /* App Settings 
        <add key="rabbit:host" value="" />
		<add key="rabbit:user" value="" />
		<add key="rabbit:pass" value="" />
		<add key="rabbit:vhost" value="/" />
		<add key="rabbit:port" value="5672" />
		<add key="rabbit:requestedHeartbeat" value="20" />
		<add key="rabbit:topologyRecoveryEnabled" value="true" />
		<add key="rabbit:maxConnectionRemaxTries" value="50" />
		<add key="rabbit:connectionRetrySeconds" value="3" />
		<add key="rabbit:connectionCloseTimeout" value="2000" />
		<add key="rabbit:dontTryToRecover" value="true" />
        */
    }
}
