using System.Collections.Generic;
using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    public class GalleryResults
    {

        /// <summary>
        /// Total number of pages avaliable. 
        /// </summary>
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; } = 1;

        /// <summary>
        /// Current page requiested.
        /// </summary>
        [JsonProperty("page_number")]
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// The gallery array contains list of all image galleries for a listing. 
        /// </summary>
        [JsonProperty("galleries")]
        public List<Gallery> Galleries { get; set; } = new List<Gallery>();
    }
}