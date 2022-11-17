using CLMS.AppDev.Messaging.DTOs;
using CLMS.AppDev.Messaging.DTOs.Requests;
using CLMS.AppDev.Messaging.DTOs.Responses;
using CLMS.AppDev.Messaging.RequestProcessing;
using CLMS.AppDev.Messaging.Transport;

namespace CLMS.CodingFacility.CS.Server.ServiceProxies
{
    public class ModelServiceProxy : ServiceProxyBase
    {
        public ModelServiceProxy(string user, string clientId, string requestId, int appId) 
            : base(user, clientId, requestId, appId)
        {
        }

        public Task<byte[]> GetModelContents()
        {
            var taskCompletionSource = new TaskCompletionSource<byte[]>();

            RequestCallbackManager.PublishPrivateMessage(PrepareMessage(AppDevServices.Model.GetAllFileContents),
                response =>
                {
                    var err = response as ErrorMessageServiceResponse;
                    if (err != null)
                    {
                        taskCompletionSource.SetResult(null);
                        return false;
                    }
                    taskCompletionSource.SetResult(((ModelServiceResponse)response).Models.FirstOrDefault().BinaryContents);
                    return true;
                });

            return taskCompletionSource.Task;
        }

        private MessageBase PrepareMessage(string operation)
        {
            var message = PrepareMessage(nameof(AppDevServices.Model),
                new MetaModelRequest
                {
                    Operation = operation,
                    ModelType = 0,
                    ModelId = 0,
                });

            return message;
        }
    }
}
