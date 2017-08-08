using System.Collections.Generic;
using Newtonsoft.Json; 
namespace MoxiWorks.Platform
{
    public class AgentResults
    {
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        [JsonProperty("page_number")]
        public int PageNumber { get; set; }

        public List<Agent> Agents { get; set; } = new List<Agent>();
    }
}