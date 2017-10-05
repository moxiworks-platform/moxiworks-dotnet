using System;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Web.UI;
using Newtonsoft.Json;
using static  MoxiWorks.Platform.MoxiWorksClient; 
namespace MoxiWorks.Platform
{
    public class Client : MoxiWorksClient
    {

        
        public  int GetTimeStamp(DateTime value)
        {
            return (int)Math.Truncate(value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
        }

        public  Response<ListingResults> GetListingsUpdateSince(string companyId, DateTime updateSince,
            string lastMoxiWorksListingId = null, int perpage = 10)
        {
            var timestamp = GetTimeStamp(updateSince);
            var builder = new UriBuilder("/listings");
            builder.AddQueryParameter("moxi_works_company_id", companyId);
            builder.AddQueryParameter("updated_since", timestamp.ToString());
            builder.AddQueryParameter("per_page", perpage.ToString());
            builder.AddQueryParameter("last_moxi_works_listing_id", lastMoxiWorksListingId);

            return GetRequest<ListingResults>(builder.GetUrl());
        }

        public  Response<Listing> GetListing(string companyId, string moxiWorksListingId)
        {
            var builder = new UriBuilder($"/listings/{moxiWorksListingId}");
            builder.AddQueryParameter("moxi_works_company_id", companyId);
            return GetRequest<Listing>(builder.GetUrl());

        }

        public  Response<Agent> GetAgent(string moxiWorksAgentId, string companyId)
        {
            var builder = new UriBuilder($"/agent/{moxiWorksAgentId}");
            builder.AddQueryParameter("moxi_works_company_id", companyId);
            return GetRequest<Agent>(builder.GetUrl());
        }

        public  Response<AgentResults> GetAgentsUpdatedSince(string moxiWorksCompanyId, DateTime updatedSince,
            int? totalPages = null, int pageNumber = 1)
        {
            var builder = new UriBuilder("/agents");
            builder.AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId);

            var timestamp = GetTimeStamp(updatedSince);
            builder.AddQueryParameter("updated_since", timestamp);
            builder.AddQueryParameter("total_pages", totalPages);
            builder.AddQueryParameter("page_number", pageNumber);

            return GetRequest<AgentResults>(builder.GetUrl());
        }

        public  Response<Company> GetCompany(string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"/companies/{moxiWorksCompanyId}");
            return GetRequest<Company>(builder.GetUrl());
        }

