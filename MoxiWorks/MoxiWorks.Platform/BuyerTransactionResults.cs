using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    public class BuyerTransactionResults
    {
        [JsonProperty("page_number")]
        public int? PageNumber { get; set; }
        
        [JsonProperty("total_pages")]
        public int? TotalPages { get; set; }
        
        [JsonProperty("transactions")]
        public List<BuyerTransaction> Transactions { get; set; } = new List<BuyerTransaction>();


    }
}