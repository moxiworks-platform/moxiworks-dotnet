using System.Collections.Generic;
using NUnit.Framework;
namespace MoxiWorks.Platform.Test
{
    [TestFixture]
    class ListingResultFixture
    {
        [Test]
        public void ShouldReturnNullIfNoListingsExists()
        {
            var results = new ListingResults();
            Assert.AreEqual(results.LastMoxiWorksID, null);  
        }

        [Test]
        public void ShouldReturnTheLastMoxiWorksListingId()
        {
            var results = new ListingResults();
            var listings = new List<Listing>(); 
            for(var i = 0; i < 100; i++)
            {
                var l = new Listing {MoxiWorksListingId = i.ToString()};
                listings.Add(l);
            }
            results.Listings = listings;

            Assert.AreEqual(results.LastMoxiWorksID, results.Listings[99].MoxiWorksListingId); 

        }
    }
}
