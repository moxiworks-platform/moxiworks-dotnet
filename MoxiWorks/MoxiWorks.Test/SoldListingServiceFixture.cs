using System;
using System.Collections.Generic;
using Xunit;
using MoxiWorks.Platform;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Test
{
    public class SoldListingServiceFixture
    {
        [Fact]
        public void ShouldReturnASoldListing()
        {
            var soldListingJson = StubDataLoader.LoadJsonFile("SoldListing.json");

            ISoldListingService service = new SoldListingService(new MoxiWorksClient(new StubContextClient(soldListingJson)));
            var response = service.GetSoldListingAsync("moxiworks_listing_id","moxi_works_company_id").Result; 
            
            Assert.IsType<SoldListing>(response.Item);


        }


        [Fact]
        public void ShouldReturnACollectionOfSoldListings()
        {
            var soldListingsJson = StubDataLoader.LoadJsonFile("SoldListings.json");

            ISoldListingService service = new SoldListingService(new MoxiWorksClient(new StubContextClient(soldListingsJson)));
            var response = service.GetSoldListingsUpdatedSinceAsync("moxi_works_company_id", AgentIdType.MoxiWorksagentId,"MoxiWorksagentId", DateTime.Now).Result;

            Assert.IsType<SoldListingResults>(response.Item);
            Assert.IsType<List<SoldListing>>(response.Item.Listings);
            Assert.True(response.Item.Listings.Count == 2);
            Assert.True(response.Item.FinalPage.HasValue);
            Assert.True(response.Item.FinalPage.Value);

        }

        [Fact]
        public void ShouldReturnNullIfNoListingsExists()
        {
            var results = new SoldListingResults();
            Assert.Null(results.LastMoxiWorksID);
        }

        [Fact]
        public void ShouldReturnTheLastMoxiWorksListingId()
        {
            var results = new SoldListingResults();
            var listings = new List<SoldListing>();
            for (var i = 0; i < 100; i++)
            {
                var l = new SoldListing { MoxiWorksListingId = i.ToString() };
                listings.Add(l);
            }
            results.Listings = listings;

            Assert.Matches(results.LastMoxiWorksID, results.Listings[99].MoxiWorksListingId);

        }

    }
}