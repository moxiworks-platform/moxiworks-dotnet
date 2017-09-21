using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Cryptography;
using NUnit.Framework;
using Bogus;

namespace MoxiWorks.Platform.Test
{
    [TestFixture]
    class TestClient
    {
        const string  MOXI_WORKS_AGENT_ID = "5872936a-4f75-49e6-9a64-f459f5f8ac3d";
        [Test]
        public void GetListings()
        {
            var d = new DateTime(2017, 1, 1, 00, 00, 00);
            var results = new List<ListingResults> {Client.GetListingsUpdateSince("windermere", d)};



            for (var i = 0; i < 2; i++)
            {
                results.Add(Client.GetListingsUpdateSince("windermere", d, results[i].LastMoxiWorksID));
            }

            Assert.AreNotEqual(results[0].LastMoxiWorksID, results[1].LastMoxiWorksID);
            Assert.AreEqual(results[0].Listings.Count, results[1].Listings.Count);
        }

        [Test]
        public void GetSinglisting()
        {
            var expectedId = "5ce0e9a5-6015-fec5-aadf-a328aebc40d7";
            Listing l = Client.GetListing("windermere", expectedId);
            Assert.AreEqual(expectedId, l.MoxiWorksListingId );
        }

        [Test]
        public void GetAgentsByCompany()
        {
            var d = new DateTime(2017, 1, 1, 00, 00, 00);
            var results = new List<AgentResults> {Client.GetAgentsUpdatedSince("windermere", d)};
            results.Add(Client.GetAgentsUpdatedSince("windermere", d,2,results[0].TotalPages));
                
            Assert.AreEqual(results[0].TotalPages, results[1].TotalPages);
            Assert.AreNotEqual(results[0].PageNumber, results[1].PageNumber);
            results[0].Agents.ForEach(a => Console.WriteLine(a.Uuid));

        }

        [Test]
        public void GetCompany()
        {
            var id = "windermere"; 
            var c = Client.GetCompany("windermere");
            Assert.AreEqual(id, c.MoxiWorksCompanyId );
        }

//        [Test]
//        public void CreatContact()
//        {
//            var fakeContact = GetFakerContactBuilder();
//
//
//            var c = fakeContact.Generate();
//            c.PartnerContactId =  Guid.NewGuid().ToString();;
//            c.AgentUuid = MOXI_WORKS_AGENT_ID;
//            
//
//            var result = Client.CreateContact(c);
//            
//            
//            
//            Assert.AreEqual(c.PartnerContactId,result.PartnerContactId);
//            Assert.AreEqual(c.MoxiWorksAgentId, result.MoxiWorksAgentId);
//        }

//        [Test]
//        public void UpdateContact()
//        {
//            var fakeContact = GetFakerContactBuilder();
//
//
//            var c = fakeContact.Generate();  
//            c.PartnerContactId =  Guid.NewGuid().ToString();;
//            c.AgentUuid = MOXI_WORKS_AGENT_ID;
//
//            var newContact = Client.CreateContact(c);
//            var expected  = "1234 happy lane";
//            newContact.HomeStreetAddress = expected;
//
//            var result = Client.UpdateContact(newContact);
//            
//            Assert.AreEqual(expected, result.HomeStreetAddress);
//            
//        }

        [Test]
        public void ContactCrudOperations()
        {
            var fakeContact = GetFakerContactBuilder();
            var c = fakeContact.Generate();
            c.PartnerContactId =  Guid.NewGuid().ToString();;
            c.AgentUuid = MOXI_WORKS_AGENT_ID;
            
            var created = Client.CreateContact(c);
            
            // testing create
            Assert.AreEqual(c.PartnerContactId,created.PartnerContactId, "Create PartnerContactId did not match" );
            Assert.AreEqual(c.MoxiWorksAgentId, created.MoxiWorksAgentId ,"Create MoxiWorksAgentId did not match");

            // test update 
            var old_address = created.HomeStreetAddress;
            var expected_address  = "1234 happy lane";
            created.HomeStreetAddress = expected_address;
            var updated = Client.UpdateContact(created);
            
            Assert.AreEqual(expected_address, updated.HomeStreetAddress,"Update did not match");
            
            // test get
            var result =  Client.GetContact(updated.AgentUuid, AgentIdType.AgentUuid, updated.PartnerContactId);
            
            Assert.AreNotEqual(old_address, result.HomeStreetAddress,"get returned incorrect address");
            Assert.AreEqual(updated.HomeStreetAddress, result.HomeStreetAddress,"get returned incorrect address");
            
            
            
        }
        
       

