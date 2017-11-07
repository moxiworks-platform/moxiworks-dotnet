using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Container for returning Multiple BuyerTransactions. 
    /// </summary>
    public class BuyerTransactionResults
    {
        /// <summary>
        /// If there is more than one page of BuyerTransaction objects to return, 
        /// page_number will denote which page of responses has been returned. 
        /// If this is less than the value of total_pages, 
        /// there are more pages that can be returned by including the page_number parameter 
        /// in your API request.
        /// </summary>
        [JsonProperty("page_number")]
        public int? PageNumber { get; set; }
        
        /// <summary>
        /// If there is more than one page of BuyerTransaction objects to return, total_pages will 
        /// denote how many pages of BuyerTransaction objects there are to be returned 
        /// for the current query. Subsequent pages can be returned by including the 
        /// page_number parameter in your API request.
        /// </summary>
        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }
        
        /// <summary>
        /// This array contains the payload from the request query. 
        /// Any found BuyerTransaction objects matching the query will be returned as 
        /// BuyerTransaction objects in the response.
        /// </summary>
        [JsonProperty("transactions")]
        public List<BuyerTransaction> Transactions { get; set; } = new List<BuyerTransaction>();


    }
}