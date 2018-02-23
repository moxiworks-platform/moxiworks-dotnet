using System;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{
    public class SoldListingService: ISoldListingService
    {
        private readonly IMoxiWorksClient Client; 
        
        public SoldListingService(IMoxiWorksClient client)
        {
            Client = client;
        }
            
        /// <summary>
        /// Return a single sold listing
        /// </summary>
        /// <param name="moxiWorksListingId">
        /// This is the Moxi Works Platform ID of the SoldListing which you are requesting to Show. 
        /// This data is required and must reference a valid Moxi Works Sold Listing ID for your Show request to be accepted.
        /// </param>
        /// <param name="moxiWorksCompanyId">
        /// A valid Moxi Works Company ID. Use Company Endpoint to determine what moxi_works_company_id you can use.
        /// </param>
        /// <returns>SoldListing or a empty SoldListing</returns>
        public async Task<Response<SoldListing>> GetSoldListingAsync(string moxiWorksListngId, string moxiWorksCompanyId)
        {
                var builder = new UriBuilder($"sold_listings/{moxiWorksListngId}") 
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId);

            return await Client.GetRequestAsync<SoldListing>(builder.GetUrl()); 
 
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
        public async Task<Response<SoldListingResults>> GetSoldListingsUpdatedSinceAsync(string moxiWorksCompanyId
            ,AgentIdType agentIdType , string agentId = null,DateTime? updatedSince = null  
             ,string lastMoxiWorksListingId = null)
        {
            var builder = new UriBuilder("sold_listings/")
                .AddQueryPerameterAgentId(agentId, agentIdType)
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId)
                .AddQueryParameter("updated_since", updatedSince)
                .AddQueryParameter("last_moxi_works_listing_id", lastMoxiWorksListingId);

            return await Client.GetRequestAsync<SoldListingResults>(builder.GetUrl()); 
        }
        
        
        
        
    }
}