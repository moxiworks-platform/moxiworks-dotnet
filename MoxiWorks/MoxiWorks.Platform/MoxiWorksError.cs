using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MoxiWorks.Platform
{
    public class MoxiWorksError
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("messages")]
        public List<string> Messages { get; set; } = new List<string>(); 
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
    }
}