        private Faker<Contact> GetFakerContactBuilder()
        {
            return new Faker<Contact>()
                .RuleFor(co => co.ContactName, f => $"{f.Name.FirstName()} {f.Name.LastName()}")
                .RuleFor(co => co.PrimaryPhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(co => co.PrimaryEmailAddress, f => f.Internet.ExampleEmail())
                .RuleFor(co => co.HomeStreetAddress, f => f.Address.StreetAddress())
                .RuleFor(co => co.HomeCity, f => f.Address.City())
                .RuleFor(co => co.HomeState, f => f.Address.State())
                .RuleFor(co => co.HomeZip, f => f.Address.ZipCode());
        }
 

        

        //[Test]
        //public void ShouldBeAbleToGetCookes()m
        //{

        //    var cookie = new Cookie("foo", "bar");
        //    Client.Cookies.Add(cookie);

        //    Client.Context

        //}


    }
        
    
   




    public class ClientTester
    {
        //public void run()
        //{
        //    var d = new DateTime(2017, 1, 1, 00, 00, 00);
        //    List<ListingResults> results = new List<ListingResults>();
        //    results.Add(Client.GetListingsUpdateSince(", d));
            
          
        //    for(var i= 0; i < 2; i++)
        //    { 
        //         results.Add(Client.GetListingsUpdateSince("foo", d, results[i].LastMoxiWorksID));
        //    }

        //    Assert.AreNotEqual(results[0].LastMoxiWorksID, results[1].LastMoxiWorksID);
        //    Assert.AreEqual(results[0].Listings.Count, results[1].Listings.Count);
            


            //var _handler = new HttpClientHandler();
            //  _handler.CookieContainer = Cookies;
            //            _handler.UseCookies = true;


            //var client = new HttpClient(_handler);
            //var cred = new Credentials("5d39ba58-bfc3-11e5-a4e3-d0e1408e8026", "a56sthhidTlUsLyp8eFZBQtt");
            //var auth = AuthenticationHeaderValue.Parse("Basic " + cred.ToBase64());
            //client.DefaultRequestHeaders.Authorization = auth;
            //client.DefaultRequestHeaders.Add("Accept", "application/vnd.moxi-platform+json;version=1");

            //HttpResponseMessage result = client.GetAsync("https://api-qa.moxiworks.com/api/listings?moxi_works_company_id=windermere&updated_since=1461108284").Result;

            //var cookies = _handler.CookieContainer.GetCookies(new Uri("https://api-qa.moxiworks.com"));
            //var cookie =  cookies[0];
            //HttpContent content = result.Content;
            //string test = content.ReadAsStringAsync().Result;

            //var listings = JsonConvert.DeserializeObject<ListingResults>(test);


            //client.DefaultRequestHeaders.Add("Cookie", String.Format("{0}={1}; path=/; HttpOnly", cookie.Name, cookie.Value));

            //HttpResponseMessage result2 = client.GetAsync("https://api-qa.moxiworks.com/api/listings?moxi_works_company_id=windermere&updated_since=1461108284").Result;

            //HttpContent content2 = result2.Content;
            //string test2 = content2.ReadAsStringAsync().Result;

            //var listings2 = JsonConvert.DeserializeObject<ListingResults>(test2);


            //client.DefaultRequestHeaders.Add("Cookie", String.Format("{0}={1}; path=/; HttpOnly", cookie.Name, cookie.Value));

            //HttpResponseMessage result3 = client.GetAsync("https://api-qa.moxiworks.com/api/listings?moxi_works_company_id=windermere&updated_since=1461108284").Result;

            //HttpContent content3 = result3.Content;
            //string test3 = content2.ReadAsStringAsync().Result;

            //var listings3 = JsonConvert.DeserializeObject<ListingResults>(test3);




       // }
    }
}