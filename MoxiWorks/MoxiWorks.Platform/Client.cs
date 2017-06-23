using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    public static class Client
    {
        private static HttpClient _context = null;
        public static HttpClient Context
        {
            get
            {
                if (_context == null)
                {
                    _context = getContext();
                }
                return _context;
            }
        }


        private static CookieContainer _cookies = null;
        public static CookieContainer Cookies
        {
            get
            {
                if (_cookies == null)
                {
                    _cookies = new CookieContainer();
                }
                return _cookies;
            }
        }

        public static void ResetClient()
        {
            _context = getContext();
        }


        private static HttpClientHandler _handler = null;
        private static HttpClient getContext()
        {
            _handler = new HttpClientHandler();
            _handler.CookieContainer = Cookies;
            _handler.UseCookies = true;
            return new HttpClient(_handler);
        }

        public static int GetTimeStamp(DateTime value)
        {
           return (int)Math.Truncate((value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
        }
     

        public static ListingResults GetListingsUpdateSince(string companyId,DateTime updateSince,string lastMoxiWorksListingId = null,int perpage = 10 )
        {
            var client = Context;  
            var cred = new Credentials("5d39ba58-bfc3-11e5-a4e3-d0e1408e8026", "a56sthhidTlUsLyp8eFZBQtt");
            var auth = AuthenticationHeaderValue.Parse("Basic " + cred.ToBase64());
            client.DefaultRequestHeaders.Authorization = auth;
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.moxi-platform+json;version=1");
            
            if (Session.Instance.IsSessionCookieSet)
            {
                var cookie = Session.Instance.SessionCookie; 
                client.DefaultRequestHeaders.Add("Cookie", String.Format("{0}={1}; path=/; HttpOnly", cookie.Name, cookie.Value));
            }

            int timestamp = GetTimeStamp(updateSince);
            var url = String.Format("https://api-qa.moxiworks.com/api/listings?moxi_works_company_id={0}&updated_since={1}&per_page={2}", companyId,timestamp.ToString(),perpage.ToString());
            if(lastMoxiWorksListingId != null )
            {
                url += String.Format("&last_moxi_works_listing_id={0}",lastMoxiWorksListingId);
            }
            HttpResponseMessage result = client.GetAsync(url).Result;
            HttpContent content = result.Content;
            if(!Session.Instance.IsSessionCookieSet)
            {
                Session.Instance.SessionCookie = _handler.CookieContainer.GetCookies(new Uri("https://api-qa.moxiworks.com"))["_wms_svc_public_session"];
            }

            return JsonConvert.DeserializeObject<ListingResults>(content.ReadAsStringAsync().Result);

        }

        public static Listing GetListing(string companyId, string moxiWorksListingId)
        {
            var client = Context;
            var cred = new Credentials("5d39ba58-bfc3-11e5-a4e3-d0e1408e8026", "a56sthhidTlUsLyp8eFZBQtt");
            var auth = AuthenticationHeaderValue.Parse("Basic " + cred.ToBase64());
            client.DefaultRequestHeaders.Authorization = auth;
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.moxi-platform+json;version=1");

            if (Session.Instance.IsSessionCookieSet)
            {
                var cookie = Session.Instance.SessionCookie;
                client.DefaultRequestHeaders.Add("Cookie", String.Format("{0}={1}; path=/; HttpOnly", cookie.Name, cookie.Value));
            }

          
            var url = String.Format("https://api-qa.moxiworks.com/api/listings/{0}?moxi_works_company_id={1}", moxiWorksListingId, companyId);
            
            HttpResponseMessage result = client.GetAsync(new Uri(url)).Result;
            HttpContent content = result.Content;

            if (!Session.Instance.IsSessionCookieSet)
            {
                Session.Instance.SessionCookie = _handler.CookieContainer.GetCookies(new Uri("https://api-qa.moxiworks.com"))["_wms_svc_public_session"];
            }

            return JsonConvert.DeserializeObject<Listing>(content.ReadAsStringAsync().Result);
        }

    }


}
