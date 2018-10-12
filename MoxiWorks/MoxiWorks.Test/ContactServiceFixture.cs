using Xunit;
using System.Configuration;
using MoxiWorks.Platform;


namespace MoxiWorks.Test
{
    public class ContactServiceFixture
    {
        [Fact]
        public void ShouldReturnAContactAsync()
        {
            var contactJson = StubDataLoader.LoadJsonFile("Contact.json");  
           
            var service = new ContactService(new MoxiWorksClient(new StubContextClient(contactJson)));
            
            var response = service.GetContactAsync("12345678-1234-1234-1234-1234567890ab",
                AgentIdType.AgentUuid,"booyuh").Result;
            Assert.IsType<Contact>(response.Item);
            Assert.True(response.Item.AgentUuid == "12345678-1234-1234-1234-1234567890ab");
        }
        
        [Fact]
        public void ShouldRunReturnAContactSync()
        {
            var contactJson = StubDataLoader.LoadJsonFile("Contact.json");  
           
            var service = new ContactService(new MoxiWorksClient(new StubContextClient(contactJson)));
            
            var response = service.GetContact("12345678-1234-1234-1234-1234567890ab",
                AgentIdType.AgentUuid,"booyuh");
            Assert.IsType<Contact>(response.Item);
            Assert.True(response.Item.AgentUuid == "12345678-1234-1234-1234-1234567890ab");
        }
    }
}