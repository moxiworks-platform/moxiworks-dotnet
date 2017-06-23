using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace MoxiWorks.Platform.Test
{
    [TestFixture]
    class ListingResultFixture
    {
        [Test]
        public void ShouldReturnNullIfNoListingsExists()
        {
            ListingResults results = new ListingResults();
            Assert.AreEqual(results.LastMoxiWorksID, null);  
        }

        [Test]
        public void ShouldReturnTheLastMoxiWorksListingID()
        {
            ListingResults results = new ListingResults();
            List<Listing> listings = new List<Listing>(); 
            for(int i = 0; i < 100; i++)
            {
                var l = new Listing();
                l.MoxiWorksListingId = i.ToString();
                listings.Add(l);
            }
            results.Listings = listings;

            Assert.AreEqual(results.LastMoxiWorksID, results.Listings[99].MoxiWorksListingId); 

        }
    }
}
