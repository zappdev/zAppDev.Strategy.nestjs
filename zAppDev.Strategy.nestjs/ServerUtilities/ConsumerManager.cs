using CLMS.AppDev.Messaging.DTOs;
using CLMS.AppDev.Messaging.DTOs.Responses;
using CLMS.AppDev.Messaging.RequestProcessing;
using CLMS.AppDev.Messaging.Transport;

namespace CLMS.CodingFacility.ServerUtilities
{
    public class ConsumerManager : IServiceRequestBehavior
    {
        public void Before()
        {
            
        }

        public void OnSuccess()
        {
            
        }

        public void OnError(Exception e, MessageBase request)
        {
            var errors = new List<Tuple<string, string>>();
            var currentException = e;
            while (currentException != null)
            {
                errors.Add(Tuple.Create(currentException.Message, currentException.StackTrace));
                currentException = currentException.InnerException;
            }
            errors.Reverse();

            var errMessage = new ErrorMessageServiceResponse
            {
                RequestId = request.RequestId,
                ClientId = request.ClientId,
                Operation = request.Operation,
                Channel = request.Channel,
                PublishedOn = DateTime.UtcNow,
                ApplicationId = request.ApplicationId,
                UserEmail = request.UserEmail,
                Topic = request.Sender,
                Errors = errors,
                Message = errors.Any() ? errors.First().Item1 : ""
            };

            AppDevServiceManager.Instance.Publish(new MessageBase
            {
                RequestId = request.RequestId,
                ClientId = request.ClientId,
                Operation = request.Operation,
                Channel = request.Channel,
                PublishedOn = DateTime.UtcNow,
                ApplicationId = request.ApplicationId,
                UserEmail = request.UserEmail,
                Topic = request.Sender,
                Error = errMessage
            });
        }

        public void OnFinish()
        {
            
        }
    }
}