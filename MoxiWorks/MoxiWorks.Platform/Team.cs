using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    public class Team
    {
        
        /// <summary>
        /// This is the Moxi Works Platform ID of the Team. This will be an RFC 4122 compliant UUID.
        /// </summary>
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
        /// <summary>
        /// The name of the team. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// This is the team’s main email address. This email address should
        /// be considered the email address the team would prefer to be contacted by.
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("email")]
        public string Email {get; set; }
        /// <summary>
        /// The street address of the team. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("address1")]
        public string Address1 { get; set;}
        /// <summary>
        /// The suite or team number of the team. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("address2")]
        public string Address2 { get; set; }
        /// <summary>
        /// The city the team is in. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("city")]
        public string City {get; set; }
        /// <summary>
        /// The postal code the team is in. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("zipcode")]
        public string ZipCode { get; set; }
        /// <summary>
        /// The state or provice the team is in. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }   
        /// <summary>
        /// This is the team’s main phone number. This number should be
        /// considered the number the team would prefer to be contacted by.
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }
        /// <summary>
        /// This is the team’s fax phone number.
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("fax")]
        public string Fax { get; set; }
        /// <summary>
        /// URL to an logo for the team. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("logo_url")]
        public string LogoUrl { get; set; }
        /// <summary>
        /// URL to an image of the team. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("photo_url")]
        public string PhotoUrl { get; set;}
        /// <summary>
        /// Description of the team. This can contain embedded HTML tags. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// Alternate phone number for the team. This should be considered second in priority to Phone. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("alt_phone")]
        public string AltPhone { get; set; }
        /// <summary>
        /// Alternate phone number for the team. This should be considered second in priority to Email. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("alt_email")] 
        public string AltEmail { get; set; }
        /// <summary>
        /// Team’s website url. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("website_url")]
        public string WebSiteUrl { get; set; }
        /// <summary>
        /// Whether this team is active.
        /// </summary>
        [JsonProperty("active")]
        public bool? Actve { get; set; }
    }
}