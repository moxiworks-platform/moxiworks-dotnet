using System;
using System.Collections.Generic;
using Bogus;
using System.Threading;



//
//namespace MoxiWorks.Platform.Test
//{
//    [TestFixture]
//    class TestClient
//    {
//        const string MOXI_WORKS_AGENT_ID = "5872936a-4f75-49e6-9a64-f459f5f8ac3d";
//        const string COMPANY_ID = "windermere";
//        private readonly Client Client = new Client(); 
//        [Test]
//        public void GetListings()
//        {
//            var d = new DateTime(2017, 1, 1, 00, 00, 00);
//            var results = new List<ListingResults> {Client.GetListingsUpdateSince("windermere", d).Item};
//
//
//
//            for (var i = 0; i < 2; i++)
//            {
//                results.Add(Client.GetListingsUpdateSince("windermere", d, results[i].LastMoxiWorksID).Item);
//            }
//
//            Assert.AreNotEqual(results[0].LastMoxiWorksID, results[1].LastMoxiWorksID);
//            Assert.AreEqual(results[0].Listings.Count, results[1].Listings.Count);
//        }
//
//        [Test]
//        public void GetSinglisting()
//        {
//            var expectedId = "5ce0e9a5-6015-fec5-aadf-a328aebc40d7";
//            Listing l = Client.GetListing("windermere", expectedId).Item;
//            Assert.AreEqual(expectedId, l.MoxiWorksListingId);
//        }
//
//        [Test]
//        public void GetAgentsByCompany()
//        {
//            var d = new DateTime(2017, 1, 1, 00, 00, 00);
//            var results = new List<AgentResults> {Client.GetAgentsUpdatedSince("windermere", d).Item};
//            results.Add(Client.GetAgentsUpdatedSince("windermere", d, 2, results[0].TotalPages).Item);
//
//            Assert.AreEqual(results[0].TotalPages, results[1].TotalPages);
//            Assert.AreNotEqual(results[0].PageNumber, results[1].PageNumber);
//            results[0].Agents.ForEach(a => Console.WriteLine(a.Uuid));
//
//        }
//
//        [Test]
//        public void GetCompany()
//        {
//            var id = "windermere";
//            var c = Client.GetCompany("windermere").Item;
//            Assert.AreEqual(id, c.MoxiWorksCompanyId);
//        }
//
//        [Test]
//        public void ContactCrudOperations()
//        {
//            var fakeContact = GetFakerContactBuilder();
//            var c = fakeContact.Generate();
//            c.PartnerContactId = Guid.NewGuid().ToString();
//
//            c.AgentUuid = MOXI_WORKS_AGENT_ID;
//
//            var created = Client.CreateContact(c).Item;
//
//            // testing create
//            Assert.AreEqual(c.PartnerContactId, created.PartnerContactId, "Create PartnerContactId did not match");
//            Assert.AreEqual(c.MoxiWorksAgentId, created.MoxiWorksAgentId, "Create MoxiWorksAgentId did not match");
//
//            // test update 
//            var oldAddress = created.HomeStreetAddress;
//            var expectedAddress = "1234 happy lane";
//            created.HomeStreetAddress = expectedAddress;
//            var updated = Client.UpdateContact(created).Item;
//
//            Assert.AreEqual(expectedAddress, updated.HomeStreetAddress, "Update did not match");
//
//            // test get
//            var result = Client.GetContact(updated.AgentUuid, AgentIdType.AgentUuid, updated.PartnerContactId).Item;
//
//            Assert.AreNotEqual(oldAddress, result.HomeStreetAddress, "get returned incorrect address");
//            Assert.AreEqual(updated.HomeStreetAddress, result.HomeStreetAddress, "get returned incorrect address");
//
//        }
//
//        [Test]
//        public void BuyerTransactionCrudOperations()
//        {
//            var fakeContact = GetFakerContactBuilder();
//            var c = fakeContact.Generate();
//            c.PartnerContactId = Guid.NewGuid().ToString();
//
//            c.AgentUuid = MOXI_WORKS_AGENT_ID;
//
//            var contact = Client.CreateContact(c).Item;
//
//
//            var fakeBuyerTransaction = GetBogusContactBuilder();
//            var b = fakeBuyerTransaction.Generate();
//            b.PartnerContactId = contact.PartnerContactId;
//            b.AgentUuid = MOXI_WORKS_AGENT_ID;
//
//
//            var created = Client.CreateBuyerTransaction(b).Item;
//
//            // testing create
//            Assert.AreEqual(b.PartnerContactId, created.PartnerContactId, "Create PartnerContactId did not match");
//            Assert.AreEqual(b.MoxiWorksAgentId, created.MoxiWorksAgentId, "Create MoxiWorksAgentId did not match");
//
//
//            // get transaction
//            var result = Client.GetBuyerTransaction(created.AgentUuid, AgentIdType.AgentUuid,
//                created.MoxiWorksTransactionId).Item;
//
//            Assert.IsNotNull(result);
//
//            // update transaction
//            result.Address = "12345 happy place";
//            var updated = Client.UpdateBuyerTransaction(result).Item;
//            Assert.AreEqual(updated.Address, result.Address);
//
//
//        }
//
//        [Test]
//        public void GetResultListOfBuyerTransactions()
//        {
//
//            var results = Client.GetBuyerTransactions(MOXI_WORKS_AGENT_ID, AgentIdType.AgentUuid).Item;
//
//            Assert.IsNotNull(results.PageNumber);
//            Assert.IsNotNull(results.TotalPages);
//        }
//
//        [Test]
//        public void CreateActionLogAndGetItFromIndex()
//        {
//            var fakeContact = GetFakerContactBuilder();
//            var c = fakeContact.Generate();
//            c.PartnerContactId = Guid.NewGuid().ToString();
//            c.AgentUuid = MOXI_WORKS_AGENT_ID;
//
//            var contact = Client.CreateContact(c).Item;
//            var log = GetBogusActionLogBuilder().Generate();
//            log.PartnerContactId = contact.PartnerContactId;
//            log.AgentUuid = contact.AgentUuid;
//
//            var result = Client.CreateActionLog(log).Item;
//
//            Assert.AreEqual(log.Title, result.Title);
//            Assert.AreEqual(log.Body, result.Body);
//            Thread.Sleep(6000);
//            var results = Client.GetActionLogs(MOXI_WORKS_AGENT_ID, AgentIdType.AgentUuid, log.PartnerContactId).Item;
//            Assert.IsTrue(results.Actions.Count > 0);
//        }
//
//        [Test]
//        public void GetBrand()
//        {
//            var result = Client.GetCompanyBrand(COMPANY_ID).Item;
//            Assert.IsNotNull(result.ImageLogo);
//        }
//
//        //[Test]
//        //public void GetFullCompanyBranding()
//        //{
//        //    var result = Client.GetFullCompanyBranding(COMPANY_ID, MOXI_WORKS_AGENT_ID).Item;
//
//        //    Assert.IsNotNull(result.ImageLogo);
//        //}
//
//        [Test]
//        public void GetEmailCampaign()
//        {
//            var fakeContact = GetFakerContactBuilder();
//            var c = fakeContact.Generate();
//            c.PartnerContactId = Guid.NewGuid().ToString();
//            c.AgentUuid = MOXI_WORKS_AGENT_ID;
//
//            var contact = Client.CreateContact(c).Item;
//            var log = GetBogusActionLogBuilder().Generate();
//            log.PartnerContactId = contact.PartnerContactId;
//            log.AgentUuid = contact.AgentUuid;
//
//            var result = Client.GetEmailCampaign(c.AgentUuid, AgentIdType.AgentUuid, contact.PartnerContactId).Item;
//            Assert.AreEqual(result.EmailCampaigns.Count, 0);
//        }
//
//        [Test]
//        public void EventCrud()
//        {
//            var fakeContact = GetFakerContactBuilder();
//            var c = fakeContact.Generate();
//            c.PartnerContactId = Guid.NewGuid().ToString();
//            c.AgentUuid = MOXI_WORKS_AGENT_ID;
//            var contact = Client.CreateContact(c).Item;
//
//            var newEvent = GetFakerEventBuilder().Generate();
//            newEvent.AgentUuId = MOXI_WORKS_AGENT_ID;
//            newEvent.PartnerEventId = Guid.NewGuid().ToString();
//            newEvent.Attendees.Add(contact.PartnerContactId);
//
//            var created = Client.CreateEvent(newEvent).Item;
//            Assert.AreEqual(newEvent.AgentUuId, created.AgentUuId);
//            Assert.AreEqual(newEvent.PartnerEventId,created.PartnerEventId);
//            Assert.AreEqual(newEvent.AllDay, created.AllDay);
//            Assert.AreEqual(newEvent.EventLocation, created.EventLocation);
//            Assert.AreEqual(newEvent.Attendees.Count, 1);
//
//            var current = Client.GetEvent(MOXI_WORKS_AGENT_ID, AgentIdType.AgentUuid, created.PartnerEventId).Item;
//            Assert.AreEqual(created.MoxiWorksAgentId ,current.MoxiWorksAgentId);
//            Assert.AreEqual(created.PartnerEventId, current.PartnerEventId);
//            
//            var expected = "1234 happy lane seattle wa 98136";
//            created.EventLocation = expected;
//            var updated = Client.UpdateEvent(created).Item;
//            Assert.AreEqual(expected, updated.EventLocation);
//
//
//            if (updated.EventStart != null)
//            {
//                if (updated.EventEnd != null)
//                {
//                    var results = Client.GetEventsByDate(MOXI_WORKS_AGENT_ID,
//                        AgentIdType.AgentUuid,
//                        updated.EventStart.Value,
//                        updated.EventEnd.Value).Item;
//                    Assert.AreEqual(2, results.EventListDates.Count);
//                }
//            }
//
//
//            var deleted = Client.DeleteEvent(MOXI_WORKS_AGENT_ID,
//                AgentIdType.AgentUuid,
//                updated.PartnerEventId).Item; 
//            
//            Assert.AreEqual("success",deleted.Status);
//            Assert.IsTrue(deleted.Deleted);
//
//        }
//
//        
//        [Test]
//        [Ignore("Unable to get this one running")]
//        public void GetGroup()
//        {
//            var result = Client.GetGroup("a5552043-0649-489e-afbf-166fbbe53aea",
//                AgentIdType.AgentUuid,
//                "http://www.google.com/m8/feeds/groups/qatest2%40gapps-qa.moxiworks.com/base/1dc99b740fc9e318").Item;
//            Assert.AreEqual("a5552043-0649-489e-afbf-166fbbe53aea",result.AgentUuId);
//            Assert.IsTrue(result.Contacts.Count > 0 );
//        }
//
//        [Test]
//        [Ignore("Unable to test groups")]
//        public void GetGroups()
//        {
//            var results = Client.GetGroups(MOXI_WORKS_AGENT_ID, AgentIdType.AgentUuid).Item;
//        }
//
//
//        private Faker<Event> GetFakerEventBuilder()
//        {
//            return new Faker<Event>()
//                .RuleFor(e => e.EventEnd, Client.GetTimeStamp(DateTime.Now.AddDays(1).AddHours(5)))
//                .RuleFor(e => e.EventStart, Client.GetTimeStamp(DateTime.Now.AddDays(1)))
//                .RuleFor(e => e.AllDay, false)
//                .RuleFor(e => e.EventSubject, f => f.Name.JobTitle() + "event title")
//                .RuleFor(e => e.Note, f => f.Lorem.Paragraph())
//                .RuleFor(e => e.RemindMinutesBefore, f => f.Random.Number(5, 45))
//                .RuleFor(e => e.SendReminder, f => f.Random.Bool())
//                .RuleFor(e => e.EventLocation, f => f.Address.FullAddress());
//
//
//        }
//
//
//        private Faker<Contact> GetFakerContactBuilder()
//        {
//            return new Faker<Contact>()
//                .RuleFor(co => co.ContactName, f => $"{f.Name.FirstName()} {f.Name.LastName()}")
//                .RuleFor(co => co.PrimaryPhoneNumber, f => f.Phone.PhoneNumber())
//                .RuleFor(co => co.PrimaryEmailAddress, f => f.Internet.ExampleEmail())
//                .RuleFor(co => co.HomeStreetAddress, f => f.Address.StreetAddress())
//                .RuleFor(co => co.HomeCity, f => f.Address.City())
//                .RuleFor(co => co.HomeState, f => f.Address.State())
//                .RuleFor(co => co.HomeZip, f => f.Address.ZipCode());
//        }
//
//        private Faker<BuyerTransaction> GetBogusContactBuilder()
//        {
//            return new Faker<BuyerTransaction>()
//                .RuleFor(bt => bt.Notes, f => f.Lorem.Sentence())
//                .RuleFor(bt => bt.Address, f => f.Address.StreetAddress())
//                .RuleFor(bt => bt.City, f => f.Address.City())
//                .RuleFor(bt => bt.State, f => f.Address.State())
//                .RuleFor(bt => bt.ZipCode, f => f.Address.ZipCode())
//                .RuleFor(bt => bt.CommissionFlatFee, 3000)
//                .RuleFor(bt => bt.TransactionName, f => f.Name.FullName() + " - buyer");
//        }
//
//        private Faker<ActionLog> GetBogusActionLogBuilder()
//        {
//            return new Faker<ActionLog>()
//                .RuleFor(al => al.Body, f => f.Lorem.Paragraph())
//                .RuleFor(al => al.Title, f => f.Lorem.Word() + "-title");
//        }
//
//    }
//
//
//
//}
//        
//    
//   
//
//
//
//
//    