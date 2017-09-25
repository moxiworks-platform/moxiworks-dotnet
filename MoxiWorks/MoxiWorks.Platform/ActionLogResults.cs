using System.Collections.Generic;
using System.Security.AccessControl;
using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    public class ActionLogResults
    {
        
        [JsonProperty("agent_uui")]  
        public string AgentUuid { get; set; }
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }  
        [JsonProperty("moxi_works_contact_id")]
        public string MoxWorksContactId { get; set; }
        [JsonProperty("partner_contact_id")]   
        public string PartnerContactId { get; set; }
        [JsonProperty("actions")]
        public List<ActionLogIndexItem> Actions { get; set; } = new List<ActionLogIndexItem>();
        
    }
}