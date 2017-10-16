using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    public class Agent
    {
        /// <summary>
        /// This is the Moxi Works Platform ID of the Agent. This will be a string that may take the form 
        /// of an email address, or a unique alphanumeric identification string.
        /// </summary>
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }
        /// <summary>
        /// This is the ID of the Agent utilized by their company.
        /// </summary>
        [JsonProperty("client_agent_id")]
        public string ClientAgentId { get; set; }
        /// <summary>
        /// This is the ID of this Agent. This will be an integer.
        /// </summary>
        [JsonProperty("agent_id")]
        public string AgentId { get; set; }
        /// <summary>
        /// This is the Moxi Works Platform ID of the office for this Agent. This will be an RFC 4122 compliant UUID.
        /// </summary>
        [JsonProperty("moxi_works_office_id")]
        public string MoxiWorksOfficeId { get; set; }
        /// <summary>
        /// This is the ID of the office for this Agent. This will be an integer.
        /// </summary>
        [JsonProperty("office_id")]
        public string OfficeId { get; set; }
        /// <summary>
        /// This is the ID of the office for this Agent utilized by their company.
        /// </summary>
        [JsonProperty("client_office_id")]
        public string ClientOfficeId { get; set; }
        /// <summary>
        /// This is the ID of the company for this Agent.This will be an integer.
        /// </summary>
        [JsonProperty("company_id")]
        public string CompanyId { get; set; }
        /// <summary>
        /// This is the ID of the Company utilized by their company.
        /// </summary>
        [JsonProperty("client_company_id")]
        public string ClientCompanyId { get; set; }
        /// <summary>
        /// The street address of the agent’s office. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("office_address_street")]
        public string OfficeAddressStreet { get; set; }
        /// <summary>
        /// The suite or office number of the agent’s office.This can be null 
        ///if there is no data for this attribute. 
        /// </summary>
        [JsonProperty("office_address_street2")]
        public string OfficeAddressStreet2 { get; set; }  
        [JsonProperty("office_address_city")]
        public string OfficeAddressCity { get; set; }
        [JsonProperty("office_address_state")]
        public string OfficeAddressState { get; set; }
        [JsonProperty("office_address_zip")]
        public string OfficeAddressZip { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("main_phone_number")]
        public string MainPhoneNumber { get; set; }
        [JsonProperty("mobile_phone_number")]
        public string MobilePhoneNumber { get; set; }
        [JsonProperty("alt_phone_number")]
        public string AltPhoneNumber { get; set; }
        [JsonProperty("fax_phone_number")]
        public string FaxPhoneNumber { get; set; }
        [JsonProperty("office_phone_number")]
        public string OfficePhoneNumber { get; set; }
        [JsonProperty("primary_email_address")]
        public string PrimaryEmailAddress { get; set; }
        [JsonProperty("secondary_email_address")]
        public string SecondaryEmailAddress { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
        [JsonProperty("twitter")]
        public string Twitter { get; set; }
        [JsonProperty("google_plus")]
        public string GooglePlus { get; set; }
        [JsonProperty("facebook")]
        public string Facebook { get; set; }
        [JsonProperty("home_page")]
        public string HomePage { get; set; }
        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }
        [JsonProperty("profile_thumb_url")]
        public string ProfileThumbUrl { get; set; }
        [JsonProperty("alternate_offices")]
        public List<Office>  AlternateOffices { get; set; }
    }
}