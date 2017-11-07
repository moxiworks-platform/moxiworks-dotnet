using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoxiWorks.Platform
{

    /// <summary>
    /// Entity for Handling errors returned from the Moxi Works API platfrom.
    /// </summary>
    public class MoxiWorksError
    {
        /// <summary>
        /// The http status code of the associated interaction
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// The messages returned from teh API 
        /// </summary>
        [JsonProperty("messages")]
        public List<string> Messages { get; set; } = new List<string>(); 
        /// <summary>
        /// The error code returned from the API.
        /// </summary>
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
    }
}