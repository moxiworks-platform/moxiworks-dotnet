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
            var response = service.GetListingsUpdatedSinceAsync("moxi_works_company_id", AgentIdType.MoxiWorksagentId,"MoxiWorksagentId", DateTime.Now).Result; 
            
            Assert.IsType<SoldListingResults>(response.Item);
          
        }

//       [Fact]
//        public void ShouldHanldeApiReturnedErrors()
//        {
//            var json = StubDataLoader.LoadJsonFile("FailureResponse.json"); 
//            var service = new TaskService(new MoxiWorksClient(new StubContextClient(json)));
//            var response = service.GetTaskAsync("foo", AgentIdType.AgentUuid, "1234", "12345").Result;
//            Assert.True((bool?) response.HasErrors); 
//            
//        }
    }
}