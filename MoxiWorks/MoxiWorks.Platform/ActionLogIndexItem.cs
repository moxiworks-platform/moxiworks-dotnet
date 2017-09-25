using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace MoxiWorks.Platform
{
    public class ActionLogIndexItem
    {
        
        [JsonProperty("moxi_works_action_log_id")]
        public string MoxiWorksActionLogId { get; set; }  
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("timestamp")]
        public int? TimeStamp { get; set; }
        
        
        [JsonProperty("log_data")]
        public Dictionary<string,object> LogData { get; set; } = new Dictionary<string,object>();
    }
}