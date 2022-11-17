using CLMS.AppDev.Messaging.DTOs.Responses;
using CLMS.AppDev.Messaging.RequestProcessing;
using CLMS.CodingFacility.ServerUtilities;

namespace CLMS.CodingFacility.CS.Server.Consumers
{
    public class Error : RequestServerBase // this is weird
    {
        private ErrorMessageServiceResponse _response;
       
        public Error(ErrorMessageServiceResponse response) : base(response)
        {
            _response = response;
        }

        public void ErrorMessage()
        {
            RequestCallbackManager.Consume(_response);
        }
    }
}
