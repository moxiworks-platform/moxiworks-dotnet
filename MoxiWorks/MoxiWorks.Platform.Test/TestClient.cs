using System;
using System.Collections.Generic;
using NUnit.Framework;
using Bogus;
using Newtonsoft.Json;
using System.IO; 

namespace MoxiWorks.Platform.Test
{
    [TestFixture]
    class TestClient
    {
        const string MOXI_WORKS_AGENT_ID = "5872936a-4f75-49e6-9a64-f459f5f8ac3d";

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
            Assert.AreEqual(expectedId, l.MoxiWorksListingId);
        }

        [Test]
        public void GetAgentsByCompany()
        {
            var d = new DateTime(2017, 1, 1, 00, 00, 00);
            var results = new List<AgentResults> {Client.GetAgentsUpdatedSince("windermere", d)};
            results.Add(Client.GetAgentsUpdatedSince("windermere", d, 2, results[0].TotalPages));

            Assert.AreEqual(results[0].TotalPages, results[1].TotalPages);
            Assert.AreNotEqual(results[0].PageNumber, results[1].PageNumber);
            results[0].Agents.ForEach(a => Console.WriteLine(a.Uuid));

        }

        [Test]
        public void GetCompany()
        {
            var id = "windermere";
            var c = Client.GetCompany("windermere");
            Assert.AreEqual(id, c.MoxiWorksCompanyId);
        }

        [Test]
        public void ContactCrudOperations()
        {
            var fakeContact = GetFakerContactBuilder();
            var c = fakeContact.Generate();
            c.PartnerContactId = Guid.NewGuid().ToString();
           
            c.AgentUuid = MOXI_WORKS_AGENT_ID;

            var created = Client.CreateContact(c);

            // testing create
            Assert.AreEqual(c.PartnerContactId, created.PartnerContactId, "Create PartnerContactId did not match");
            Assert.AreEqual(c.MoxiWorksAgentId, created.MoxiWorksAgentId, "Create MoxiWorksAgentId did not match");

            // test update 
            var old_address = created.HomeStreetAddress;
            var expected_address = "1234 happy lane";
            created.HomeStreetAddress = expected_address;
            var updated = Client.UpdateContact(created);

            Assert.AreEqual(expected_address, updated.HomeStreetAddress, "Update did not match");

            // test get
            var result = Client.GetContact(updated.AgentUuid, AgentIdType.AgentUuid, updated.PartnerContactId);

            Assert.AreNotEqual(old_address, result.HomeStreetAddress, "get returned incorrect address");
            Assert.AreEqual(updated.HomeStreetAddress, result.HomeStreetAddress, "get returned incorrect address");



        }

        [Test]
        public void BuyerTransactionCrudOperations()
        {
            var fakeContact = GetFakerContactBuilder();
            var c = fakeContact.Generate();
            c.PartnerContactId = Guid.NewGuid().ToString();
           
            c.AgentUuid = MOXI_WORKS_AGENT_ID;

            var contact = Client.CreateContact(c);
            
            
            var fakeBuyerTransaction = GetBogusContactBuilder();
            var b = fakeBuyerTransaction.Generate();
            b.PartnerContactId = contact.PartnerContactId;
            b.AgentUuid = MOXI_WORKS_AGENT_ID;
            

            var created = Client.CreateBuyerTransaction(b);

            // testing create
            Assert.AreEqual(b.PartnerContactId, created.PartnerContactId, "Create PartnerContactId did not match");
            Assert.AreEqual(b.MoxiWorksAgentId, created.MoxiWorksAgentId, "Create MoxiWorksAgentId did not match");


            // get transaction
            var result = Client.GetBuyerTransaction(created.AgentUuid, AgentIdType.AgentUuid,
                created.MoxiWorksTransactionId);
            
            Assert.IsNotNull(result);
            
            // update transaction
            result.Address = "12345 happy place";
            var updated = Client.UpdateBuyerTransaction(result);
            Assert.AreEqual(updated.Address, result.Address);
           

        }

