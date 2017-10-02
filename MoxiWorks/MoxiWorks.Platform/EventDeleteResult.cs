using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    public class EventDeleteResult
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("deleted")] 
        public bool Deleted { get; set; }    
    }
}