using System;

namespace MoxiWorks.Platform
{
    public interface IListingService
    {
        MoxiWorksClient Client { get; set; }
        Response<Listing> GetListing(string moxiWorksListingId, string moxiWorksCompanyId);

        Response<ListingResults> GetListingsUpdatedSince(string moxiWorksCompanyId
            ,AgentIdType agentIdType, string agentId = null,DateTime? updatedSince = null  
            ,string lastMoxiWorksListingId = null);
    }

    public class ListingService : IListingService
    {
        public MoxiWorksClient Client { get; set; }
        
        public ListingService(MoxiWorksClient client)
        {
            Client = client;
        }
        
        public Response<Listing> GetListing(string moxiWorksListingId, string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"listings/{moxiWorksListingId}");
            builder.AddQueryParameter("moxi_works_company_id",moxiWorksCompanyId);

            return Client.GetRequest<Listing>(builder.GetUrl());
        }

        public Response<ListingResults> GetListingsUpdatedSince(string moxiWorksCompanyId
            ,AgentIdType agentIdType, string agentId = null,DateTime? updatedSince = null  
             ,string lastMoxiWorksListingId = null)
        {
            var builder = new UriBuilder("listings/")
                .AddQueryPerameterAgentId(agentId, agentIdType)
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId)
                .AddQueryParameter("updated_since", updatedSince)
                .AddQueryParameter("last_moxi_works_listing_id", lastMoxiWorksListingId);

            return Client.GetRequest<ListingResults>(builder.GetUrl()); 
        }
        
    }
}