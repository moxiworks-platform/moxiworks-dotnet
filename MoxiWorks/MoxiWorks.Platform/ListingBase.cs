﻿using System;
using System.Collections.Generic;
using MoxiWorks.Platform.Serializers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoxiWorks.Platform
{
    public abstract class  ListingBase
    {
        /// <summary>
        /// This is the property size of the listing land in acres.
        /// If no data is available for this attribute, it will be null.
        /// </summary>
        public float? LotSizeAcres { get; set; }
        /// <summary>
        /// This is the number of full bathrooms in the property. If no data is available for this attribute, it will be null.
        /// </summary>
        public int? BathroomsFull { get; set; }
        /// <summary>
        /// This is the number of half bathrooms in the property. If no data is available for this attribute, it will be null.
        /// </summary>
        public int? BathroomsHalf { get; set; }
        /// <summary>
        /// This is the number of quarter-sized bathrooms in the property. If no data is available for this attribute, it will be null.
        /// </summary>
        public int? BathroomsOneQuarter { get; set; }
        /// <summary>
        /// This is the number of partial bathrooms in the property. If no data is available for this attribute, it will be null.
        /// </summary>
        public int? BathroomsPartial { get; set; }
        /// <summary>
        /// This is the number of three-quarter bathrooms in the property. If no data is available for this attribute, it will be null.
        /// </summary>
        public int? BathroomsThreeQuarter { get; set; }
        /// <summary>
        /// This is the number of rooms that are bathrooms in the property. This is not a summary count of bathrooms by size. 
        /// If no data is available for this attribute, it will be null.
        /// </summary>
        public int? BathroomsTotalInteger { get; set; }
        /// <summary>
        /// This is the summary count of bathrooms in the property. 
        /// This will be the number of quarter-bathrooms plus half-bathrooms plus three-quarter bathrooms plus full bathrooms. 
        /// If no data is available for this attribute, it will be null.
        /// </summary>
        public float? BathroomsTotal { get; set; }
        /// <summary>
        /// This is the number of bedrooms in the property. If no data is available for this attribute, it will be null.
        /// </summary>
        public int? BedroomsTotal { get; set; }
        /// <summary>
        /// The human-readable title for the listing generated by the property agent.
        /// If no data is available for this attribute, it will be null.
        /// </summary>
        public string PublicTitle { get; set; }
        /// <summary>
        /// These are human-readable notes about the property generated by the property agent. 
        /// If no data is available for this attribute, it will be null.
        /// </summary>
        public string PublicRemarks { get; set; }
        /// <summary>
        /// This is a string representing a date on which the listing data was last updated in ISO 8601 format. 
        /// If no data is available for this attribute, it will be null.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? ModificationTimestamp { get; set; }
        /// <summary>
        /// This denotes whether the property should be displayed on a public facing website. If no data is available for this attribute, it will be null.
        /// </summary>
        public bool? InternetAddressDisplayYN { get; set; }
        /// <summary>
        /// The number of days the listing has been on market.
        /// </summary>
        public int? DaysOnMarket { get; set; }
        /// <summary>
        /// This is a string representing a date on which the listing contract was initiated. The string format is MM/DD/YYYY.
        /// </summary>
        [JsonConverter(typeof(MoxiDateFormatConverter), "MM/dd/yyyy")]
        public DateTime? ListingContractDate { get; set; }
        /// <summary>
        /// This is a string representing a date on which the Listing object was created. The string format is MM/DD/YYYY.
        /// </summary>
        [JsonConverter(typeof(MoxiDateFormatConverter), "MM/dd/yyyy")]
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// The elementary school for the property.
        /// </summary>
        public string ElementarySchool { get; set; }
        /// <summary>
        /// The number of garage spaces that are available at the property.
        /// </summary>
        public int? GarageSpaces { get; set; }
        /// <summary>
        /// Whether the property is waterfront.
        /// </summary>
        public bool? WaterfrontYN { get; set; }
        /// <summary>
        /// The high school for the property.
        /// </summary>
        public string HighSchool { get; set; }
        /// <summary>
        /// The home owner’s association fee for the property.
        /// </summary>
        public int? AssociationFee { get; set; }
        /// <summary>
        /// The name of the listing office.
        /// </summary>
        public string ListOfficeName { get; set; }
        /// <summary>
        /// The listed price for the listing.
        /// </summary>
        public int? ListPrice { get; set; }
        /// <summary>
        /// The MLS number for the listing.
        /// </summary>
        public string ListingID { get; set; }
        /// <summary>
        /// The name of the listing agent.
        /// </summary>
        public string ListAgentFullName { get; set; }
        /// <summary>
        /// A unique identifier for the listing agent. This will correspond to the uuid field of an Agent.
        /// </summary>
        public string ListAgentUUID { get; set; }
        /// <summary>
        /// A unique identifier for the listing agent’s office. This will correspond to the office_id field of an Office.
        /// </summary>
        public string ListAgentOfficeID { get; set; }
        /// <summary>
        /// A unique identifier for the listing agent’s office. This will correspond to the moxi_works_office_id field of an Office.
        /// </summary>
        public string ListAgentMoxiWorksOfficeID { get; set; }
        /// <summary>
        /// If there is a second listing agent, the name of the second listing agent.
        /// </summary>
        public string SecondaryListAgentFullName { get;set;}
        /// <summary>
        /// If there is a second listing agent, the unique identifier for the second listing agent. 
        /// This will correspond to the uuid field of an Agent.
        /// </summary>
        public string SecondaryListAgentUUID { get; set; }
        /// <summary>
        /// The school district the listing property is in.
        /// </summary>
        public string SchoolDistrict { get; set; }
        /// <summary>
        /// The street address of the property.
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Additional street address information, for example, suite number.
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// City or township the property is located in.
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Contry or parish the property is located in.
        /// </summary>
        public string CountyOrParish { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        /// <summary>
        /// Whether to display information about this listing publicly. 
        /// If this is false, then the information about this listing should not be visible to the Internet.
        /// </summary>
        public string StateOrProvince { get; set; }
        /// <summary>
        /// The zip code or postal code the property is located in.
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// The community the property is located in.
        /// </summary>
        public string Community { get; set; }
        /// <summary>
        /// Total area of the lot.
        /// </summary>
        public long? LotSizeSquareFeet { get; set; }
        /// <summary>
        /// Whether to display information about this listing publicly. 
        /// If this is false, then the information about this listing should not be visible to the Internet.
        /// </summary>
        public bool? InternetEntireListingDisplayYN { get; set; }
        /// <summary>
        /// The middle school for the property.
        /// </summary>
        public string MiddleOrJuniorSchool { get; set; }
        /// <summary>
        /// The name of the MLS which this listing is listed with.
        /// </summary>
        public string ListOfficeAOR { get; set; }
        /// <summary>
        /// The MLS Area which this listing is in.
        /// </summary>
        public string ListOfficeAORArea { get; set; }
        /// <summary>
        /// Whether the property has a pool.
        /// </summary>
        public bool? PoolYN { get; set; }
        /// <summary>
        /// The type of property being listed. This can be one of Residential, Condo-Coop, Townhouse, Land, Multifamily
        /// </summary>
        public string PropertyType { get; set; }
        /// <summary>
        /// The total annual property tax.
        /// </summary>
        public int? TaxAnnualAmount { get; set; }
        /// <summary>
        /// The tax year that the property tax in TaxAnnualAmount was assessed.
        /// </summary>
        public int? TaxYear { get; set; }
        /// <summary>
        /// Whether the building has one story or is multi-story.
        /// </summary>
        public bool? SingleStory { get; set; }
        /// <summary>
        /// Total square footage of the building(s) on the property.
        /// </summary>
        public int? LivingArea { get; set; }
        /// <summary>
        /// Whether the property has a view.
        /// </summary>
        public bool? ViewYN { get; set; }
        /// <summary>
        /// The year the living building(s) on the property were built.
        /// </summary>
        public int? YearBuilt { get; set; }
        /// <summary>
        /// Whether the listing is currently on-market.
        /// </summary>
        public bool? OnMarket { get; set; }
        /// <summary>
        /// Detailed status of the listing; whether it’s active pending
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The unique Identifier for the listing in The Moxi Works Platform.
        /// </summary>
        public string MoxiWorksListingId { get; set; }
        /// <summary>
        /// Whether the agent created this listing.
        /// </summary>
        public bool? AgentCreatedListing { get; set; }
        /// <summary>
        /// Virtual tour URL for this listing.
        /// </summary>
        public string VirtualTourURL { get; set; }
        /// <summary>
        /// Details URL for this listing.
        /// </summary>
        public string ListingURL { get; set; }
        /// <summary>
        /// Any defined features about the property.
        /// </summary>
        public List<PropertyFeatures> PropertyFeatures { get; set; }
        /// <summary>
        /// Company specific attributes associated with the listing. These will be defined by the company & should not be expected to be uniform across companies.
        /// </summary>
        public List<CompanyListingAttribute> CompanyListingAttributes { get; set; }
        /// <summary>
        /// Open house data
        /// </summary>
        public List<OpenHouse> OpenHouse { get; set; }
        /// <summary>
        /// Any images of the property.
        /// </summary>
        public List<ListingImage> ListingImages { get; set; }
    }
}