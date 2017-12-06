using Xunit;
using Bogus;
using MoxiWorks.Platform;
using System.Collections.Generic;
namespace MoxiWorks.Test
{

    public class ListingResultFixture
    {
        [Fact]
        public void ShouldReturnNullIfNoListingsExists()
        {
            var results = new ListingResults();
            Assert.Equal(results.LastMoxiWorksID, null);  
        }

        [Fact]
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

            Assert.Equal(results.LastMoxiWorksID, results.Listings[99].MoxiWorksListingId); 

        }
    }
}
