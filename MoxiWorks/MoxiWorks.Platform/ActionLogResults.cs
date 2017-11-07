using System.Collections.Generic;
using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    /// <summary>
    /// A Result of an abbreviated collection of Action Logs (ActionLogIndexItems). 
    /// </summary>
    public class ActionLogResults
    {
        /// <summary>
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry is associated with. 
        /// This will be an RFC 4122 compliant UUID. agent_uuid or moxi_works_agent_id is required and 
        /// must reference a valid Moxi Works Agent ID for your ActionLog request to be accepted. 
        /// </summary>
        [JsonProperty("agent_uuid")]  
        public string AgentUuid { get; set; }
        /// <summary>
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry is associated with.
        /// This will be a string that may take the form of an email address, or a unique identification 
        /// string. Agent_uuid or moxi_works_agent_id is required and must reference a valid Moxi Works Agent ID
        /// for your ActionLog request to be accepted.
        /// </summary>
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }

        /// <summary>
        /// This is the Moxi Works Platform ID of the Contact which the ActionLog objects are associated with.
        /// This will be an RFC 4122 compliant UUID. This data is required and must reference a valid 
        /// Moxi Works Contact ID for your ActionLog Index request to be accepted. This is the same as 
        /// the moxi_works_contact_id attribute of the Contact response.
        /// </summary>
        [JsonProperty("moxi_works_contact_id")]
        public string MoxWorksContactId { get; set; }
        /// <summary>
        /// This is the unique identifer you use in your system that has been associated with the 
        /// Contact that you are creating an ActionLog entry about. You should have already created 
        /// the Contact record on the Moxi Works Platform using Contact Create before attempting to 
        /// use your system’s contact ID to show ActionLog entries for the Contact. Your request 
        /// will be rejected if the Contact record does not exist.
        /// </summary>
        [JsonProperty("partner_contact_id")]   
        public string PartnerContactId { get; set; }
        /// <summary>
        /// The actions array contains a list of ActionLogIndexItem  representing ActionLog entries.
        /// </summary>
        [JsonProperty("actions")]
        public List<ActionLogIndexItem> Actions { get; set; } = new List<ActionLogIndexItem>();
        
    }
}