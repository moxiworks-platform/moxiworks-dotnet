using System.Collections.Generic;
using Newtonsoft.Json;


namespace MoxiWorks.Platform
{
    public class ContactResults
    {
        
        /// <summary>
        /// If there is more than one page of Contact objects to return, 
        /// total_pages will denote how many pages of Contact objects there are to be returned 
        /// for the current query. Subsequent pages can be returned by including the 
        /// page_number parameter in your API request.
        /// </summary>
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; } 
        /// <summary>
        /// If there is more than one page of Contact objects to return, 
        /// page_number will denote which page of responses has been returned. 
        /// If this is less than the value of total_pages, 
        /// there are more pages that can be returned by including the page_number parameter 
        /// in your API request.
        /// </summary>
        [JsonProperty("page_number")]
        public int  PageNumber { get; set; }
        
        /// <summary>
        /// This List contains the payload from the request query. 
        /// Any found Contact objects matching the query will be returned as 
        /// Contact objects in the response.
        /// </summary>
        [JsonProperty("contacts")]
        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}