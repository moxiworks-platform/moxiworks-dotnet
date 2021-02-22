using System;
using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    /// <summary>
    /// Wrapper around the service to allow stubbing of the service.
    /// </summary>
    public interface IAgentService
    {
        IMoxiWorksClient Client { get; set; }
        
        Task<Response<Agent>> GetAgentAsync(string agentId, string moxiWorksCompanyId);
        Response<Agent> GetAgent(string agentId, string moxiWorksCompanyId);

        Task<Response<Agent>> GetAgentWithGoalsAsync(string agentId, string moxiWorksCompanyId, bool includeGciGoals);
        Response<Agent> GetAgentWithGoals(string agentId, string moxiWorksCompanyId, bool includeGciGoals);

        Task<Response<Agent>> GetAgentWithAccessLevelAsync(string agentId, string moxiWorksCompanyId, bool includeGciGoals);
        Response<Agent> GetAgentWithAccessLevel(string agentId, string moxiWorksCompanyId, bool includeGciGoals);
        
        Task<Response<AgentResults>> GetAgentsAsync(string moxiWorksCompanyId, string moxiWorksOfficeId = null,
            DateTime? updatedSince = null, int? pageNumber = 1);
        Response<AgentResults> GetAgents(string moxiWorksCompanyId, string moxiWorksOfficeId = null,
            DateTime? updatedSince = null, int? pageNumber = 1);
    }
}