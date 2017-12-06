using MoxiWorks.Platform.Interfaces;
using System.Threading.Tasks;

namespace MoxiWorks.Platform
{
    public class GalleryService: IGalleryService
    {
        public IMoxiWorksClient Client { get; set; }

        public GalleryService(IMoxiWorksClient client)
        {
            Client = client; 
        }

        public async Task<Response<GalleryResults>> GetAgentGalleries(string agentId, AgentIdType agentIdType, string moxiWorksCompanyId)
        {
            var builder = new UriBuilder("gallery")
                .AddQueryPerameterAgentId(agentId, agentIdType)
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId);

            return await Client.GetRequestAsync<GalleryResults>(builder.GetUrl());
            
        }
    }
}