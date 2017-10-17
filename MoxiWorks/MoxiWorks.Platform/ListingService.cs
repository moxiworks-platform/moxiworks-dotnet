using System;
using System.Threading.Tasks;

namespace MoxiWorks.Platform
{

    public class ListingService : IListingService
    {
        public MoxiWorksClient Client { get; set; }
        
        public ListingService(MoxiWorksClient client)
        {
            Client = client;
        }
        
        public async Task<Response<Listing>> GetListingAsync(string moxiWorksListingId, string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"listings/{moxiWorksListingId}");
            builder.AddQueryParameter("moxi_works_company_id",moxiWorksCompanyId);

            return await Client.GetRequestAsync<Listing>(builder.GetUrl());
        }

        public async Task<Response<ListingResults>> GetListingsUpdatedSinceAsync(string moxiWorksCompanyId
            ,AgentIdType agentIdType, string agentId = null,DateTime? updatedSince = null  
             ,string lastMoxiWorksListingId = null)
        {
            var builder = new UriBuilder("listings/")
                .AddQueryPerameterAgentId(agentId, agentIdType)
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId)
                .AddQueryParameter("updated_since", updatedSince)
                .AddQueryParameter("last_moxi_works_listing_id", lastMoxiWorksListingId);

            return await Client.GetRequestAsync<ListingResults>(builder.GetUrl()); 
        }
        
    }
}