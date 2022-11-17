using CLMS.AppDev.Messaging.DTOs;

namespace CLMS.CodingFacility.ServerUtilities
{
    public class RequestServerBase
    {
        protected MessageBase Request;

        protected RequestServerBase(MessageBase request)
        {
            Request = request;
        }

        protected MessageBase PrepareResponseMessage(MessageBase response)
        {
            response.UserEmail = Request.UserEmail;
            response.ClientId = Request.ClientId;
            response.Operation = Request.Operation;
            response.Channel = Request.Channel;
            response.ApplicationId = Request.ApplicationId;
            response.RequestId = Request.RequestId;

            return response;
        }
    }
}