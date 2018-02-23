using System;
using Xunit;
using MoxiWorks.Platform;

namespace MoxiWorks.Test
{
    public class SoldListingServiceFixture
    {
        [Fact]
        public void ShouldReturnASoldListing()
        {
            var soldListingJson = StubDataLoader.LoadJsonFile("SoldListing.json");  
           
            var service = new SoldListingService(new MoxiWorksClient(new StubContextClient(soldListingJson)));
            var response = service.GetSoldListingAsync("moxiworks_listing_id","moxi_works_company_id").Result; 
            
            Assert.IsType<SoldListing>(response.Item);
        
            
        }
        
        
        [Fact]
        public void ShouldReturnACollectionOfSoldListings()
        {
            var soldListingsJson = StubDataLoader.LoadJsonFile("SoldListings.json");  
           
            var service = new SoldListingService(new MoxiWorksClient(new StubContextClient(soldListingsJson)));
            var response = service.GetSoldListingsUpdatedSinceAsync("moxi_works_company_id", AgentIdType.MoxiWorksagentId,"MoxiWorksagentId", DateTime.Now).Result; 
            
            Assert.IsType<SoldListingResults>(response.Item);
            Assert.True(response.Item.Listings.Count == 2);
          
        }

    }
}