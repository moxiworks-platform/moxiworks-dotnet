using System.Collections.Generic;
using System.Linq;

namespace MoxiWorks.Platform
{
    public class ListingResults
    {
        public bool? FinalPage;
        public string LastMoxiWorksID => Listings.Any() ? Listings.Last().MoxiWorksListingId : null;

        public List<Listing> Listings { get; set; } = new List<Listing>();
    }
}
