using Newtonsoft.Json;

namespace MoxiWorks.Platform

{
    public class Office
    {
        
        [JsonProperty("moxi_works_office_id")]
        public string MoxiWorksOfficeId { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("address2")]
        public string Address2 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("county")]
        public string Country { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }
        [JsonProperty("alt_phone")]
        public string AltPhone { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("facebook")]
        public string Facebook { get; set; }
        [JsonProperty("google_plus")]
        public string GooglePluse { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        [JsonProperty("twitter")]
        public string Twitter { get; set; }
        
    }
}