using System.Linq;
using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    public class SoldListingResults
    {
        /// <summary>
        /// If there is another page of Listing objects available, this will be false. 
        /// If you are receiving the final page of Listing objects for the query, FinalPage will be true.
        /// </summary>
        public bool? FinalPage;
        /// <summary>
        /// MoxiWorksID of the last listing returned
        /// </summary>
        public string LastMoxiWorksID => Listings.Any() ? Listings.Last().MoxiWorksListingId : null;
        /// <summary>
        /// This is the payload object for the query. Any Listing object that matches the request query will be returned here.
        /// </summary>
        public List<Listing> Listings { get; set; } = new List<Listing>();
        
    }
}