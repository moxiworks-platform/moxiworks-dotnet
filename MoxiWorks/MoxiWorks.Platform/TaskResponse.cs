using System.Collections.Generic;
using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    public class TaskResponse
    {
        [JsonProperty("page_number")]
        public int? PageNumber { get; set; } = 1;

        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; } = 1;

        [JsonProperty("tasks")] 
        public List<Task> Tasks { get; set; } = new List<Task>(); 

    }
}