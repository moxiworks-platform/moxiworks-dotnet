using System;
using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    /// <summary>
    /// Wrapper around the service to allow stubbing of the service.
    /// </summary>
    public interface IListingService
    {
        MoxiWorksClient Client { get; set; }
        Task<Response<Listing>> GetListingAsync(string moxiWorksListingId, string moxiWorksCompanyId);

        Task<Response<ListingResults>> GetListingsUpdatedSinceAsync(string moxiWorksCompanyId
            ,AgentIdType agentIdType, string agentId = null,DateTime? updatedSince = null  
            ,string lastMoxiWorksListingId = null);
    }
}