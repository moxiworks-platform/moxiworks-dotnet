using System;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
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

        public static ListingResults GetListingsUpdateSince(string companyId,DateTime updateSince,string lastMoxiWorksListingId = null,int perpage = 10 )
        {
            var client = Context;  
            var cred = new Credentials(Identifier, Secret);
            var auth = AuthenticationHeaderValue.Parse("Basic " + cred.ToBase64());
            client.DefaultRequestHeaders.Authorization = auth;
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.moxi-platform+json;version=1");
            
            if (Session.Instance.IsSessionCookieSet)
            {
                var cookie = Session.Instance.SessionCookie; 
                client.DefaultRequestHeaders.Add("Cookie", $"{cookie.Name}={cookie.Value}; path=/; HttpOnly");
            }

            var timestamp = GetTimeStamp(updateSince);
            var url =
                $"https://api-qa.moxiworks.com/api/listings?moxi_works_company_id={companyId}&updated_since={timestamp.ToString()}&per_page={perpage.ToString()}";
            if(lastMoxiWorksListingId != null )
            {
                url += $"&last_moxi_works_listing_id={lastMoxiWorksListingId}";
            }
            var result = client.GetAsync(url).Result;
            var content = result.Content;
            if(!Session.Instance.IsSessionCookieSet)
            {
                Session.Instance.SessionCookie = _handler.CookieContainer.GetCookies(new Uri("https://api-qa.moxiworks.com"))["_wms_svc_public_session"];
            }

            return JsonConvert.DeserializeObject<ListingResults>(content.ReadAsStringAsync().Result);

        }

        public static Listing GetListing(string companyId, string moxiWorksListingId)
        {
            var client = Context;
            var cred = new Credentials(Identifier, Secret);
            var auth = AuthenticationHeaderValue.Parse("Basic " + cred.ToBase64());
            client.DefaultRequestHeaders.Authorization = auth;
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.moxi-platform+json;version=1");

            if (Session.Instance.IsSessionCookieSet)
            {
                var cookie = Session.Instance.SessionCookie;
                client.DefaultRequestHeaders.Add("Cookie", String.Format("{0}={1}; path=/; HttpOnly", cookie.Name, cookie.Value));
            }

          
            var url =
                $"https://api-qa.moxiworks.com/api/listings/{moxiWorksListingId}?moxi_works_company_id={companyId}";
            
            var result = client.GetAsync(new Uri(url)).Result;
            var content = result.Content;

            if (!Session.Instance.IsSessionCookieSet)
            {
                Session.Instance.SessionCookie = _handler.CookieContainer.GetCookies(new Uri("https://api-qa.moxiworks.com"))["_wms_svc_public_session"];
            }

            return JsonConvert.DeserializeObject<Listing>(content.ReadAsStringAsync().Result);
        }

        public static Agent GetAgent(string moxiWorksAgentId,  string companyId)
        {
            var client = Context;
            var cred = new Credentials(Identifier, Secret);
            var auth = AuthenticationHeaderValue.Parse("Basic " + cred.ToBase64());
            client.DefaultRequestHeaders.Authorization = auth;
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.moxi-platform+json;version=1");

            if (Session.Instance.IsSessionCookieSet)
            {
                var cookie = Session.Instance.SessionCookie;
                client.DefaultRequestHeaders.Add("Cookie", $"{cookie.Name}={cookie.Value}; path=/; HttpOnly");
            }

          
            var url =
                $"https://api-qa.moxiworks.com/api/listings/{moxiWorksAgentId}?moxi_works_company_id={companyId}";
            
            var result = client.GetAsync(new Uri(url)).Result;
            var content = result.Content;

            if (!Session.Instance.IsSessionCookieSet)
            {
                Session.Instance.SessionCookie = _handler.CookieContainer.GetCookies(new Uri("https://api-qa.moxiworks.com"))["_wms_svc_public_session"];
            }

            return JsonConvert.DeserializeObject<Agent>(content.ReadAsStringAsync().Result);
        }

        public static AgentResults GetAgents(string moxiWorksCompanyId, DateTime updatedSince ,int? totalPages = null, int pageNumber = 1 )
        {
            var client = Context;  
            var cred = new Credentials(Identifier, Secret);
            var auth = AuthenticationHeaderValue.Parse("Basic " + cred.ToBase64());
            client.DefaultRequestHeaders.Authorization = auth;
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.moxi-platform+json;version=1");
            
            if (Session.Instance.IsSessionCookieSet)
            {
                var cookie = Session.Instance.SessionCookie; 
                client.DefaultRequestHeaders.Add("Cookie", $"{cookie.Name}={cookie.Value}; path=/; HttpOnly");
            }

            var timestamp = GetTimeStamp(updatedSince);
            var url =
                $"https://api-qa.moxiworks.com/api/agents?moxi_works_company_id={moxiWorksCompanyId}&updated_since={timestamp}";
            if(totalPages != null)
            {
                url += $"&total_pages={totalPages}"; 
            }

            if (pageNumber != null)
            {
                url += $"&page_number={pageNumber}";
            }
            
            var result = client.GetAsync(url).Result;
            var content = result.Content;
            if(!Session.Instance.IsSessionCookieSet)
            {
                Session.Instance.SessionCookie = _handler.CookieContainer.GetCookies(new Uri("https://api-qa.moxiworks.com"))["_wms_svc_public_session"];
            }

            return JsonConvert.DeserializeObject<AgentResults>(content.ReadAsStringAsync().Result);
        }

    }


}
