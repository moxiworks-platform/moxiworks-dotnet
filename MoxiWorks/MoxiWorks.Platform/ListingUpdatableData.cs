namespace MoxiWorks.Platform
{
    /// <summary>
    /// Used to hold properties updatable for listings
    /// </summary>
    public class ListingUpdatableData 
    {
        /// <summary>
        /// Virtual tour URL for this listing.
        /// </summary>
        public string VirtualTourURL { get; set; }
        
        /// <summary>
        /// Partner specific listing information in a json formatted string.
        /// </summary>
        public string SharedPartnerData { get; set; }
        
    }
    
    
}