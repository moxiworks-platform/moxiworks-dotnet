using System.Collections.Generic;
using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    /// <summary>
    /// Container for returning a Task Collection. 
    /// </summary>
    public class TaskResponse
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
        ///  List of tasks 
        /// </summary>
        [JsonProperty("tasks")] 
        public List<Task> Tasks { get; set; } = new List<Task>(); 
    }
}