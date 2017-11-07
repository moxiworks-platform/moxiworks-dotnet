using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Moxi Works ActionLog entries record actions that contacts take that an agent might
    /// want to see to increase their effectivity. For example, if a contact sends an email 
    /// to an agent asking a question, Moxi Works ActionLog will record that interaction 
    /// and display it to the agent.
    /// </summary>
    public class ActionLog
    {
        /// <summary>
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry
        /// is associated with. This will be an RFC 4122 compliant UUID.
        /// </summary>
        [JsonProperty("agent_uuid")]
        public string AgentUuid { get; set; }
        /// <summary>
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry is associated with. 
        /// This will be a string that may take the form of an email address,
        /// or a unique identification string.
        /// </summary>
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }
        /// <summary>
        /// This is a human readable string which would be presented to the Agent as the content of the 
        /// ActionLog entry. This can be any arbitrary plain-text string which would be practical for 
        /// the agent to see in the history of events associated with a Contact. This should be the same 
        /// as the data sent in the body parameter of the ActionLog Create request.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }
        /// <summary>
        /// This is the unique identifer you use in your system that has been associated with the 
        /// Contact that you are creating an ActionLog entry about. You should have already created the 
        /// Contact record on the Moxi Works Platform using Contact Create
        /// </summary>
        [JsonProperty("moxi_works_contact_id")]
        public string MoxWorksContactId { get; set; }
        /// <summary>
        /// This is the Moxi Works Platform ID of the Contact that you are creating an ActionLog 
        /// entry about. This will be an RFC 4122 compliant UUID.
        /// </summary>
        [JsonProperty("partner_contact_id")]
        public string PartnerContactId { get; set; }
        /// <summary>
        /// This is the human readable plain-text string which will be presented to the Agent 
        /// as the heading of the ActionLog entry. This may be any short, descriptive sentence 
        /// which would be practical for the agent to see in the history of events associated with a Contact. 
        /// This should be the same as the data sent in the title parameter of the ActionLog Create request.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// This is the Unix timestamp for the creation time of the ActionLog entry.
        /// </summary>
        [JsonProperty("timestamp")]
        public int? TimeStamp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("log_data")]
        public Dictionary<string,string> LogData { get; set; } 
        
    }
}