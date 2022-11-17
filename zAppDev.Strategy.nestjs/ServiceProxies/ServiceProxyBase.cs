using CLMS.AppDev.Messaging.DTOs;
using CLMS.AppDev.Messaging.RequestProcessing;
using CLMS.AppDev.Messaging.Transport;

namespace CLMS.CodingFacility.CS.Server.ServiceProxies
{
    public class ServiceProxyBase
    {
        public ServiceProxyBase(string user, string clientId, string requestId, int appId, string topic = null)
        {
            _user = user;
            _clientId = clientId;
            _requestId = requestId;
            _appId = appId;
            _topic = string.IsNullOrWhiteSpace(topic) ? AppDevServices.Topic.SERVER : topic;
        }

        private readonly string _user;
        private readonly string _clientId;
        private string _requestId;
        private readonly int _appId;
        private string _topic;

        protected MessageBase PrepareMessage(string channel, MessageBase message)
        {
            if (string.IsNullOrWhiteSpace(_requestId))
            {
                _requestId = Guid.NewGuid().ToString();
            }

            message.ClientId = _clientId;
            message.RequestId = _requestId;
            message.ApplicationId = _appId;
            message.Channel = channel;
            message.Topic = string.IsNullOrWhiteSpace(_topic) ? RequestServer.Instance.DefaultTopic : _topic;

            if (string.IsNullOrEmpty(message.UserEmail))
            {
                message.UserEmail = _user;
            }

            message.PublishedOn = DateTime.UtcNow;
            return message;
        }
    }
}