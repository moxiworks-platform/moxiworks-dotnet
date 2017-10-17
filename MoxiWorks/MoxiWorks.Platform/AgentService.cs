using System;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{
    public class AgentService : IAgentService
    {
        public MoxiWorksClient Client { get; set; }

        public AgentService(MoxiWorksClient client)
        {
            Client = client;
        }

        public async Task<Response<Agent>> GetAgentAsync(string agentId, string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"agents/{agentId}")
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId);
            return await Client.GetRequestAsync<Agent>(builder.GetUrl()); 
        }

        public async Task<Response<AgentResults>> GetAgentsAsync(string moxiWorksCompanyId, string moxiWorksOfficeId = null,
            DateTime? updatedSince = null, int? pageNumber = 1)
        {
            var builder = new UriBuilder("agents")
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId)
                .AddQueryParameter("moxi_works_office_id", moxiWorksOfficeId)
                .AddQueryParameter("updated_since", updatedSince)
                .AddQueryParameter("page_number", pageNumber);
            return await  Client.GetRequestAsync<AgentResults>(builder.GetUrl());
        }
        
    }
}