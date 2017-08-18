using System;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Web.Compilation;
using System.Web.UI;
using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    public static class Client
    {
        private static HttpClient _context;
        public static HttpClient Context => _context ?? (_context = GetContext());


        private static CookieContainer _cookies;
        public static CookieContainer Cookies => _cookies ?? (_cookies = new CookieContainer());

        public static void ResetClient()
        {
            _context = GetContext();
        }

        private static string Identifier { get; } = "5d39ba58-bfc3-11e5-a4e3-d0e1408e8026";

        private static string Secret { get; } = "a56sthhidTlUsLyp8eFZBQtt";

        private static HttpClientHandler _handler;
        
        private static HttpClient GetContext()
        {
            _handler = new HttpClientHandler
            {
                CookieContainer = Cookies,
                UseCookies = true
            };
            return new HttpClient(_handler);
        }

        public static int GetTimeStamp(DateTime value)
        {
           return (int)Math.Truncate((value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
        }

        public static HttpClient RequestClient()
        {
            var client = Context;  
            var cred = new Credentials(Identifier, Secret);
            var auth = AuthenticationHeaderValue.Parse("Basic " + cred.ToBase64());
            client.DefaultRequestHeaders.Authorization = auth;
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.moxi-platform+json;version=1");

            if (!Session.Instance.IsSessionCookieSet) return client;
            
            var cookie = Session.Instance.SessionCookie; 
            client.DefaultRequestHeaders.Add("Cookie", $"{cookie.Name}={cookie.Value}; path=/; HttpOnly");

            return client; 
        }
        
        public static T Request<T>(string url)
        {
            var client = RequestClient(); 
            var result = client.GetAsync(new Uri(url)).Result;
            var content = result.Content;

            if (!Session.Instance.IsSessionCookieSet)
            {
                Session.Instance.SessionCookie = _handler.CookieContainer.GetCookies(new Uri("https://api-qa.moxiworks.com"))["_wms_svc_public_session"];
            }

            return JsonConvert.DeserializeObject<T>(content.ReadAsStringAsync().Result);  
        }

        public static ListingResults GetListingsUpdateSince(string companyId,DateTime updateSince,string lastMoxiWorksListingId = null,int perpage = 10 )
        {
            var timestamp = GetTimeStamp(updateSince);
            var builder = new UriBuilder("https://api-qa.moxiworks.com/api/listings");
            builder.AddQueryParameter("moxi_works_company_id",companyId);
            builder.AddQueryParameter("updated_since", timestamp.ToString());
            builder.AddQueryParameter("per_page",perpage.ToString());
            builder.AddQueryParameter("last_moxi_works_listing_id",lastMoxiWorksListingId);

            return Request<ListingResults>(builder.getUrl()); 
        }

        public static Listing GetListing(string companyId, string moxiWorksListingId)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/listings/{moxiWorksListingId}");
            builder.AddQueryParameter("moxi_works_company_id",companyId);
            return Request<Listing>(builder.getUrl());

        }

        public static Agent GetAgent(string moxiWorksAgentId,  string companyId)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/agent/{moxiWorksAgentId}");
            builder.AddQueryParameter("moxi_works_company_id",companyId);
            return Request<Agent>(builder.getUrl());
        }

        public static AgentResults GetAgentsUpdatedSince(string moxiWorksCompanyId, DateTime updatedSince ,int? totalPages = null, int pageNumber = 1 )
        {
            var builder = new UriBuilder("https://api-qa.moxiworks.com/api/agents");
            builder.AddQueryParameter("moxi_works_company_id",moxiWorksCompanyId);

            var timestamp = GetTimeStamp(updatedSince);
            builder.AddQueryParameter("updated_since",timestamp);
            builder.AddQueryParameter("total_pages",totalPages);
            builder.AddQueryParameter("page_number",pageNumber);
            return Request<AgentResults>(builder.getUrl());
        }

        public static Company GetCompany(string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/companies/{moxiWorksCompanyId}");
            return Request<Company>(builder.getUrl());
        }

        public static Contact GetContact(string moxiWorksAgentId, string partner_contact_id)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/contact/{partner_contact_id}");
            builder.AddQueryParameter("moxi_works_agent_id",moxiWorksAgentId);
            return Request<Contact>(builder.getUrl());
       }

        public static ContactResults GetContactsUpdatedSince(string moxi_works_agent_id, string emailAddress = null, 
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            var builder = new UriBuilder($"https://api-qa.moxiworks.com/api/{moxi_works_agent_id}");

            if (updatedSince != null)
            {
                builder.AddQueryParameter("updated_since", GetTimeStamp(updatedSince.Value).ToString());
            }

            builder.AddQueryParameter("email_address", emailAddress);
            builder.AddQueryParameter("contact_name",contactName); 
            builder.AddQueryParameter("phone_number",phoneNumber);
            builder.AddQueryParameter("page_number", pageNumber);
            return Request<ContactResults>(builder.getUrl());
        }
    }


}
