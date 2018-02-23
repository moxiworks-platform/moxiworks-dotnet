using System.Collections.Generic;
using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    public class PresentationLogResults
    {

        /// <summary>
        /// For queries with multi-page responses, use the page_number parameter to return data for specific pages. Data for page 1 is returned if this parameter is not included. 
        /// </summary>
        [JsonProperty("page_number")]
        public int? PageNumber { get; set; } = 1;
        /// <summary>
        /// Use this parameter if total_pages indicates that there is more than one page of data available.
        /// </summary>
        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; } = 1;
        /// <summary>
        /// List of a PresentationLogs
        /// </summary>
        [JsonProperty("presentations")]
        public List<PresentationLog>PresentationLogs { get; set; } = new List<PresentationLog>();

        
    }
}