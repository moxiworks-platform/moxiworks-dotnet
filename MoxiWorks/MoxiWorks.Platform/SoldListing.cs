using System;
using System.Configuration;

namespace MoxiWorks.Platform
{
    public class SoldListing : ListingBase
    {
        /// <summary>
        /// The MLS number for the listing.
        /// </summary>
        public string SoldListingID { get; set; }
        
        /// <summary>
        /// This is a string representing a date on which the listing contract was initiated. 
        /// The string format is MM/DD/YYYY
        /// </summary>
        public string SoldListingContractDate { get; set; }
        
        /// <summary>
        /// Date on which this listing was sold.
        /// </summary>
        public string SoldDate { get; set; }
        
        /// <summary>
        /// Price for which this listing was sold.
        /// </summary>
        public int? SoldPrice { get; set; }
        
        
    }
}