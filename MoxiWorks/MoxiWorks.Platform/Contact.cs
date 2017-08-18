using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    public class Contact
    {
        [JsonProperty("agent_uuid")]
        public string AgentUuid { get; set; }
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }
        [JsonProperty("partner_contact_id")]
        public string PartnerContactId { get; set; }
        [JsonProperty("contact_name")]
        public string ContactName { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("primary_email_address")]
        public string PrimaryEmailAddress { get; set; }
        [JsonProperty("secondary_email_address")]
        public string SecondaryEmailAddress { get; set; }
        [JsonProperty("primary_phone_number")]
        public string PrimaryPhoneNumber { get; set; }
        [JsonProperty("secondary_phone_number")]
        public string SecondaryPhoneNumber { get; set; }
        [JsonProperty("home_street_address")]
        public string HomeStreetAddress { get; set; }
        [JsonProperty("home_city")]
        public string HomeCity { get; set; }
        [JsonProperty("home_state")]
        public string HomeState { get; set; }
        [JsonProperty("home_zip")]
        public string HomeZip { get; set; }
        [JsonProperty("home_country")]
        public string HomeCountry { get; set; }
        [JsonProperty("is_not_lead")]
        public bool IsNotLead { get; set; }
        [JsonProperty("job_title")]
        public string JobTitle { get; set; }
        [JsonProperty("occupation")]
        public string Occuparion { get; set; }
        [JsonProperty("property_url")]
        public string PropertyUrl { get; set; }
        [JsonProperty("property_mls_id")]
        public string PropertyMlsId { get; set; }
        [JsonProperty("property_street_address")]
        public string PropertyStreetAddress { get; set; }
        [JsonProperty("property_city")]
        public string PropertyCity { get; set; }
        [JsonProperty("property_state")]
        public string PropertyState { get; set; }
        [JsonProperty("property_zip")]
        public string PropertyZip{ get; set; }   
        [JsonProperty("property_beds")]
        public int PropertyBeds{ get; set; }   
        [JsonProperty("property_baths")]
        public int  PropertyBaths{ get; set; }   
        [JsonProperty("property_list_price")]
        public string PropertyListPrice{ get; set; }   
        [JsonProperty("property_listing_status")]
        public string PropertyListingStatus{ get; set; }   
        [JsonProperty("property_photo_url")]
        public string PropertyPhotoUrl{ get; set; }   
        [JsonProperty("search_city")]
        public string SearchCity{ get; set; }   
        [JsonProperty("search_state")]
        public string SearchState{ get; set; }   
        [JsonProperty("search_zip")]
        public string SearchZip{ get; set; }   
        [JsonProperty("search_min_baths")]
        public int SearchMinBaths{ get; set; }   
        [JsonProperty("search_min_beds")]
        public int SearchMinBeds{ get; set; }   
        [JsonProperty("search_min_price")]
        public int  SearchMinPrice{ get; set; }   
        [JsonProperty("search_max_price")]
        public int  SearchMaxPrice{ get; set; }   
        [JsonProperty("search_min_sq_ft")]
        public int SearchMinSqFt{ get; set; }   
        [JsonProperty("search_max_sq_ft")]
        public int  SearchMaxSqFt { get; set; }   
        [JsonProperty("search_min_lot_size")]
        public int SearchMinLotSize{ get; set; }   
        [JsonProperty("search_max_lot_size")]
        public int  SearchMaxLotSize{ get; set; }   
        [JsonProperty("search_min_year_built")]
        public string SearchMinYearBuilt{ get; set; }   
        [JsonProperty("search_max_year_built")]
        public string SearchMaxYearBuilt{ get; set; }   
        [JsonProperty("search_property_types")]
        public string SearchPropertyTypes { get; set; }   
        [JsonProperty("note")]
        public string Note { get; set; }
    }
}