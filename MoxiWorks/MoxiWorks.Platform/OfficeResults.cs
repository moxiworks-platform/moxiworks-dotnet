using System.Collections.Generic;
using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    public class OfficeResults
    {
        [JsonProperty("page_number")]
        public int? PageNumber { get; set; } = 1;
        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; } = 1;
        [JsonProperty("offices")]
        public List<Office>Offices { get; set; } = new List<Office>();

    }
}