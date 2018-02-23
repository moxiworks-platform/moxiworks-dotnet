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
            Assert.Null(results.LastMoxiWorksID);  
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

            Assert.Matches(results.LastMoxiWorksID, results.Listings[99].MoxiWorksListingId); 

        }

      
    }
}
