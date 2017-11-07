using System.Collections.Generic;
using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    /// <summary>
    /// Container for returning a SellerTransaction Collection. 
    /// </summary>
    public class SellerTransactionResults
    {
        /// <summary>
        /// If there is more than one page of SellerTransaction objects to return, page_number will denote which page 
        /// of responses has been returned. If this is less than the value of total_pages, there are more pages that 
        /// can be returned by including the page_number parameter in your API request.
        /// </summary>
        [JsonProperty("page_number")]
        public int? PageNumber { get; set; }
        /// <summary>
        /// If there is more than one page of SellerTransaction objects to return, total_pages will denote how many 
        /// pages of SellerTransaction objects there are to be returned fo the current query. Subsequent pages can 
        /// be returned by including the page_number parameter in your API request.
        /// </summary>
        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }
        
        /// <summary>
        /// This list contains the payload from the request query. Any found SellerTransaction objects matching the 
        /// query will be returned as SellerTransaction objects in the response.
        /// </summary>
        [JsonProperty("transactions")]
        public List<SellerTransaction> Transactions { get; set; } = new List<SellerTransaction>();

    }
}