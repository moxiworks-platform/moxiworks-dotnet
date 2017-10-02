using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    public class EmailCampaign
    {
        [JsonProperty("agent_uuid")]
        public string AgentUuid { get; set; }
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }
        [JsonProperty("subscription_type")]
        public string SubscriptionType { get; set; }
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
        [JsonProperty("subscribed_at")]
        public int? SubscribedAt { get; set; }
        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }
        [JsonProperty("area")]
        public string Area { get; set; }
        [JsonProperty("last_sent")]
        public int? LastSent { get; set; } 
        [JsonProperty("next_scheduled")]
        public int? NextScheduled { get; set; }
    }
}