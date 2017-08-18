using System.Collections.Generic;
using Newtonsoft.Json;


namespace MoxiWorks.Platform
{
    public class ContactResults
    {
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; } 
        [JsonProperty("page_number")]
        public int  PageNumber { get; set; }
        [JsonProperty("contacts")]
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}