        public  Response<Contact> GetContact(string agentId, AgentIdType agentIdType, string partnerContactId)
        {
            var builder = new UriBuilder($"/contacts/{partnerContactId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            return GetRequest<Contact>(builder.GetUrl());
        }

        public  Response<Contact> CreateContact(Contact contact)
        {
            var builder = new UriBuilder($"/contacts");

            return PostRequest(builder.GetUrl(), contact);
        }

        public  Response<Contact> UpdateContact(Contact contact)
        {
            var builder = new UriBuilder($"/contacts/{contact.PartnerContactId}");
            return PutRequest(builder.GetUrl(), contact);

        }

        public  Response<ContactResults> GetContactResultsAgentUuid(string AgentId, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            return GetContactsUpdatedSince(AgentId, AgentIdType.AgentUuid, emailAddress, contactName, phoneNumber,
                updatedSince, pageNumber);
        }

        public  Response<ContactResults> GetContactResultsMoxiWorksagentId(string AgentId, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            return GetContactsUpdatedSince(AgentId, AgentIdType.MoxiWorksagentId, emailAddress, contactName,
                phoneNumber, updatedSince, pageNumber);
        }

        public  Response<ContactResults> GetContactsUpdatedSince(string AgentId, AgentIdType agentIdType,
            string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {

            var builder = new UriBuilder("/contacts/");

            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                AgentId);


            if (updatedSince != null)
            {
                builder.AddQueryParameter("updated_since", GetTimeStamp(updatedSince.Value).ToString());
            }

            builder.AddQueryParameter("email_address", emailAddress);
            builder.AddQueryParameter("contact_name", contactName);
            builder.AddQueryParameter("phone_number", phoneNumber);
            builder.AddQueryParameter("page_number", pageNumber);
            return GetRequest<ContactResults>(builder.GetUrl());
        }

        public  Response<BuyerTransaction> CreateBuyerTransaction(BuyerTransaction buyerTransaction)
        {
            var builder = new UriBuilder("/buyer_transactions/");
            return PostRequest(builder.GetUrl(), buyerTransaction);
        }

        public  Response<BuyerTransaction> UpdateBuyerTransaction(BuyerTransaction buyerTransaction)
        {
            var builder =
                new UriBuilder(
                    $"/buyer_transactions/{buyerTransaction.MoxiWorksTransactionId}");
            return PutRequest(builder.GetUrl(), buyerTransaction);
        }

        public  Response<BuyerTransaction> GetBuyerTransaction(string agentId, AgentIdType agentIdType,
            string moxiworksTransactionId)
        {
            var builder =
                new UriBuilder($"/buyer_transactions/{moxiworksTransactionId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            return GetRequest<BuyerTransaction>(builder.GetUrl());
        }

        public  Response<BuyerTransactionResults> GetBuyerTransactions(string agentId, AgentIdType agentIdType,
            string moxiworksContactId = null, string partnerContactId = null, int pageNumber = 1)
        {
            var builder = new UriBuilder("/buyer_transactions/");

            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            builder.AddQueryParameter("partner_contact_id", partnerContactId);
            builder.AddQueryParameter("moxi_works_contact_id", moxiworksContactId);
            builder.AddQueryParameter("page_number", pageNumber);

            return GetRequest<BuyerTransactionResults>(builder.GetUrl());
        }

        public  Response<ActionLog> CreateActionLog(ActionLog log)
        {
            var builder = new UriBuilder("/action_logs/");

            return PostRequest(builder.GetUrl(), log);
        }

        public  Response<ActionLogResults> GetActionLogs(string agentId, AgentIdType agentIdType, string partnerContactId)
        {
            var builder = new UriBuilder("/action_logs/");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
            builder.AddQueryParameter("partner_contact_id", partnerContactId);

            return GetRequest<ActionLogResults>(builder.GetUrl());
        }

        public  Response<Brand> GetCompanyBrand(string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"/brands/{moxiWorksCompanyId}");
            return GetRequest<Brand>(builder.GetUrl());
        }

        public  Response<Brand> GetFullCompanyBranding(string moxiworksCompanyId, string moxiworksAgentId)
        {
            var builder = new UriBuilder($"/brands/{moxiworksCompanyId}");
            builder.AddQueryParameter("moxi_works_agent_id", moxiworksAgentId);
            return GetRequest<Brand>(builder.GetUrl());
        }


        public  Response<EmailCampaignResults> GetEmailCampaign(string agentId, AgentIdType agentIdType,
            string partnerContactId)
        {
            var builder = new UriBuilder("/email_campaigns");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            builder.AddQueryParameter("partner_contact_id", partnerContactId);
           
            var res = GetRequest<List<EmailCampaign>>(builder.GetUrl());
            
            var campaigns = new EmailCampaignResults
            {
                EmailCampaigns = res.Item
            };

            var response = new Response<EmailCampaignResults>
            {
                Errors = res.Errors,
                Item = campaigns
            };
            
            return response; 

        }

        public  Response<Event> CreateEvent(Event cmaEvent)
        {
            var builder = new UriBuilder("/events");
            
            return PostRequest(builder.GetUrl(),cmaEvent);
        }

        public  Response<Event> UpdateEvent(Event updateEvent)
        {
            var builder = new UriBuilder($"/events/{updateEvent.PartnerEventId}");
            return PutRequest(builder.GetUrl(), updateEvent);
        }

        public  Response<Event> GetEvent(string agentId, AgentIdType agentIdType, string partnerEventId)
        {
            var builder = new UriBuilder($"/events/{partnerEventId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
            return GetRequest<Event>(builder.GetUrl());
        }

        public  Response<EventResults> GetEventsByDate(string agentId, AgentIdType agentIdType, int eventStart, int eventEnd)
        {
           var builder = new UriBuilder($"/events");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
            builder.AddQueryParameter("date_start",eventStart);
            builder.AddQueryParameter("date_end",eventEnd);

            var resultsList = GetRequest<List<EventDateList>>(builder.GetUrl());
  
            var results =  new EventResults
            {
                EventListDates = resultsList.Item
            };

            return new Response<EventResults>
            {
                Errors = resultsList.Errors,
                Item = results
            };
        }

        public  Response<EventDeleteResult> DeleteEvent(string agentId, AgentIdType agentIdType, string eventId)
        {
            var builder = new UriBuilder($"/events/{eventId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
                
            
            return DeleteRequest<EventDeleteResult>(builder.GetUrl());

        }

        public  Response<Group> GetGroup(string agentId, AgentIdType agentIdType, string moxiWorksGroupId)
        {
            var builder = new UriBuilder($"/groups/{moxiWorksGroupId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
                
            return GetRequest<Group>(builder.GetUrl());
            
        }

        public  Response<ICollection<GroupItem>> GetGroups(string agentId, AgentIdType agentIdType, string name = null)
        {
            var builder = new UriBuilder("/groups");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
            builder.AddQueryParameter("name",name);
            var results = GetRequest <List<GroupItem>>(builder.GetUrl());

            return new Response<ICollection<GroupItem>>
            {
                Errors = results.Errors, 
                Item = results.Item
            };
        }

        public  Response<BuyerTransaction> CreateSellerTransaction(BuyerTransaction buyerTransaction)
        {
            var builder = new UriBuilder("/buyer_transactions/");
            return PostRequest(builder.GetUrl(), buyerTransaction);
        }

        public  Response<SellerTransaction> UpdateSellerTransaction(SellerTransaction sellerTransaction)
        {
            var builder =
                new UriBuilder(
                    $"/buyer_transactions/{sellerTransaction.MoxiWorksTransactionId}");
            return PutRequest(builder.GetUrl(), sellerTransaction);
        }

        public  Response<SellerTransaction> GetSellerTransaction(string agentId, AgentIdType agentIdType,
            string moxiworksTransactionId)
        {
            var builder =
                new UriBuilder($"/buyer_transactions/{moxiworksTransactionId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            return GetRequest<SellerTransaction>(builder.GetUrl());
        }

        public  Response<SellerTransactionResults> GetSellerTransactions(string agentId, AgentIdType agentIdType,
            string moxiworksContactId = null, string partnerContactId = null, int pageNumber = 1)
        {
            var builder = new UriBuilder("/buyer_transactions/");

            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            builder.AddQueryParameter("partner_contact_id", partnerContactId);
            builder.AddQueryParameter("moxi_works_contact_id", moxiworksContactId);
            builder.AddQueryParameter("page_number", pageNumber);

            return GetRequest<SellerTransactionResults>(builder.GetUrl());
        }

    }

    /*
    agent_uuid=12345678-1234-1234-1234-1234567890ab&partner_contact_id=abc982cdf345&contact_name=Billy+Football&gender=m&primary_email_address=johnny%40football.foo&secondary_email_address=fooball%40johnnyshead.lost&primary_phone_number=123123213&secondary_phone_number=2929292922&home_street_address=1234+Winterfell+Way&home_city=Cityville&home_state=Stateland&home_zip=12345&home_country=Westeros&job_title=Junior+Bacon+Burner&occupation=Chef&property_url=http%3A%2F%2Fteh.property.is%2Fhere&property_mls_id=123abc&property_street_address=1234+here+ave.&property_city=anywhereville&property_state=anystate&property_zip=918928&property_beds=21&property_baths=12.75&property_list_price=1231213&property_listing_status=Active&property_photo_url=http%3A%2F%2Fthis.is%2Fthe%2Fphoto.jpg&search_city=searchville&search_state=ofconfusion&search_zip=92882&search_min_beds=12&search_min_baths=4&search_min_price=1234&search_max_price=22324&search_min_sq_ft=1234&search_max_sq_ft=23455&search_min_lot_size=29299&search_max_lot_size=292929&search_min_year_built=1999&search_max_year_built=2004&search_property_types=Condo%2C+Single-Family&note=whatevers2009
    */
}

