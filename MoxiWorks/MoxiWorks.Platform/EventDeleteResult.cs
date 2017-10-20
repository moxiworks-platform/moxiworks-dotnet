using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    public class EventDeleteResult
    {
        /// <summary>
        /// This indicates whether the request was successfully processed.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// This is the result of the action – whether the Eventobject was actually deleted.
        /// </summary>
        [JsonProperty("deleted")] 
        public bool Deleted { get; set; }    
    }
}