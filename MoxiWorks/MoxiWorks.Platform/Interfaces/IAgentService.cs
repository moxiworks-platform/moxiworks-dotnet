using System;

namespace MoxiWorks.Platform
{
    public interface IAgentService
    {
        MoxiWorksClient Client { get; set; }
        Response<Agent> GetAgent(string agentId, string moxiWorksCompanyId);

        Response<AgentResults> GetAgents(string moxiWorksCompanyId, string moxiWorksOfficeId = null,
            DateTime? updatedSince = null, int? pageNumber = 1);
    }
}