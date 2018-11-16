using System;
using Xunit;
using System.Configuration;
using System.Linq.Expressions;
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

        [Fact]
        public void ShouldHandleSubdomianEmails()
        {
            var contactJson = StubDataLoader.LoadJsonFile("Contact.json");  
            var service = new ContactService(new MoxiWorksClient(new StubContextClient(contactJson)));
            var response = service.GetContact("12345678-1234-1234-1234-1234567890ab",
                AgentIdType.AgentUuid,"booyuh");
            var contact = response.Item;
            contact.PrimaryEmailAddress = "gmm@neohio.twcbc.com"; 
            
            response = service.CreateContact(contact); 
            Assert.IsType<Contact>(response.Item);
            Assert.True(response.Item.AgentUuid == "12345678-1234-1234-1234-1234567890ab");

        }

        [Fact]
        public async void ShouldThrowUnableToDeserializeException()
        {
            var contactJson = StubDataLoader.LoadJsonFile("error.html");  
            var service = new ContactService(new MoxiWorksClient(new StubContextClient(contactJson)));
            await Assert.ThrowsAsync<UnableToDeserializeException>(async () => await service.GetContactAsync("12345678-1234-1234-1234-1234567890ab",
               AgentIdType.AgentUuid,"booyuh")); 
        }
        
        
        [Fact]
        public async void UnableToDeserializeExceptionShouldContainResponseBody()
        {
            var contactJson = StubDataLoader.LoadJsonFile("error.html");  
            var service = new ContactService(new MoxiWorksClient(new StubContextClient(contactJson)));
            try
            {
                await service.GetContactAsync("12345678-1234-1234-1234-1234567890ab",
                    AgentIdType.AgentUuid, "booyuh");
            }
            catch (UnableToDeserializeException e)
            {
                Assert.Equal(contactJson, e.Data); 
            }

        }
        
        
    }
}