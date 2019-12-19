using System.Collections.Generic;
using Newtonsoft.Json;


namespace MoxiWorks.Platform
{
    public class ListingUpdate
    {
        public ListingUpdate()
        {
            SharedPartnerData = new Dictionary<string, dynamic>();
        }
        /// <summary>
        /// This is the Moxi Works Platform ID of the Listing which you are requesting to Update.
        /// This data is required and must reference a valid Moxi Works Listing ID for your Update request to be accepted.
        ///</summary>
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
        
        /// <summary>
        /// Virtual tour URL for this listing.
        /// </summary>
        public string VirtualTourURL { get; set; }
        
        /// <summary>
        /// Partner specific listing information in a json formatted string.
        /// </summary>
        public IDictionary<string, dynamic> SharedPartnerData { get; set; }
    }

}