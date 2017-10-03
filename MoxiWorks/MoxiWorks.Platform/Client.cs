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
    public class Client 
    {
        public static int GetTimeStamp(DateTime value)
        {
            return (int)Math.Truncate((value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
        }

        public static ListingResults GetListingsUpdateSince(string companyId, DateTime updateSince,
            string lastMoxiWorksListingId = null, int perpage = 10)
        {
            var timestamp = GetTimeStamp(updateSince);
            var builder = new UriBuilder("https://api-qa.moxiworks.com/api/listings");
            builder.AddQueryParameter("moxi_works_company_id", companyId);
            builder.AddQueryParameter("updated_since", timestamp.ToString());
            builder.AddQueryParameter("per_page", perpage.ToString());
            builder.AddQueryParameter("last_moxi_works_listing_id", lastMoxiWorksListingId);

            return GetRequest<ListingResults>(builder.GetUrl());
        }

        public static Listing GetListing(string companyId, string moxiWorksListingId)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/listings/{moxiWorksListingId}");
            builder.AddQueryParameter("moxi_works_company_id", companyId);
            return GetRequest<Listing>(builder.GetUrl());

        }

        public static Agent GetAgent(string moxiWorksAgentId, string companyId)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/agent/{moxiWorksAgentId}");
            builder.AddQueryParameter("moxi_works_company_id", companyId);
            return GetRequest<Agent>(builder.GetUrl());
        }

        public static AgentResults GetAgentsUpdatedSince(string moxiWorksCompanyId, DateTime updatedSince,
            int? totalPages = null, int pageNumber = 1)
        {
            var builder = new UriBuilder("https://api-qa.moxiworks.com/api/agents");
            builder.AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId);

            var timestamp = GetTimeStamp(updatedSince);
            builder.AddQueryParameter("updated_since", timestamp);
            builder.AddQueryParameter("total_pages", totalPages);
            builder.AddQueryParameter("page_number", pageNumber);

            return GetRequest<AgentResults>(builder.GetUrl());
        }

        public static Company GetCompany(string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/companies/{moxiWorksCompanyId}");
            return GetRequest<Company>(builder.GetUrl());
        }

        public static Contact GetContact(string agentId, AgentIdType agentIdType, string partnerContactId)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/contacts/{partnerContactId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            return GetRequest<Contact>(builder.GetUrl());
        }

        public static Contact CreateContact(Contact contact)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/contacts");

            return PostRequest(builder.GetUrl(), contact);
        }

        public static Contact UpdateContact(Contact contact)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/contacts/{contact.PartnerContactId}");
            return PutRequest(builder.GetUrl(), contact);

        }

        public static ContactResults GetContactResultsAgentUuid(string AgentId, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            return GetContactsUpdatedSince(AgentId, AgentIdType.AgentUuid, emailAddress, contactName, phoneNumber,
                updatedSince, pageNumber);
        }

        public static ContactResults GetContactResultsMoxiWorksagentId(string AgentId, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            return GetContactsUpdatedSince(AgentId, AgentIdType.MoxiWorksagentId, emailAddress, contactName,
                phoneNumber, updatedSince, pageNumber);
        }

        public static ContactResults GetContactsUpdatedSince(string AgentId, AgentIdType agentIdType,
            string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {

            var builder = new UriBuilder("https://api-qa.moxiworks.com/api/contacts/");

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

        public static BuyerTransaction CreateBuyerTransaction(BuyerTransaction buyerTransaction)
        {
            var builder = new UriBuilder("https://api-qa.moxiworks.com/api/buyer_transactions/");
            return PostRequest(builder.GetUrl(), buyerTransaction);
        }

        public static BuyerTransaction UpdateBuyerTransaction(BuyerTransaction buyerTransaction)
        {
            var builder =
                new UriBuilder(
                    $"https://api-qa.moxiworks.com/api/buyer_transactions/{buyerTransaction.MoxiWorksTransactionId}");
            return PutRequest(builder.GetUrl(), buyerTransaction);
        }

        public static BuyerTransaction GetBuyerTransaction(string agentId, AgentIdType agentIdType,
            string moxiworksTransactionId)
        {
            var builder =
                new UriBuilder($"https://api-qa.moxiworks.com/api/buyer_transactions/{moxiworksTransactionId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            return GetRequest<BuyerTransaction>(builder.GetUrl());
        }

        public static BuyerTransactionResults GetBuyerTransactions(string agentId, AgentIdType agentIdType,
            string moxiworksContactId = null, string partnerContactId = null, int pageNumber = 1)
        {
            var builder = new UriBuilder("https://api-qa.moxiworks.com/api/buyer_transactions/");

            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            builder.AddQueryParameter("partner_contact_id", partnerContactId);
            builder.AddQueryParameter("moxi_works_contact_id", moxiworksContactId);
            builder.AddQueryParameter("page_number", pageNumber);

            return GetRequest<BuyerTransactionResults>(builder.GetUrl());
        }

        public static ActionLog CreateActionLog(ActionLog log)
        {
            var builder = new UriBuilder("https://api-qa.moxiworks.com/api/action_logs/");

            return PostRequest(builder.GetUrl(), log);
        }

        public static ActionLogResults GetActionLogs(string agentId, AgentIdType agentIdType, string partnerContactId)
        {
            var builder = new UriBuilder("https://api-qa.moxiworks.com/api/action_logs/");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
            builder.AddQueryParameter("partner_contact_id", partnerContactId);

            return GetRequest<ActionLogResults>(builder.GetUrl());
        }

        public static Brand GetCompanyBrand(string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/brands/{moxiWorksCompanyId}");
            return GetRequest<Brand>(builder.GetUrl());
        }

        public static Brand GetFullCompanyBranding(string moxiworksCompanyId, string moxiworksAgentId)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/brands/{moxiworksCompanyId}");
            builder.AddQueryParameter("moxi_works_agent_id", moxiworksAgentId);
            return GetRequest<Brand>(builder.GetUrl());
        }


        public static EmailCampaignResults GetEmailCampaign(string agentId, AgentIdType agentIdType,
            string partnerContactId)
        {
            var builder = new UriBuilder("https://api-qa.moxiworks.com/api/email_campaigns");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            builder.AddQueryParameter("partner_contact_id", partnerContactId);
            return new EmailCampaignResults
            {
                EmailCampaigns = GetRequest<EmailCampaign[]>(builder.GetUrl()).ToList()
            };

        }

        public static Event CreateEvent(Event cmaEvent)
        {
            var builder = new UriBuilder("https://api-qa.moxiworks.com/api/events");
            
            return PostRequest(builder.GetUrl(),cmaEvent);
        }

        public static Event UpdateEvent(Event updateEvent)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/events/{updateEvent.PartnerEventId}");
            return PutRequest(builder.GetUrl(), updateEvent);
        }

        public static Event GetEvent(string agentId, AgentIdType agentIdType, string partnerEventId)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/events/{partnerEventId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
            return GetRequest<Event>(builder.GetUrl());
        }

        public static EventResults GetEventsByDate(string agentId, AgentIdType agentIdType, int eventStart, int eventEnd)
        {
           var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/events");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
            builder.AddQueryParameter("date_start",eventStart);
            builder.AddQueryParameter("date_end",eventEnd);

  
            return new EventResults
            {
                EventListDates = GetRequest<List<EventDateList>>(builder.GetUrl())
            };
        }

        public static EventDeleteResult DeleteEvent(string agentId, AgentIdType agentIdType, string eventId)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/events/{eventId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
                
            
            return DeleteRequest<EventDeleteResult>(builder.GetUrl());

        }

        public static Group GetGroup(string agentId, AgentIdType agentIdType, string moxiWorksGroupId)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/groups/{moxiWorksGroupId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
                
            return GetRequest<Group>(builder.GetUrl());
            
        }

        public static ICollection<GroupItem>GetGroups(string agentId, AgentIdType agentIdType, string name = null)
        {
            var builder = new UriBuilder("https://api-qa.moxiworks.com/api/groups");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
            builder.AddQueryParameter("name",name);
            return GetRequest <List<GroupItem>>(builder.GetUrl());
        }

        public static BuyerTransaction CreateSellerTransaction(BuyerTransaction buyerTransaction)
        {
            var builder = new UriBuilder("https://api-qa.moxiworks.com/api/buyer_transactions/");
            return PostRequest(builder.GetUrl(), buyerTransaction);
        }

        public static SellerTransaction UpdateSellerTransaction(SellerTransaction sellerTransaction)
        {
            var builder =
                new UriBuilder(
                    $"https://api-qa.moxiworks.com/api/buyer_transactions/{sellerTransaction.MoxiWorksTransactionId}");
            return PutRequest(builder.GetUrl(), sellerTransaction);
        }

        public static SellerTransaction GetSellerTransaction(string agentId, AgentIdType agentIdType,
            string moxiworksTransactionId)
        {
            var builder =
                new UriBuilder($"https://api-qa.moxiworks.com/api/buyer_transactions/{moxiworksTransactionId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            return GetRequest<SellerTransaction>(builder.GetUrl());
        }

        public static SellerTransactionResults GetSellerTransactions(string agentId, AgentIdType agentIdType,
            string moxiworksContactId = null, string partnerContactId = null, int pageNumber = 1)
        {
            var builder = new UriBuilder("https://api-qa.moxiworks.com/api/buyer_transactions/");

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

