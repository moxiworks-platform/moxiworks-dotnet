using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    public class Group
    {
        
        [JsonProperty("agent_uuid")]
        public string AgentUuId { get; set; }
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }
        [JsonProperty("moxi_works_group_name")]
        public string MoxiWorksGroupName { get; set; }
        [JsonProperty("moxi_works_group_id")]
        public string MoxiWorksGroupId { get; set; } 
        [JsonProperty("transient")]
        public bool?  Transient { get; set; }
        [JsonProperty("page_number")]
        public int? PageNumber { get; set; }
        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }
        [JsonProperty("contacts")]
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}