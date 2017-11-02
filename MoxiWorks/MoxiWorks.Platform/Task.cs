using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    public class Task
    {
        
        /// <summary>
        /// This is the Moxi Works Platform ID of the Agent which an Task entry is associated with. This will be an 
        /// RFC 4122 compliant UUID. agent_uuid or moxi_works_agent_id is required and must reference a valid 
        /// Moxi Works Agent ID for your Task Create request to be accepted.
        /// </summary>
        [JsonProperty("agent_uuid")]
        public string AgentUuId { get; set; }
        /// <summary>
        /// This is the Moxi Works Platform ID of the Agent which this Task object is to be associated with. 
        /// This will be a string that may take the form of an email address, or a unique identification string. 
        /// This data is required and must reference a valid Moxi Works Agent ID for your Task Create request to 
        /// be accepted.
        /// </summary>
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }
        /// <summary>
        /// This is the unique identifer you use in your system that has been associated with the Contact 
        /// that this Task regards.
        /// </summary>
        [JsonProperty("partner_contact_id")]
        public string PartnerContactId { get; set; }
        /// <summary>
        /// This is the unique identifer you use in your system that will be associated with the 
        /// Task that you are creating. This data is required and must be a unique ID for your Task Create 
        /// request to be accepted.
        /// </summary>
        [JsonProperty("partner_task_id")]
        public string PartnerTaskId { get; set; }
        /// <summary>
        /// A brief, human readable title that will be shown to the agent as the subject of the Task that 
        /// you are creating.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// Brief, human readable content that will be shown to the agent as the body of the Task that you are creating.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// A Unix timestamp representing the point in time when the task associated with this Task object 
        /// should be completed by.
        /// </summary>
        [JsonProperty("due_at")]
        public int? DueAt { get; set; }
        /// <summary>
        /// The timespan (in minutes) that the task for this Task object is expected to take.
        /// </summary>
        [JsonProperty("duration")]
        public int? Duration { get; set; }
        /// <summary>
        /// Status of the task.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// A Unix timestamp representing the point in time when the Task object was created.
        /// </summary>
        [JsonProperty("created_at")]
        public int? CreateAt { get; set; }
        /// <summary>
        /// A Unix timestamp representing the point in time when the task for this Task object was completed. 
        /// This should be null if the task has not yet been completed.
        /// </summary>
        [JsonProperty("completed_at")]
        public int? CompletedAt { get; set; }
    }
}