using System;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{

    /// <summary>
    /// Moxi Works Platform Listing entities represent a Brokerage’s listings.
    /// </summary>
    public class ListingService : IListingService
    {
        public IMoxiWorksClient Client { get; set; }

        public ListingService(IMoxiWorksClient client)
        {
            Client = client;
        }

        /// <summary>
        /// Return a single listing
        /// </summary>
        /// <param name="moxiWorksListingId">
        /// This is the Moxi Works Platform ID of the Listing which you are requesting to Show. 
        /// This data is required and must reference a valid Moxi Works Listing ID for your Show request to be accepted.
        /// </param>
        /// <param name="moxiWorksCompanyId">
        /// A valid Moxi Works Company ID. Use Company Endpoint to determine what moxi_works_company_id you can use.
        /// </param>
        /// <returns>Listing or a empty listing</returns>
        public async Task<Response<Listing>> GetListingAsync(string moxiWorksListingId, string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"listings/{moxiWorksListingId}");
            builder.AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId);

            return await Client.GetRequestAsync<Listing>(builder.GetUrl());
        }

        /// <summary>
        /// Index will return a paged response of listings that have been updated since a given timestamp for a specified company. 
        /// For a list of company IDs that you can request listings for, use the Company Endpoint.
        /// </summary>
        /// <param name="moxiWorksCompanyId">
        /// A valid Moxi Works Company ID. Use Company Endpoint to determine what moxi_works_company_id you can use.
        /// </param>
        /// <param name="agentId">
        /// Must include either:
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an Listing entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your Listing request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an Listing entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or moxi_works_agent_id is required 
        /// and must reference a valid Moxi Works Agent ID for your Listing request to be accepted.
        /// Agent ID for your Listing request to be accepted.
        /// </param>
        /// <param name="agentIdType">What agentId type you are using.</param>
        /// <param name="updatedSince">
        /// Paged responses of all Listing objects updated after this Unix timestamp will be returned in the response. If no updated_since parameter is included in the request, 
        /// only Listing objects updated in the last seven days will be returned.
        /// </param>
        /// <param name="lastMoxiWorksListingId">
        /// If fetching a multi-page response, this should be the MoxiWorksListingId found in the last Listing object of the previously fetched page.</param>
        /// <returns></returns>
        public async Task<Response<ListingResults>> GetListingsUpdatedSinceAsync(string moxiWorksCompanyId
            , AgentIdType agentIdType, string agentId = null, DateTime? updatedSince = null
            , string lastMoxiWorksListingId = null)
        {
            var builder = new UriBuilder("listings/")
                .AddQueryPerameterAgentId(agentId, agentIdType)
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId)
                .AddQueryParameter("updated_since", updatedSince)
                .AddQueryParameter("last_moxi_works_listing_id", lastMoxiWorksListingId);

            return await Client.GetRequestAsync<ListingResults>(builder.GetUrl());
        }

        
        
        /// <summary>
        /// Updates the listing data specified in ListingUpdatableData of the ListingUpdate object
        /// </summary>
        /// <param name="listingUpdate"></param>
        /// <returns>ListingResu</returns>
        [Obsolete("Use UpdateListingDataAsync instead")]
        public async Task<Response<ListingResults>> UpdateListingData(ListingUpdate listingUpdate)
        {
            return await UpdateListingDataAsync(listingUpdate);
        }
        
        
        /// <summary>
        /// Updates the listing data specified in ListingUpdatableData of the ListingUpdate object
        /// </summary>
        /// <param name="listingUpdate"></param>
        /// <returns>ListingResu</returns>
        public async Task<Response<ListingResults>> UpdateListingDataAsync(ListingUpdate listingUpdate)
        {
            var builder = new UriBuilder($"listings/{listingUpdate.MoxWorksListingId}")
                .AddQueryParameter("moxi_works_company_id", listingUpdate.MoxiWorksCompanyId);



            return await Client.PutRequestAsync<ListingResults, ListingUpdate>(builder.GetUrl(), listingUpdate);
        }

    }
}