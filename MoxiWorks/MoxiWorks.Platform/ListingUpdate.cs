using Newtonsoft.Json;
using System.Collections.Generic;


namespace MoxiWorks.Platform
{
    public class ListingUpdate
    {
        [JsonProperty("moxi_works_listing_id")]   
        public string MoxWorksListingId { get; set; }
        [JsonProperty("moxi_works_company_id")]
        public string MoxiWorksCompanyId { get; set; }
        
        /// <summary>
        /// Virtual tour URL for this listing.
        /// </summary>
        public string VirtualTourURL { get; set; }
        
        /// <summary>
        /// Partner specific listing information in a json formatted string.
        /// </summary>
        public IDictionary<string, object> SharedPartnerData { get; set; }

        
    }

}