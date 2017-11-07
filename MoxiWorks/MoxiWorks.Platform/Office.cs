using Newtonsoft.Json;

namespace MoxiWorks.Platform

{
    /// <summary>
    /// Office entities represent brokerage offices.
    /// </summary>
    public class Office
    {
        /// <summary>
        /// This is the Moxi Works Platform ID of the office for this Office. 
        /// This will be an RFC 4122 compliant UUID.
        /// </summary>
        [JsonProperty("moxi_works_office_id")]
        public string MoxiWorksOfficeId { get; set; }
        /// <summary>
        /// An alternate integer ID of the office. 
        /// If you are integrating with Moxi Works Authentication services, you should use this ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// URL to an image of the office. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The name of the office. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
        /// <summary>
        /// The street address of the office. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }
        /// <summary>
        /// The suite or office number of the office. This can be null 
        /// if there is no data for this attribute.
        /// </summary>
        [JsonProperty("address2")]
        public string Address2 { get; set; }
        /// <summary>
        /// The city the office is in. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }
        /// <summary>
        /// The county the office is in. This can be null if there is no data for this attribute
        /// </summary>
        [JsonProperty("county")]
        public string Country { get; set; }
        /// <summary>
        /// The state or provice the office is in. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }
        /// <summary>
        /// The postal code the office is in. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("zip_code")]
        public string ZipCode { get; set; }
        /// <summary>
        /// Alternate phone number for the office. This should be considered second in priority to phone_number. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("alt_phone")]
        public string AltPhone { get; set; }
        /// <summary>
        /// This is the office’s main email address. This email address should be considered the email address the office would prefer to be contacted by. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
        /// <summary>
        /// Office’s Facebook page url. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("facebook")]
        public string Facebook { get; set; }
        /// <summary>
        /// Office’s Google Plus account name. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("google_plus")]
        public string GooglePluse { get; set; }
        /// <summary>
        /// This is the office’s main phone number. This number should be considered the number the office would prefer to be contacted by. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }
        /// <summary>
        /// Timezone the office is in.
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        /// <summary>
        /// Office’s Twitter account name. This can be null if there is no data available for this attribute.
        /// </summary>
        [JsonProperty("twitter")]
        public string Twitter { get; set; }
        
    }
}