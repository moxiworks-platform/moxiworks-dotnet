
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;


namespace MoxiWorks.Platform
{
    /// <summary>
    /// used internaly to generate urls to the moxiworks api
    /// </summary>
    public class UriBuilder
    {

        private const string DEFAULT_HOST = "https://api.moxiworks.com/api/";
        private string _host = null; 
        private string Host
        {
            get
            {
               _host = _host ?? ConfigurationManager.AppSettings["MoxiWorksApiHost"];
               _host = _host ?? DEFAULT_HOST;

               return _host;
            }
        }

        public Dictionary<string, string> QueryParameters { get; } =  new Dictionary<string, string>(); 
        private Uri Path { get; }

        public UriBuilder(string path = "")
        {
            Path = new Uri(Host +  path); 
        }

        public string GetUrl()
        {
            return Path + BuildQueryString();
        }

        public string BuildQueryString()
        {
            if (QueryParameters.Count <= 0)
            return string.Empty;
                
            return "?" + string.Join("&", QueryParameters.Select(q => $"{  HttpUtility.UrlEncode(q.Key)}={HttpUtility.UrlEncode(q.Value)}"));
        }

        public UriBuilder AddQueryParameter(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
            {
                return this; 
            }
            
            QueryParameters.Add(key,value);

            return this;
        }

        public UriBuilder AddQueryParameter(string key, int? value)
        {
            if (string.IsNullOrWhiteSpace(key) || ! value.HasValue)
            {
                return this; 
            }
            
            QueryParameters.Add(key,value.Value.ToString());
            return this;
        }

        public UriBuilder AddQueryParameter(string key, DateTime? value)
        {
            if (string.IsNullOrWhiteSpace(key) || !value.HasValue)
            {
                return this; 
            }

            QueryParameters.Add(key, GetTimeStamp(value.Value).ToString());
            return this; 
        }

        public UriBuilder AddQueryPerameterAgentId(string agentId, AgentIdType agentIdType)
        {
            if (agentIdType == AgentIdType.NotAvaliable)
                return this; 
                
            AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
            return this; 
        }

        private int GetTimeStamp(DateTime value)
        {
            return (int)Math.Truncate(value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
        }

    }
}