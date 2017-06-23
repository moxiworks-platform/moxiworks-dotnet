using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoxiWorks.Platform
{
    public class ListingResults
    {
        public bool? FinalPage;
        public string LastMoxiWorksID {
            get {
                if (Listings.Count() > 0) {

                    return Listings.Last().MoxiWorksListingId;
                } 
                else {
                    return null;
                } 
                  
            } }

        private List<Listing> _listings = new List<Listing>();
        public List<Listing> Listings { get { return _listings; } set { _listings = value; } } 

    }
}
