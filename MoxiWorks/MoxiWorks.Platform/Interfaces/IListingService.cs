using System;
using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    public interface IListingService
    {
        MoxiWorksClient Client { get; set; }
        Task<Response<Listing>> GetListingAsync(string moxiWorksListingId, string moxiWorksCompanyId);

        Task<Response<ListingResults>> GetListingsUpdatedSinceAsync(string moxiWorksCompanyId
            ,AgentIdType agentIdType, string agentId = null,DateTime? updatedSince = null  
            ,string lastMoxiWorksListingId = null);
    }
}