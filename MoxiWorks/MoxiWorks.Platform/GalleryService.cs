using MoxiWorks.Platform.Interfaces;
using System.Threading.Tasks;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Moxi Works Platform Gallery entities are groups of photos an agent has associated with a listing.
    /// </summary>
    public class GalleryService: IGalleryService
    {
        public IMoxiWorksClient Client { get; set; }

        public GalleryService(IMoxiWorksClient client)
        {
            Client = client; 
        }
        
        
        
        /// <summary>
        /// Moxi Works Platform Gallery entities are groups of photos an agent has associated with a listing.
        /// </summary>
        /// <param name="agentId">
        /// Must include either:
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an Gallery is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your Gallery request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an Gallery is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or moxi_works_agent_id is required 
        /// and must reference a valid Moxi Works Agent ID for your Gallery request to be accepted.
        /// </param>
        /// <param name="agentIdType">What agentId type you are using.</param>
        /// <param name="agentId"></param>
        /// <param name="agentIdType"></param>
        /// <param name="moxiWorksCompanyId">A valid Moxi Works Company ID. Use Company Endpoint to determine what moxi_works_company_id you can use.</param>
        /// <returns></returns>

        public async Task<Response<GalleryResults>> GetAgentGalleries(string agentId, AgentIdType agentIdType, string moxiWorksCompanyId)
        {
            var builder = new UriBuilder("gallery")
                .AddQueryPerameterAgentId(agentId, agentIdType)
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId);

            return await Client.GetRequestAsync<GalleryResults>(builder.GetUrl());
            
        }
    }
}