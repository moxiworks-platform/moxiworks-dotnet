﻿using System;
using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    /// <summary>
    /// Wrapper around the service to allow stubbing of the service.
    /// </summary>
    public interface IAgentService
    {
        MoxiWorksClient Client { get; set; }
        Task<Response<Agent>> GetAgentAsync(string agentId, string moxiWorksCompanyId);

        Task<Response<AgentResults>> GetAgentsAsync(string moxiWorksCompanyId, string moxiWorksOfficeId = null,
            DateTime? updatedSince = null, int? pageNumber = 1);
    }
}