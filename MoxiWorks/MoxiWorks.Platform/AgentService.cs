using System;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Moxi Works Agent objects contain data about agents that your organization can use. 
    /// For example, you can determine an agent’s office address or primary phone number 
    /// from an Agent object.
    /// </summary>
    public class AgentService : IAgentService
    {
        public IMoxiWorksClient Client { get; set; }

        public AgentService(IMoxiWorksClient client)
        {
            Client = client;
        }
        
        /// <summary>
        /// When finding an Agent using the Moxi Works platform API
        /// </summary>
        /// <param name="agentId">
        /// Must include either:
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your ActionLog request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or moxi_works_agent_id is required 
        /// and must reference a valid Moxi Works Agent ID for your ActionLog request to be accepted.
        /// Agent ID for your ActionLog request to be accepted.
        /// </param>
        /// <param name="moxiWorksCompanyId">
        /// A valid Moxi Works Company ID. Use Company Endpoint to determine what 
        /// moxi_works_company_id you can use
        /// </param>
        /// <returns> the Agent if exists or an empty Agent Object </returns>
        public async Task<Response<Agent>> GetAgentAsync(string agentId,string moxiWorksCompanyId)
        {
            return await GetAgentWithGoalsAsync(agentId, moxiWorksCompanyId, false);
        }
        
        /// <summary>
        /// Synchronous wrapper for GetAgentAsync
        /// </summary>
        public Response<Agent> GetAgent(string agentId,string moxiWorksCompanyId)
        {
            return System.Threading.Tasks.Task.Run(() =>GetAgentAsync(agentId,moxiWorksCompanyId)).Result; 
        }

        /// <summary>
        /// When finding an Agent using the Moxi Works platform API and optionaly include an agents gci goals.
        /// </summary>
        /// <param name="agentId">
        /// Must include either:
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your ActionLog request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or moxi_works_agent_id is required 
        /// and must reference a valid Moxi Works Agent ID for your ActionLog request to be accepted.
        /// Agent ID for your ActionLog request to be accepted.
        /// </param>
        /// <param name="moxiWorksCompanyId">
        /// A valid Moxi Works Company ID. Use Company Endpoint to determine what 
        /// moxi_works_company_id you can use
        /// </param>
        /// <param name="includeGciGoals">
        /// Whether to include agent’s GCI goals and commissions data in the response data.
        /// </param>
        /// <returns> the Agent if exists or an empty Agent Object </returns>
        public async Task<Response<Agent>> GetAgentWithGoalsAsync(string agentId, string moxiWorksCompanyId, bool includeGciGoals)
        {
            var builder = new UriBuilder($"agents/{agentId}")
                .AddQueryParameter("include_gci_goals", includeGciGoals)
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId);
            return await Client.GetRequestAsync<Agent>(builder.GetUrl()); 
        }
        
        /// <summary>
        /// Synchronous wrapper for GetAgentWithGoalsAsync
        /// </summary>
        public Response<Agent> GetAgentWithGoals(string agentId, string moxiWorksCompanyId, bool includeGciGoals)
        {
            return System.Threading.Tasks.Task.Run(() =>GetAgentWithGoalsAsync(agentId,moxiWorksCompanyId,includeGciGoals)).Result; 
        }
        
        
        /// <summary>
        /// When searching for Agent entities using the Moxi Works platform API
        /// </summary>
        /// <param name="moxiWorksCompanyId">A valid Moxi Works Company ID. Use Company Endpoint to
        ///  determine what moxi_works_company_id you can use.
        /// </param>
        /// <param name="moxiWorksOfficeId">
        /// A valid Moxi Works Office ID. Use Office Endpoint to determine what 
        /// moxiWorksOfficeId you can use.
        /// </param>
        /// <param name="updatedSince">
        /// any Agent objects updated after this Unix timestamp will be returned in the response. 
        /// If no updated_since parameter is included in the request, only Agent objects 
        /// updated in the last seven days will be returned.
        /// </param>
        /// <param name="pageNumber">
        /// For queries with multi-page responses, use the page_number parameter to return data 
        /// for specific pages. Data for page 1 is returned if this parameter is not included. 
        /// Use this parameter if total_pages indicates that there is more than one page of data 
        /// available.
        /// </param>
        /// <returns>Returns a Result containing  list of agent meeting the criteria.</returns>
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


        /// <summary>
        /// Synchronous wrapper for GetAgentsAsync
        /// </summary>
        public Response<AgentResults> GetAgents(string moxiWorksCompanyId, string moxiWorksOfficeId = null,
            DateTime? updatedSince = null, int? pageNumber = 1)
        {
            return System.Threading.Tasks.Task.Run(() =>GetAgentsAsync(moxiWorksCompanyId,moxiWorksOfficeId,
            updatedSince,pageNumber)).Result; 
        }
        
    }
}