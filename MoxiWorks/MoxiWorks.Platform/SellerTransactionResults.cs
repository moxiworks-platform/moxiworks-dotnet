using System.Collections.Generic;
using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    public class SellerTransactionResults
    {
        [JsonProperty("page_number")]
        public int? PageNumber { get; set; }
        
        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }
        
        [JsonProperty("transactions")]
        public List<SellerTransaction> Transactions { get; set; } = new List<SellerTransaction>();


    }
}