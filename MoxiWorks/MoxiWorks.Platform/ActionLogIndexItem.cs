using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Entity to record actions that contacts take, that an agent might want to see. 
    /// </summary>
    public class ActionLogIndexItem
    {
        /// <summary>
        /// This is the unique identifier for the Moxi Works Platform 
        /// </summary>
        [JsonProperty("moxi_works_action_log_id")]
        public string MoxiWorksActionLogId { get; set; }  
        /// <summary>
        /// This is a string from an enumerated set representing the type of ActionLog entry this is. 
        /// The string should be formatted in lowercase with an underscore between each word. 
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        /// <summary>
        /// This is the Unix timestamp for the creation time of the ActionLog entry.
        /// </summary>
        [JsonProperty("timestamp")]
        public int? TimeStamp { get; set; }
        
        /// <summary>
        /// This is the payload data of the ActionLog entry. 
        /// The structure returned is dependent on the kind of ActionLog entry this is. 
        /// Use the type attribute to determine what the structure of the ActionLog entry is and how to handle it. 
        /// Details of various structures contained in ActionLog log_data is outside the scope of this documentation.
        /// </summary>
        [JsonProperty("log_data")]
        public Dictionary<string,object> LogData { get; set; } = new Dictionary<string,object>();
    }
}