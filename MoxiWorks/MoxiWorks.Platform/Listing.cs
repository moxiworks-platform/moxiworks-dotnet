using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    public class Listing
    {
        public float? LotSizeAcres { get; set; }
        public int? BathroomsFull { get; set; }
        public int? BathroomsHalf { get; set; }
        public int? BathroomsOneQuarter { get; set; }
        public int? BathroomsPartial { get; set; }
        public int? BathroomsThreeQuarter { get; set; }
        public int? BathroomsTotalInteger { get; set; }
        public float? BathroomsTotal { get; set; }
        public int? BedroomsTotal { get; set; }
        public string PublicRemarks { get; set; }
        public string ModificationTimestamp { get; set; }
        public bool? InternetAddressDisplayYN { get; set; }
        public int? DaysOnMarket { get; set; }
        public string ListingContractDate { get; set; }
        public string CreatedDate { get; set; }
        public string ElementarySchool { get; set; }
        public int? GarageSpaces { get; set; }
        public bool? WaterfrontYN { get; set; }
        public string HighSchool { get; set; }
        public int? AssociationFee { get; set; }
        public string ListOfficeName { get; set; }
        public int? ListPrice { get; set; }
        public string ListingID { get; set; }
        public string ListAgentFullName { get; set; }
        public string ListAgentUUID { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string CountyOrParish { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string StateOrProvince { get; set; }
        public string PostalCode { get; set; }
        public string LotSizeSquareFeet { get; set; }
        public bool? InternetEntireListingDisplayYN { get; set; }
        public string MiddleOrJuniorSchool { get; set; }
        public string ListOfficeAOR { get; set; }
        public bool? PoolYN { get; set; }
        public string PropertyType { get; set; }
        public int? TaxAnnualAmount { get; set; }
        public int? TaxYear { get; set; }
        public bool? SingleStory { get; set; }
        public int? LivingArea { get; set; }
        public bool? ViewYN { get; set; }
        public int? YearBuilt { get; set; }
        public bool? OnMarket { get; set; }
        public string Status { get; set; }
        public string MoxiWorksListingId { get; set; }
        public List<PropertyFeatures> PropertyFeatures { get; set; }
        public List<string> LisingImages { get; set; }
    }


    
}

