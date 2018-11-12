using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Moxi Works Platform Contact entities represent an agent’s contacts in the Moxi Works Platform.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// This is the Moxi Works Platform ID of the Agent which an Contact entry 
        /// is associated with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your Contact Update request to be accepted.
        /// </summary>
        [JsonProperty("agent_uuid")]
        public string AgentUuid { get; set; }
        /// <summary>
        /// This is the Moxi Works Platform ID of the Agent which this Contact entry is to be 
        /// associated with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. This data is required and must reference a 
        /// valid Moxi Works Agent ID for your Contact Update request to be accepted.
        /// </summary>
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }
        /// <summary>
        /// This is the unique identifier you use in your system that has been associated with 
        /// the Contact that you are creating.
        /// </summary>
        [JsonProperty("partner_contact_id")]
        public string PartnerContactId { get; set; }
        /// <summary>
        /// This is the full name of the contact you are creating a Contact record for. 
        /// You should format this information as first middle last.
        /// </summary>
        [JsonProperty("contact_name")]
        public string ContactName { get; set; }
        /// <summary>
        /// The gender of the contact. This can be male, female, m or f.
        ///  No matter what is provided in the request, the response payload will return m or f.
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }
        /// <summary>
        /// This is the email address that should be used first. 
        /// If provided, the address must conform to RFC 3696.
        /// </summary>
        [JsonProperty("primary_email_address")]
        public string PrimaryEmailAddress { get; set; }
        /// <summary>
        /// This is the email address that should be used as an alternate. 
        /// If provided, the address must conform to RFC 3696.
        /// </summary>
        [JsonProperty("secondary_email_address")]
        public string SecondaryEmailAddress { get; set; }
        /// <summary>
        ///  This is the phone number that should be used first. 
        /// </summary>
        [JsonProperty("primary_phone_number")]
        public string PrimaryPhoneNumber { get; set; }
        /// <summary>
        /// This is the phone number that should be used as an alternate. 
        /// </summary>
        [JsonProperty("secondary_phone_number")]
        public string SecondaryPhoneNumber { get; set; }
        /// <summary>
        /// The contact’s home address street, including number and any 
        /// suite / apartment number information.
        /// </summary>
        [JsonProperty("home_street_address")]
        public string HomeStreetAddress { get; set; }
        /// <summary>
        /// The city of the contact’s home address.
        /// </summary>
        [JsonProperty("home_city")]
        public string HomeCity { get; set; }
        /// <summary>
        /// The state of the contact’s home address.
        /// </summary>
        [JsonProperty("home_state")]
        public string HomeState { get; set; }
        /// <summary>
        /// The zip code of the contact’s home address.
        /// </summary>
        [JsonProperty("home_zip")]
        public string HomeZip { get; set; }
        /// <summary>
        /// The country of the contact’s home address.
        /// </summary>
        [JsonProperty("home_country")]
        public string HomeCountry { get; set; }
        
        [JsonProperty("is_not_lead")]
        public bool IsNotLead { get; set; }
        /// <summary>
        /// The contact’s professional job title.
        /// </summary>
        [JsonProperty("job_title")]
        public string JobTitle { get; set; }
        /// <summary>
        /// The contact’s profession.
        /// </summary>
        [JsonProperty("occupation")]
        public string Occupation { get; set; }
        /// <summary>
        /// This should be a valid URL for a property of interest in your system that can
        ///  be viewed by the agent.
        /// </summary>
        [JsonProperty("property_url")]
        public string PropertyUrl { get; set; }
        /// <summary>
        /// Use this if you have data about a property that this contact has shown interest 
        /// in (property of interest); this should be the MLS ID of the property of interest.
        /// </summary>
        [JsonProperty("property_mls_id")]
        public string PropertyMlsId { get; set; }
        /// <summary>
        /// Use this if you have data about a property that this contact has shown interest 
        /// in (property of interest); this should be the street address of the property of interest, including number and suite/apartment number information.
        /// </summary>
        [JsonProperty("property_street_address")]
        public string PropertyStreetAddress { get; set; }
        /// <summary>
        /// Use this if you have data about a property that this contact has shown interest in 
        /// (property of interest); this should be the city in which the property of 
        /// interest exists.
        /// </summary>
        [JsonProperty("property_city")]
        public string PropertyCity { get; set; }
        /// <summary>
        /// Use this if you have data about a property that this contact has shown interest in 
        /// (property of interest); this should be the state or province in which the property 
        /// of interest exists.
        /// </summary>
        [JsonProperty("property_state")]
        public string PropertyState { get; set; }
        /// <summary>
        /// Use this if you have data about a property that this contact has shown interest in 
        /// (property of interest); this should be the postal code in which the property of 
        /// interest exists.
        /// </summary>
        [JsonProperty("property_zip")]
        public string PropertyZip{ get; set; }   
        /// <summary>
        /// Use this if you have data about a property that this contact has shown interest in 
        /// (property of interest); this should be the number of bedrooms in the property of interest.
        /// </summary>
        [JsonProperty("property_beds")]
        public int? PropertyBeds{ get; set; }
        /// <summary>
        /// Use this if you have data about a property that this contact has shown interest in 
        /// (property of interest); this should be the number of bathrooms in the property of 
        /// interest.
        /// </summary>
        [JsonProperty("property_baths")]
        public string  PropertyBaths{ get; set; } 
        /// <summary>
        /// Use this if you have data about a property that this contact has shown interest in 
        /// (property of interest); this should be the list price of the property of interest.
        /// </summary>
        [JsonProperty("property_list_price")]
        public string PropertyListPrice{ get; set; }
        /// <summary>
        /// Use this if you have data about a property that this contact has shown interest in 
        /// (property of interest); this should be the listing status of the property of interest. 
        /// This can be any arbitrary string, but for best results, this should be a state like 
        /// Active, Pending, Sold, Cancelled or any other human readable state that would be 
        /// useful when presented to the agent.
        /// </summary>
        [JsonProperty("property_listing_status")]
        public string PropertyListingStatus{ get; set; }   
        /// <summary>
        /// Use this if you have data about a property that this contact has shown interest in 
        /// (property of interest); this should be a valid URL to an image of the property of 
        /// interest.
        /// </summary>
        [JsonProperty("property_photo_url")]
        public string PropertyPhotoUrl{ get; set; }  
        /// <summary>
        /// Use this if you have data about listing searches that this contact has performed; 
        /// this should be the city / locale used in the listing search criteria.
        /// </summary>
        [JsonProperty("search_city")]
        public string SearchCity{ get; set; }
        /// <summary>
        /// Use this if you have data about listing searches that this contact has performed; 
        /// this should be the state / region used in the listing search criteria.
        /// </summary>
        [JsonProperty("search_state")]
        public string SearchState{ get; set; }  
        /// <summary>
        /// Use this if you have data about listing searches that this contact has performed; 
        /// this should be the zip / postal code used in the listing search criteria.
        /// </summary>
        [JsonProperty("search_zip")]
        public string SearchZip{ get; set; }
        /// <summary>
        /// Use this if you have data about listing searches that this contact has performed; 
        /// this should be the minimum bathrooms used in the listing search criteria.
        /// </summary>
        [JsonProperty("search_min_baths")]
        public string SearchMinBaths{ get; set; }
        /// <summary>
        /// Use this if you have data about listing searches that this contact has performed; 
        /// this should be the minimum bedrooms used in the listing search criteria.
        /// </summary>
        [JsonProperty("search_min_beds")]
        public int? SearchMinBeds{ get; set; }  
        /// <summary>
        /// Use this if you have data about listing searches that this contact has performed; 
        /// this should be the minimum price used in the listing search criteria.
        /// </summary>
        [JsonProperty("search_min_price")]
        public int?  SearchMinPrice{ get; set; }
        /// <summary>
        /// Use this if you have data about listing searches that this contact has performed; 
        /// this should be the maximum price used in the listing search criteria.
        /// </summary>
        [JsonProperty("search_max_price")]
        public int?  SearchMaxPrice{ get; set; } 
        /// <summary>
        /// Use this if you have data about listing searches that this contact has performed; 
        /// this should be the minimum square feet of the total living area used in the listing search criteria.
        /// </summary>
        [JsonProperty("search_min_sq_ft")]
        public int? SearchMinSqFt{ get; set; } 
        /// <summary>
        /// Use this if you have data about listing searches that this contact has performed; 
        /// this should be the maximum square feet of the total living area used in the listing 
        /// search criteria.
        /// </summary>
        [JsonProperty("search_max_sq_ft")]
        public int?  SearchMaxSqFt { get; set; } 
        /// <summary>
        /// Use this if you have data about listing searches that this contact has performed; 
        /// this should be the minimum lot size used in the listing search criteria.
        /// </summary>
        [JsonProperty("search_min_lot_size")]
        public int? SearchMinLotSize{ get; set; }  
        /// <summary>
        /// Use this if you have data about listing searches that this contact has performed; 
        /// this should be the maximum lot size used in the listing search criteria.
        /// </summary>
        [JsonProperty("search_max_lot_size")]
        public int?  SearchMaxLotSize{ get; set; }   
        /// <summary>
        /// Use this if you have data about listing searches that this contact has performed; 
        /// this should be the minimum allowable year built used in the listing search criteria.
        /// </summary>
        [JsonProperty("search_min_year_built")]
        public string SearchMinYearBuilt{ get; set; }

        /// <summary>
        /// Use this if you have data about listing searches that this contact has performed; 
        /// this should be the minimum allowable year built used in the listing search criteria.
        /// </summary>
        [JsonProperty("search_max_year_built")]
        public string SearchMaxYearBuilt { get; set; }
        /// <summary>
        /// Use this if you have data about listing searches that this contact has performed; this should be the property types used in the listing search criteria. This can be any arbitrary human readable string, but using recognized property types such as Condo, Single-Family, Townhouse, Land, Multifamily will provide more value to the agent.
        /// </summary>
        [JsonProperty("search_property_types")]
        public string SearchPropertyTypes { get; set; }   
        /// <summary>
        /// This is an arbitrary string giving the agent more details about the contact which 
        /// would not otherwise fit into the Contact record. Any HTML formatting included will 
        /// be stripped from the note attribute’s data.
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; set; }
        
        /// <summary>
        /// comma separated string of category names 
        /// </summary>
        [JsonProperty("category_names")]
        public string CategoryNames { get; set; }
    }
}