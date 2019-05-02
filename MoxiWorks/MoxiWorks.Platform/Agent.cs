﻿using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// The following object makes up the payload of the Agent response for a Show request.
    /// </summary>
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
        /// This is the ID of the Agent utilized by their primary MLS.
        /// </summary>
        [JsonProperty("mls_agent_id")]
        public string MlsAgentId { get; set; }
        /// <summary>
        /// This is the number of the license granted to the agent.
        /// </summary>
        [JsonProperty("license")]
        public string License { get; set; }
        /// <summary>
        /// This is the name of the primary MLS for the agent.
        /// </summary>
        [JsonProperty("mls_name")]
        public string MlsName { get; set; }
        /// <summary>
        /// This is the standard abbreviation of the primary MLS utilized by the agent.
        /// </summary>
        [JsonProperty("mls_abbreviation")]
        public string MlsAbbreviation { get; set; }
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
        /// <summary>
        /// The city the agent’s office is in. This can be null if there is no data 
        /// for this attribute.
        /// </summary>
        [JsonProperty("office_address_city")]
        public string OfficeAddressCity { get; set; }
        /// <summary>
        /// The state or provice the agent’s office is in. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("office_address_state")]
        public string OfficeAddressState { get; set; }
        /// <summary>
        /// The postal code the agent’s office is in. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("office_address_zip")]
        public string OfficeAddressZip { get; set; }
        /// <summary>
        /// The full name of the agent. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The first name of the agent. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// The last name of the agent. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// The nickname of the agent.
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; }
        /// <summary>
        /// This is the agent’s main phone number. 
        /// This number should be considered the number the agent would like to be contacted by.
        ///  This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("main_phone_number")]
        public string MainPhoneNumber { get; set; }
        /// <summary>
        /// Mobile phone number of the agent. 
        /// main_phone_number should be considered higher priority, 
        /// if not the same. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("mobile_phone_number")]
        public string MobilePhoneNumber { get; set; }
        /// <summary>
        /// Alternate phone number for the agent. 
        /// This should be considered second in priority to main_phone_number. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("alt_phone_number")]
        public string AltPhoneNumber { get; set; }
        /// <summary>
        /// This is the agent’s fax phone number. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("fax_phone_number")]
        public string FaxPhoneNumber { get; set; }
        /// <summary>
        /// This is the agent’s office phone number. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("office_phone_number")]
        public string OfficePhoneNumber { get; set; }
        /// <summary>
        /// This is the agent’s main email address. 
        /// This email address should be considered the email address 
        /// the agent would prefer to be contacted by. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("primary_email_address")]
        public string PrimaryEmailAddress { get; set; }
        /// <summary>
        /// This is the agent’s alternate email address. 
        /// This email address should be considered the email address the agent would want to
        ///  be contacted by only if the address in primary_email_address is not functional. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("secondary_email_address")]
        public string SecondaryEmailAddress { get; set; }
        /// <summary>
        /// This is the agent’s lead routing email address. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("lead_routing_email_address")]
        public string LeadRoutingEmailAddress { get; set; }
        /// <summary>
        /// This is the business title of the agent. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// This is an RFC 4122 compliant UUID associated with the agent. 
        /// This UUID can be used as a unique identifier in determining 
        /// associations between Agent objects and Listing objects.
        /// </summary>
        [JsonProperty("uuid")]
        public string Uuid { get; set; }
        /// <summary>
        /// Indicates whether the agent has access to MoxiWorks Products.
        /// </summary>
        [JsonProperty("has_product_access")]
        public bool? HasProductAccess { get; set; }
        /// <summary>
        /// Indicates whether the agent has access to Moxiworks Engage.
        /// </summary>
        [JsonProperty("has_engage_access")]
        public bool HasEngageAccess { get; set; }
        /// <summary>
        /// The access level of the agent.
        /// </summary>
        [JsonProperty("access_level")]
        public string AccessLevel { get; set; }
        /// <summary>
        /// Agent’s Twitter account name. 
        /// This can be null if there is no data available for this attribute.
        /// </summary>
        [JsonProperty("twitter")]
        public string Twitter { get; set; }
        /// <summary>
        /// Agent’s Google Plus account name. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("google_plus")]
        public string GooglePlus { get; set; }
        /// <summary>
        /// Agent’s Facebook page url. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("facebook")]
        public string Facebook { get; set; }
        /// <summary>
        /// Agent’s website domain. This will be returned without the HTTP(S) prefix. 
        /// You’ll need to prefix the domain with protocol if using this attribute for an href. 
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("home_page")]
        public string HomePage { get; set; }
        /// <summary>
        /// This is a valid URL for a larger size image for the agent. 
        /// If no agent image has been uploaded for this agent a default image url will be provided.
        /// </summary>
        [JsonProperty("profile_image_url")]
        public string ProfileImageUrl { get; set; }
        /// <summary>
        /// This is a valid URL for a thumbnail size image for the agent. 
        /// If no agent image has been uploaded for this agent a default image url will be provided.
        /// </summary>
        [JsonProperty("profile_thumb_url")]
        public string ProfileThumbUrl { get; set; }
        /// <summary>
        /// The region the agent’s office is in.
        /// This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }
        /// <summary>
        /// The agent’s stated gross commission income goal.
        /// </summary>
        [JsonProperty("gci_goal")]
        public int? GciGoal { get; set; }
        /// <summary>
        /// Percentage commission rate for the agent when acting as a buyer’s agent.
        /// </summary>
        [JsonProperty("buyer_commission_rate")]
        public float? BuyerCommissionRate { get; set; }
        /// <summary>
        /// Percentage commission rate for the agent when acting as a seller’s agent.
        /// </summary>
        [JsonProperty("seller_commission_rate")]
        public float? SellerCommissionRate { get; set; }
        /// <summary>
        /// AlternateOffices contains a collection of objects representing AlternateOffice entries. 
        /// </summary>
        [JsonProperty("alternate_offices")]
        public List<AlternateOffice> AlternateOffices { get; set; }
        /// <summary>
        /// The AvailableMls collection contains objects representing MlsEntries.
        /// </summary>
        [JsonProperty("available_mls")]
        public List<MlsEntry> AvailableMls { get; set; }
        /// <summary>
        /// Date the agent was created
        /// </summary>
        [JsonProperty("created_timestamp")]
        public int? CreatedTimestamp { get; set; }
        /// <summary>
        /// Date the agent was deactivated
        /// </summary>
        [JsonProperty("deactivated_timestamp")]
        public int? DeactivatedTimestamp { get; set; }
    }
}