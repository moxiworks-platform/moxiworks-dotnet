using System;
using MoxiWorks.Platform;
using MoxiWorks.Platform.Interfaces;
using Xunit;

namespace MoxiWorks.Test
{
    public class OfficeServiceFixture
    {
        [Fact]
        public void ShouldReturnAnOffice()
        {
            var officeJson = StubDataLoader.LoadJsonFile("office.json");  
           
            IOfficeService service = new OfficeService(new MoxiWorksClient(new StubContextClient(officeJson)));

            var response = service.GetOfficeAsync("some_moxiworks_office_id","some_moxiworks_company_id").Result;
            Assert.IsType<Office>(response.Item);
            Assert.True(response.Item.CreatedTimestamp.HasValue);
            Assert.False(response.Item.DeactivatedTimestamp.HasValue);
        }
        
        [Fact]
        public void ShouldReturnAnOfficeSync()
        {
            var officeJson = StubDataLoader.LoadJsonFile("office.json");  
           
            IOfficeService service = new OfficeService(new MoxiWorksClient(new StubContextClient(officeJson)));

            var response = service.GetOffice("some_moxiworks_office_id","some_moxiworks_company_id");
            Assert.IsType<Office>(response.Item);
            Assert.True(response.Item.CreatedTimestamp.HasValue);
            Assert.False(response.Item.DeactivatedTimestamp.HasValue);
            
        }
        
        [Fact]
        public void ShouldReturnACollectionOfOffices()
        {
            var officeJson = StubDataLoader.LoadJsonFile("Offices.json");  
           
            IOfficeService service = new OfficeService(new MoxiWorksClient(new StubContextClient(officeJson)));

            var response = service.GetCompanyOfficesAsync("some_moxiworks_company_id").Result;
            Assert.IsType<OfficeResults>(response.Item);
            Assert.True(response.Item.Offices.Count == 1);
            Assert.True(response.Item.Offices[0].CreatedTimestamp.HasValue);
            Assert.False(response.Item.Offices[0].DeactivatedTimestamp.HasValue);
            
        }
        
        [Fact]
        public void ShouldReturnACollectionOfOfficesSync()
        {
            var officeJson = StubDataLoader.LoadJsonFile("Offices.json");  
           
            IOfficeService service = new OfficeService(new MoxiWorksClient(new StubContextClient(officeJson)));

            var response = service.GetCompanyOffices("some_moxiworks_company_id");
            Assert.IsType<OfficeResults>(response.Item);
            Assert.True(response.Item.Offices.Count == 1);
            Assert.True(response.Item.Offices[0].CreatedTimestamp.HasValue);
            Assert.False(response.Item.Offices[0].DeactivatedTimestamp.HasValue);
            
        }
    }
}