        [Test]
        public void GetResultListOfBuyerTransactions()
        {
                   
            var results = Client.GetBuyerTransactions(MOXI_WORKS_AGENT_ID,AgentIdType.AgentUuid);
            
            Assert.IsNotNull(results.PageNumber); 
            Assert.IsNotNull(results.TotalPages);
            
//            string []  transactions = {@"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae410937"",""moxi_works_contact_id"":""c38f1c36-e98e-43bf-9376-798fb3ad930b"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""MLS Brer Bear - buyer"",""address"":""0 Blue Ridge Rd"",""city"":""29 Palms"",""state"":""CA"",""zip_code"":""92277"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":""1"",""mls_number"":""DC13102309"",""start_timestamp"":null,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae437030"",""moxi_works_contact_id"":""134d90c6-0140-4f16-af75-3b574c55baf2"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":null,""address"":null,""city"":null,""state"":null,""zip_code"":null,""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":null,""start_timestamp"":null,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae437059"",""moxi_works_contact_id"":""5463870a-c079-40f9-9ef9-1e3b12b976f3"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":null,""address"":null,""city"":null,""state"":null,""zip_code"":null,""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":null,""start_timestamp"":null,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae438366"",""moxi_works_contact_id"":""e4acc7e5-a480-4dae-85ac-ab6926af31a3"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""Johan - buyer"",""address"":""3810 46th Ave NE"",""city"":""Seattle"",""state"":""WA"",""zip_code"":""98105"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""1140285"",""start_timestamp"":null,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae43776d"",""moxi_works_contact_id"":""bf4cb097-1725-4036-b270-856e62bbcc91"",""stage"":5,""stage_name"":""complete"",""is_mls_transaction"":false,""partner_contact_id"":null,""notes"":null,""transaction_name"":""daddy yankee - buyer"",""address"":""sjdhdhshshshhsgh"",""city"":""rr"",""state"":""ww"",""zip_code"":""87654"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":""dfghb"",""mls_number"":null,""start_timestamp"":1490818045,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":543678.0,""closing_timestamp"":1490770800}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae437d78"",""moxi_works_contact_id"":""bfdca6ae-5a83-4ad5-8f74-dcd56f38f30a"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""iris blue - buyer"",""address"":null,""city"":null,""state"":null,""zip_code"":null,""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""1078749"",""start_timestamp"":null,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae41346d"",""moxi_works_contact_id"":""05ec940e-3266-4b08-8d23-bebc8e816195"",""stage"":5,""stage_name"":""complete"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""0513 1431 LAEmailUser   - buyer"",""address"":""1527 Glen Oaks Boulevard"",""city"":""Pasadena"",""state"":""CA"",""zip_code"":""91105"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""AR14194104"",""start_timestamp"":null,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae4134b5"",""moxi_works_contact_id"":""f4052ddd-337c-4775-bc97-f7c8e32967ff"",""stage"":4,""stage_name"":""pending"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""101  dalmatians  - buyer"",""address"":""2241 Carlyle Place"",""city"":""Los Angeles"",""state"":""CA"",""zip_code"":""90065"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""WS13113509"",""start_timestamp"":null,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae4109ba"",""moxi_works_contact_id"":""c38f1c36-e98e-43bf-9376-798fb3ad930b"",""stage"":4,""stage_name"":""pending"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":""test"",""transaction_name"":""NO-MLS Brer Bear - buyer"",""address"":""2241 Carlyle Place"",""city"":""Los Angeles"",""state"":""CA"",""zip_code"":""90065"",""min_sqft"":3000,""max_sqft"":null,""min_beds"":3.0,""max_beds"":null,""min_baths"":6.0,""max_baths"":null,""area_of_interest"":""1"",""mls_number"":""WS13113509"",""start_timestamp"":null,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae4133e7"",""moxi_works_contact_id"":""bb93e5bf-b4a2-4ac1-b2a4-fa17125b814f"",""stage"":5,""stage_name"":""complete"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""0511 1008 LAEmailUser   - buyer"",""address"":""1527 Glen Oaks Boulevard"",""city"":""Pasadena"",""state"":""CA"",""zip_code"":""91105"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""AR14194104"",""start_timestamp"":null,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae411291"",""moxi_works_contact_id"":""84c102c0-9150-4c21-95ed-eb16f7f1e5eb"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":false,""partner_contact_id"":null,""notes"":null,""transaction_name"":""Alison Smith - buyer"",""address"":null,""city"":null,""state"":null,""zip_code"":null,""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":null,""start_timestamp"":1422476040,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae412dcd"",""moxi_works_contact_id"":""6bdfd8e0-155f-42cf-b890-475fd0437dc7"",""stage"":5,""stage_name"":""complete"",""is_mls_transaction"":false,""partner_contact_id"":null,""notes"":null,""transaction_name"":""Andrew  Fukuyama  - buyer"",""address"":""800 Front St S"",""city"":""Issaquah"",""state"":""WA"",""zip_code"":""98027"",""min_sqft"":1250,""max_sqft"":null,""min_beds"":3.0,""max_beds"":null,""min_baths"":4.0,""max_baths"":null,""area_of_interest"":""98027"",""mls_number"":null,""start_timestamp"":1428942860,""commission_percentage"":null,""commission_flat_fee"":2500.0,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":200000.0,""closing_timestamp"":1427871600}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae4384be"",""moxi_works_contact_id"":""686b65ad-0062-4ff6-90e1-0e16f6fe4cd8"",""stage"":4,""stage_name"":""pending"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""01061059 TaskCTAtester - buyer"",""address"":""1748 Hillcrest Avenue"",""city"":""Glendale"",""state"":""CA"",""zip_code"":""91202"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""316010602"",""start_timestamp"":1500676801,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae4378a2"",""moxi_works_contact_id"":""527801b5-0e48-42e5-b617-2dea4ebf236c"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""fnHCregasc03301045 lnHCregasc03301045 - buyer"",""address"":null,""city"":null,""state"":null,""zip_code"":null,""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":null,""start_timestamp"":null,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae438585"",""moxi_works_contact_id"":""89370f9a-d73b-4fbf-8f14-80c78d0164a3"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""03291330 TaskCTAtester - buyer"",""address"":""6725 SE 2nd St"",""city"":""Renton"",""state"":""WA"",""zip_code"":""98059"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""4321"",""start_timestamp"":null,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae432f4d"",""moxi_works_contact_id"":""fd2d6437-f531-4038-a14f-d38463469841"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""Across the Universe Sr - buyer"",""address"":""0 Crown Ave"",""city"":""Coupeville"",""state"":""WA"",""zip_code"":""98239"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""6346"",""start_timestamp"":null,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae43000d"",""moxi_works_contact_id"":""97da138e-76d8-4bfb-9359-a10e018d5c5f"",""stage"":5,""stage_name"":""complete"",""is_mls_transaction"":false,""partner_contact_id"":null,""notes"":""Its not about my schatz arbeist there...I liked this place.Lovely place,i felt friendshipness... Gg"",""transaction_name"":""Closed - buyer - Non-MLS"",""address"":""Wichernstraße 10"",""city"":""ULM"",""state"":""Germany"",""zip_code"":""89073"",""min_sqft"":null,""max_sqft"":12365,""min_beds"":null,""max_beds"":3.0,""min_baths"":null,""max_baths"":5.0,""area_of_interest"":""Einstein Café"",""mls_number"":null,""start_timestamp"":1470083178,""commission_percentage"":null,""commission_flat_fee"":321.0,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":12345678.0,""closing_timestamp"":1472799600}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae417192"",""moxi_works_contact_id"":""aebca301-bae8-4bce-8323-74e1f4524489"",""stage"":3,""stage_name"":""active"",""is_mls_transaction"":false,""partner_contact_id"":null,""notes"":null,""transaction_name"":""Zillow Custom2 - seller"",""address"":null,""city"":null,""state"":null,""zip_code"":null,""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":null,""start_timestamp"":null,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae437fd9"",""moxi_works_contact_id"":""87edbcd4-6d09-4079-bc25-b0c9c30589c5"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""0417936 TaskCTAtester - buyer"",""address"":null,""city"":null,""state"":null,""zip_code"":null,""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":null,""start_timestamp"":null,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae43832d"",""moxi_works_contact_id"":""cfaf0bb6-c08b-4c37-98c4-c06fc9375cc2"",""stage"":4,""stage_name"":""pending"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""030310x14 Special Dates - buyer"",""address"":""6408 Phinney Ave N"",""city"":""Seattle"",""state"":""WA"",""zip_code"":""98103"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""1124079"",""start_timestamp"":1498237390,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}",
//  @"{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae438a0e"",""moxi_works_contact_id"":""3769f5b0-fa72-45be-9800-adc3bd47ee90"",""stage"":3,""stage_name"":""active"",""is_mls_transaction"":false,""partner_contact_id"":null,""notes"":""Vero est officiis inventore."",""transaction_name"":""Hunter Littel - buyer"",""address"":""7998 Bosco Manor"",""city"":""Lowellton"",""state"":""Montana"",""zip_code"":""43907"",""min_sqft"":0,""max_sqft"":0,""min_beds"":0.0,""max_beds"":0.0,""min_baths"":0.0,""max_baths"":0.0,""area_of_interest"":null,""mls_number"":null,""start_timestamp"":0,""commission_percentage"":null,""commission_flat_fee"":3000.0,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}"};
//
//            foreach (var t in transactions)
//            {
//                Console.Write(t);
//                JsonConvert.DeserializeObject<BuyerTransactionResults>(t);   
//            } 
//            
//            var str = @"{""page_number"":1,""total_pages"":4,""transactions"":[{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae410937"",""moxi_works_contact_id"":""c38f1c36-e98e-43bf-9376-798fb3ad930b"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""MLS Brer Bear - buyer"",""address"":""0 Blue Ridge Rd"",""city"":""29 Palms"",""state"":""CA"",""zip_code"":""92277"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":""1"",""mls_number"":""DC13102309"",""start_timestamp"":null,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae437030"",""moxi_works_contact_id"":""134d90c6-0140-4f16-af75-3b574c55baf2"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":null,""address"":null,""city"":null,""state"":null,""zip_code"":null,""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":null,""start_timestamp"":null,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae437059"",""moxi_works_contact_id"":""5463870a-c079-40f9-9ef9-1e3b12b976f3"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":null,""address"":null,""city"":null,""state"":null,""zip_code"":null,""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":null,""start_timestamp"":null,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae438366"",""moxi_works_contact_id"":""e4acc7e5-a480-4dae-85ac-ab6926af31a3"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""Johan - buyer"",""address"":""3810 46th Ave NE"",""city"":""Seattle"",""state"":""WA"",""zip_code"":""98105"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""1140285"",""start_timestamp"":null,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae43776d"",""moxi_works_contact_id"":""bf4cb097-1725-4036-b270-856e62bbcc91"",""stage"":5,""stage_name"":""complete"",""is_mls_transaction"":false,""partner_contact_id"":null,""notes"":null,""transaction_name"":""daddy yankee - buyer"",""address"":""sjdhdhshshshhsgh"",""city"":""rr"",""state"":""ww"",""zip_code"":""87654"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":""dfghb"",""mls_number"":null,""start_timestamp"":1490818045,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":543678.0,""closing_timestamp"":1490770800},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae437d78"",""moxi_works_contact_id"":""bfdca6ae-5a83-4ad5-8f74-dcd56f38f30a"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""iris blue - buyer"",""address"":null,""city"":null,""state"":null,""zip_code"":null,""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""1078749"",""start_timestamp"":null,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae41346d"",""moxi_works_contact_id"":""05ec940e-3266-4b08-8d23-bebc8e816195"",""stage"":5,""stage_name"":""complete"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""0513 1431 LAEmailUser   - buyer"",""address"":""1527 Glen Oaks Boulevard"",""city"":""Pasadena"",""state"":""CA"",""zip_code"":""91105"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""AR14194104"",""start_timestamp"":null,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae4134b5"",""moxi_works_contact_id"":""f4052ddd-337c-4775-bc97-f7c8e32967ff"",""stage"":4,""stage_name"":""pending"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""101  dalmatians  - buyer"",""address"":""2241 Carlyle Place"",""city"":""Los Angeles"",""state"":""CA"",""zip_code"":""90065"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""WS13113509"",""start_timestamp"":null,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae4109ba"",""moxi_works_contact_id"":""c38f1c36-e98e-43bf-9376-798fb3ad930b"",""stage"":4,""stage_name"":""pending"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":""test"",""transaction_name"":""NO-MLS Brer Bear - buyer"",""address"":""2241 Carlyle Place"",""city"":""Los Angeles"",""state"":""CA"",""zip_code"":""90065"",""min_sqft"":3000,""max_sqft"":null,""min_beds"":3.0,""max_beds"":null,""min_baths"":6.0,""max_baths"":null,""area_of_interest"":""1"",""mls_number"":""WS13113509"",""start_timestamp"":null,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae4133e7"",""moxi_works_contact_id"":""bb93e5bf-b4a2-4ac1-b2a4-fa17125b814f"",""stage"":5,""stage_name"":""complete"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""0511 1008 LAEmailUser   - buyer"",""address"":""1527 Glen Oaks Boulevard"",""city"":""Pasadena"",""state"":""CA"",""zip_code"":""91105"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""AR14194104"",""start_timestamp"":null,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae411291"",""moxi_works_contact_id"":""84c102c0-9150-4c21-95ed-eb16f7f1e5eb"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":false,""partner_contact_id"":null,""notes"":null,""transaction_name"":""Alison Smith - buyer"",""address"":null,""city"":null,""state"":null,""zip_code"":null,""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":null,""start_timestamp"":1422476040,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae412dcd"",""moxi_works_contact_id"":""6bdfd8e0-155f-42cf-b890-475fd0437dc7"",""stage"":5,""stage_name"":""complete"",""is_mls_transaction"":false,""partner_contact_id"":null,""notes"":null,""transaction_name"":""Andrew  Fukuyama  - buyer"",""address"":""800 Front St S"",""city"":""Issaquah"",""state"":""WA"",""zip_code"":""98027"",""min_sqft"":1250,""max_sqft"":null,""min_beds"":3.0,""max_beds"":null,""min_baths"":4.0,""max_baths"":null,""area_of_interest"":""98027"",""mls_number"":null,""start_timestamp"":1428942860,""commission_percentage"":null,""commission_flat_fee"":2500.0,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":200000.0,""closing_timestamp"":1427871600},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae4384be"",""moxi_works_contact_id"":""686b65ad-0062-4ff6-90e1-0e16f6fe4cd8"",""stage"":4,""stage_name"":""pending"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""01061059 TaskCTAtester - buyer"",""address"":""1748 Hillcrest Avenue"",""city"":""Glendale"",""state"":""CA"",""zip_code"":""91202"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""316010602"",""start_timestamp"":1500676801,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae4378a2"",""moxi_works_contact_id"":""527801b5-0e48-42e5-b617-2dea4ebf236c"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""fnHCregasc03301045 lnHCregasc03301045 - buyer"",""address"":null,""city"":null,""state"":null,""zip_code"":null,""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":null,""start_timestamp"":null,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae438585"",""moxi_works_contact_id"":""89370f9a-d73b-4fbf-8f14-80c78d0164a3"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""03291330 TaskCTAtester - buyer"",""address"":""6725 SE 2nd St"",""city"":""Renton"",""state"":""WA"",""zip_code"":""98059"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""4321"",""start_timestamp"":null,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae432f4d"",""moxi_works_contact_id"":""fd2d6437-f531-4038-a14f-d38463469841"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""Across the Universe Sr - buyer"",""address"":""0 Crown Ave"",""city"":""Coupeville"",""state"":""WA"",""zip_code"":""98239"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""6346"",""start_timestamp"":null,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae43000d"",""moxi_works_contact_id"":""97da138e-76d8-4bfb-9359-a10e018d5c5f"",""stage"":5,""stage_name"":""complete"",""is_mls_transaction"":false,""partner_contact_id"":null,""notes"":""Its not about my schatz arbeist there...I liked this place.Lovely place,i felt friendshipness... Gg"",""transaction_name"":""Closed - buyer - Non-MLS"",""address"":""Wichernstraße 10"",""city"":""ULM"",""state"":""Germany"",""zip_code"":""89073"",""min_sqft"":null,""max_sqft"":12365,""min_beds"":null,""max_beds"":3.0,""min_baths"":null,""max_baths"":5.0,""area_of_interest"":""Einstein Café"",""mls_number"":null,""start_timestamp"":1470083178,""commission_percentage"":null,""commission_flat_fee"":321.0,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":12345678.0,""closing_timestamp"":1472799600},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae417192"",""moxi_works_contact_id"":""aebca301-bae8-4bce-8323-74e1f4524489"",""stage"":3,""stage_name"":""active"",""is_mls_transaction"":false,""partner_contact_id"":null,""notes"":null,""transaction_name"":""Zillow Custom2 - seller"",""address"":null,""city"":null,""state"":null,""zip_code"":null,""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":null,""start_timestamp"":null,""commission_percentage"":null,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae437fd9"",""moxi_works_contact_id"":""87edbcd4-6d09-4079-bc25-b0c9c30589c5"",""stage"":2,""stage_name"":""configured"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""0417936 TaskCTAtester - buyer"",""address"":null,""city"":null,""state"":null,""zip_code"":null,""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":null,""start_timestamp"":null,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae43832d"",""moxi_works_contact_id"":""cfaf0bb6-c08b-4c37-98c4-c06fc9375cc2"",""stage"":4,""stage_name"":""pending"",""is_mls_transaction"":true,""partner_contact_id"":null,""notes"":null,""transaction_name"":""030310x14 Special Dates - buyer"",""address"":""6408 Phinney Ave N"",""city"":""Seattle"",""state"":""WA"",""zip_code"":""98103"",""min_sqft"":null,""max_sqft"":null,""min_beds"":null,""max_beds"":null,""min_baths"":null,""max_baths"":null,""area_of_interest"":null,""mls_number"":""1124079"",""start_timestamp"":1498237390,""commission_percentage"":3.0,""commission_flat_fee"":null,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null},{""agent_uuid"":""5872936a-4f75-49e6-9a64-f459f5f8ac3d"",""moxi_works_transaction_id"":""5ce0e9a5-6015-fec5-aadf-a328ae438a0e"",""moxi_works_contact_id"":""3769f5b0-fa72-45be-9800-adc3bd47ee90"",""stage"":3,""stage_name"":""active"",""is_mls_transaction"":false,""partner_contact_id"":null,""notes"":""Vero est officiis inventore."",""transaction_name"":""Hunter Littel - buyer"",""address"":""7998 Bosco Manor"",""city"":""Lowellton"",""state"":""Montana"",""zip_code"":""43907"",""min_sqft"":0,""max_sqft"":0,""min_beds"":0.0,""max_beds"":0.0,""min_baths"":0.0,""max_baths"":0.0,""area_of_interest"":null,""mls_number"":null,""start_timestamp"":0,""commission_percentage"":null,""commission_flat_fee"":3000.0,""target_price"":null,""min_price"":null,""max_price"":null,""closing_price"":null,""closing_timestamp"":null}]}";
//            JsonConvert.DeserializeObject<BuyerTransactionResults>(str);   
//           
           // Assert.IsNotEmpty(results.Transactions);


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

        private Faker<BuyerTransaction> GetBogusContactBuilder()
        {
            return new Faker<BuyerTransaction>()
                .RuleFor(bt => bt.Notes, f => f.Lorem.Sentence())
                .RuleFor(bt => bt.Address, f => f.Address.StreetAddress())
                .RuleFor(bt => bt.City, f => f.Address.City())
                .RuleFor(bt => bt.State, f => f.Address.State())
                .RuleFor(bt => bt.ZipCode, f => f.Address.ZipCode())
                .RuleFor(bt => bt.CommissionFlatFee, 3000)
                .RuleFor(bt => bt.TransactionName, f => f.Name.FullName() + " - buyer");

        }





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