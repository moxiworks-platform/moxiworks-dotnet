using System;
using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    public interface ISoldListingService
    {


        Task<Response<SoldListing>> GetSoldListingAsync(
            string moxiWorksListngId,
            string moxiWorksCompanyId);

        Task<Response<SoldListingResults>> GetSoldListingsUpdatedSinceAsync(string moxiWorksCompanyId
            , AgentIdType agentIdType, string agentId = null, DateTime? updatedSince = null
            , string lastMoxiWorksListingId = null);


    }
}