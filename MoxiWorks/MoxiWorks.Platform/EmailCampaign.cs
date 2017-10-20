using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    public class EmailCampaign
    {
        /// <summary>
        /// This is the Moxi Works Platform ID of the Agent which this EmailCampaign 
        /// is associated with. This will be an RFC 4122 compliant UUID.
        /// </summary>
        [JsonProperty("agent_uuid")]
        public string AgentUuid { get; set; }
        /// <summary>
        /// This is the Moxi Works Platform ID of the Agent which this EmailCampaign is associated with. 
        /// This will be a string that may take the form of an email address, or a unique alphanumeric identification string.
        /// </summary>
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }
        
        /// <summary>
        /// A string representing the type of EmailSubscription is associated with the Contact 
        /// for the supplied partner_contact_id. This is a unique, internally defined string 
        /// per EmailSubscription type. Documentation of available subscription_type responses 
        /// is outside the scope of this documentation. If you need help determining available 
        /// types, contact your Moxi Works Platform representative.
        /// </summary>
        [JsonProperty("subscription_type")]
        public string SubscriptionType { get; set; }
        /// <summary>
        /// The email address for the EmailSubscription.
        /// </summary>
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
        /// <summary>
        /// Unix timestamp representing when the EmailSubscription that is associated 
        /// with the Contact for the supplied partner_contact_id was initiated.
        /// </summary>
        [JsonProperty("subscribed_at")]
        public int? SubscribedAt { get; set; }
        /// <summary>
        /// This is a string representing the actor responsible 
        /// for the subscription initiation.
        /// </summary>
        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }
        /// <summary>
        /// A string representing a geographic area that the EmailSubscription regards.
        /// </summary>
        [JsonProperty("area")]
        public string Area { get; set; }
        /// <summary>
        /// This is a Unix timestamp representing the point in time that the last 
        /// EmailSubscription message was sent.
        /// </summary>
        [JsonProperty("last_sent")]
        public int? LastSent { get; set; } 
        /// <summary>
        /// This is a Unix timestamp representing the point in time that the next 
        /// EmailSubscription message will be sent.
        /// </summary>
        [JsonProperty("next_scheduled")]
        public int? NextScheduled { get; set; }
    }
}