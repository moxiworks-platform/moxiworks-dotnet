using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    public class ActionLog
    {

        [JsonProperty("agent_uuid")]
        public string AgentUuid { get; set; }
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("moxi_works_contact_id")]
        public string MoxWorksContactId { get; set; }
        [JsonProperty("partner_contact_id")]
        public string PartnerContactId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}