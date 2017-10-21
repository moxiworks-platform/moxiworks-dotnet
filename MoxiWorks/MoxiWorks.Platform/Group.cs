using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    public class Group
    {
        /// <summary>
        /// This is the Moxi Works Platform ID of the Agent which this Group is associated with. 
        /// This will be an RFC 4122 compliant UUID.
        /// </summary>
        [JsonProperty("agent_uuid")]
        public string AgentUuId { get; set; }
        /// <summary>
        /// This is the Moxi Works Platform ID of the Agent which this Group is associated with. 
        /// This will be a string that may take the form of an email address, 
        /// or a unique alphanumeric identification string.
        /// </summary>
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }
        /// <summary>
        /// This is a human readable string meaningful to 
        /// the agent about what kind of Contact objects are in this Group.
        /// </summary>
        [JsonProperty("moxi_works_group_name")]
        public string MoxiWorksGroupName { get; set; }
        /// <summary>
        /// This is the unique identifier for this Group.
        /// </summary>
        [JsonProperty("moxi_works_group_id")]
        public string MoxiWorksGroupId { get; set; }
        /// <summary>
        /// Whether the group ID exists beyond name change.
        /// </summary>
        [JsonProperty("transient")]
        public bool?  Transient { get; set; }
        /// <summary>
        /// The page number of this response set.
        /// </summary>
        [JsonProperty("page_number")]
        public int? PageNumber { get; set; }
        /// <summary>
        /// The total number of pages in this response set.
        /// </summary>
        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }
        /// <summary>
        /// The Contact objects in this page.
        /// </summary>
        [JsonProperty("contacts")]
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}