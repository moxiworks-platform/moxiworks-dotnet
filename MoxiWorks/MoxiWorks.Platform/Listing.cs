using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Listing entity representing a Brokerage’s listing.
    /// </summary>
    public class Listing : ListingBase
    {
        /// <summary>
        /// The MLS number for the listing.
        /// </summary>
        public string ListingID { get; set; }
        
        /// <summary>
        /// This is a string representing a date on which the listing contract was initiated. The string format is MM/DD/YYYY.
        /// </summary>
        public string ListingContractDate { get; set; }
        
        /// <summary>
        /// Details URL for this listing.
        /// </summary>
        public string ListingURL { get; set; }
        
        /// <summary>
        /// Open house data
        /// </summary>
        public List<OpenHouse> OpenHouse { get; set; }
        
        
    }


    
}

