
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using UrlBuilder;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// used internaly to generate urls to the moxiworks api
    /// </summary>
    public class UriBuilder : UrlBuilder.UrlBuilder
    {

        private const string DEFAULT_HOST = "https://api.moxiworks.com/api/";
        private static string MoxiHost => ConfigurationManager.AppSettings["MoxiWorksApiHost"] ?? DEFAULT_HOST;


        public UriBuilder(string path = "") : base(MoxiHost + path)
        {
        }
        
        public UriBuilder AddQueryPerameterAgentId(string agentId, AgentIdType agentIdType)
        {
            if (agentIdType == AgentIdType.NotAvaliable)
                return this; 
                
            AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            return this; 
        }

    }
}