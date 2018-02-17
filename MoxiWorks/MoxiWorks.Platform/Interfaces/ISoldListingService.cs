using System;
using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    public interface ISoldListingService
    {
//        Task<Response<<SoldListing>> GetSoldListingAsync(
//            string moxiWorksCompanyId,DateTime soldSince, 
//            string agentId, 
//            AgentIdType agentIdType,
//            string moxiWorksOfficeId,
//            string lastMoxiWorksListingId
//            );

        Task<Response<SoldListing>> GetSoldListingAsync(
            string moxiWorksListngId,
            string moxiWorksCompanyId);


    }
}