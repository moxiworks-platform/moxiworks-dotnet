using System;

namespace MoxiWorks.Platform
{
    public class AgentService
    {
        public MoxiWorksClient Client { get; set; }

        public AgentService(MoxiWorksClient client)
        {
            Client = client;
        }

        public Response<Agent> GetAgent(string agentId, string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"agents/{agentId}")
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId);
            return Client.GetRequest<Agent>(builder.GetUrl()); 
        }

        public Response<AgentResults> GetAgents(string moxiWorksCompanyId, string moxiWorksOfficeId = null,
            DateTime? updatedSince = null, int? pageNumber = 1)
        {
            var builder = new UriBuilder("agents")
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId)
                .AddQueryParameter("moxi_works_office_id", moxiWorksOfficeId)
                .AddQueryParameter("updated_since", updatedSince)
                .AddQueryParameter("page_number", pageNumber);
            return Client.GetRequest<AgentResults>(builder.GetUrl());
        }
        
    }
}