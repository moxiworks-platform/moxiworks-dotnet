using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    /// <summary>
    /// Other offices associated with an Agent
    /// </summary>
    public class AlternateOffice
    {
        /// <summary>
        /// This is the unique identifier for the Moxi Works Platform AlternateOffice entry.
        /// </summary>
        [JsonProperty("moxi_works_office_id")]
        public string MoxiWorksOfficeId { get; set; }
        /// <summary>
        /// This is an integer identifier for the Moxi Works Platform AlternateOffice entry.
        /// If you are using Moxi Works SSO, this will be the ID corresponding to the
        /// ID provided there.
        /// </summary>
        [JsonProperty("office_id")]
        public int? OfficeId { get; set; }
        /// <summary>
        /// The street address of the office represented by this AlternateOffice entry.
        /// </summary>
        [JsonProperty("office_address_street")]
        public string Street { get; set; }
        /// <summary>
        /// The second line of the street address (if required) of the office
        /// represented by this AlternateOffice entry.
        /// </summary>
        [JsonProperty("office_address_street2")]
        public string Street2 { get; set; }
        /// <summary>
        /// The city portion of the address of the office represented by this AlternateOffice entry.
        /// </summary>
        [JsonProperty("office_address_city")]
        public string City { get; set; }
        /// <summary>
        /// The state portion of the address of the office represented by this AlternateOffice entry.
        /// </summary>
        [JsonProperty("office_address_state")]
        public string State { get; set; }
        /// <summary>
        /// The state portion of the address of the office represented by this AlternateOffice entry.
        /// </summary>
        [JsonProperty("office_address_zip")]
        public string Zip { get; set; }
        /// <summary>
        /// The postal code portion of the address of the office represented by this AlternateOffice entry.
        /// </summary>
        [JsonProperty("office_phone_number")]
        public string Phone { get; set; }
    }
}