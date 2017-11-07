using System.Collections.Generic;
using Newtonsoft.Json; 
namespace MoxiWorks.Platform
{
    /// <summary>
    /// Container for returning Multiple agents. 
    /// </summary>
    public class AgentResults
    {
        /// <summary>
        /// Total number of pages avaliable. 
        /// </summary>
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        /// <summary>
        /// Current page requiested.
        /// </summary>
        [JsonProperty("page_number")]
        public int PageNumber { get; set; }

        /// <summary>
        /// The agents array contains List of Agent entries. 
        /// </summary>
        public List<Agent> Agents { get; set; } = new List<Agent>();
    }
}