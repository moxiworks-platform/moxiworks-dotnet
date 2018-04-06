using Newtonsoft.Json;


namespace MoxiWorks.Platform
{
    public class ListingUpdate
    {
        [JsonProperty("moxi_works_listing_id")]   
        public string MoxWorksListingId { get; set; }
        [JsonProperty("moxi_works_company_id")]
        public string MoxiWorksCompanyId { get; set; }

        [JsonProperty("listing")]
        public ListingUpdatableData Listing { get; set; }
    }

}