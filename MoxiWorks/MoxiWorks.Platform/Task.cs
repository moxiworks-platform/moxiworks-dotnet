using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    public class Task
    {
        
        [JsonProperty("agent_uuid")]
        public string AgentUuId { get; set; }
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }
        [JsonProperty("partner_contact_id")]
        public string PartnerContactId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("due_at")]
        public int? DueAt { get; set; }
        [JsonProperty("duration")]
        public int? Duration { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("created_at")]
        public int? CreateAt { get; set; }
        [JsonProperty("completed_at")]
        public int? CompletedAt { get; set; }
    }
}