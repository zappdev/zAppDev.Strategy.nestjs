using CLMS.AppDev.Messaging.DTOs.Responses;
using CLMS.AppDev.Messaging.RequestProcessing;
using CLMS.CodingFacility.ServerUtilities;

namespace CLMS.CodingFacility.CS.Server.Consumers
{
    public class Model : RequestServerBase // this is weird
    {
        private ModelServiceResponse _response;
       
        public Model(ModelServiceResponse response) : base(response)
        {
            _response = response;
        } 
        
        public void GetAllFileContents()
        {
            RequestCallbackManager.Consume(_response);
        }
    }
}
