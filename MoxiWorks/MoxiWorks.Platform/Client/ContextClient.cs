using System;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MoxiWorks.Platform
{
    public class ContextClient : IContextClient
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
        
        public async Task<string>  GetRequestAsync<T>(string url)
        {

            var client = RequestClient();
            Console.WriteLine(url);
            var result = await client.GetAsync(new Uri(url));
            var content = result.Content;

            if (Session.Instance.IsSessionCookieSet) return await content.ReadAsStringAsync();

            
            Session.Instance.SessionCookie =
                _handler.CookieContainer.GetCookies(new Uri(new UriBuilder().GetUrl()))[
                    "_wms_svc_public_session"];

            return await content.ReadAsStringAsync();
        }

        public  string PostRequest<T>(string url, T obj)
        {
            var client = RequestClient();
            var result = client.PostAsJsonAsync(url, obj).Result;
            var content = result.Content;


            if (!Session.Instance.IsSessionCookieSet)
            {
                Session.Instance.SessionCookie =
                    _handler.CookieContainer.GetCookies(new Uri(new UriBuilder().GetUrl()))[
                        "_wms_svc_public_session"];
            }

            return content.ReadAsStringAsync().Result;

        }

        public  string PutRequest<T>(string url, T obj)
        {
            var client = RequestClient();
            var result = client.PutAsJsonAsync(url, obj).Result;
            var content = result.Content;
           

            if (!Session.Instance.IsSessionCookieSet)
            {
                Session.Instance.SessionCookie =
                    _handler.CookieContainer.GetCookies(new Uri(new UriBuilder().GetUrl()))[
                        "_wms_svc_public_session"];
            }
            
            return  content.ReadAsStringAsync().Result;
        }

        public string  DeleteRequest<T>(string url)
        {
            var client = RequestClient();
            var result = client.DeleteAsync(new Uri(url)).Result;
            var content = result.Content;

            if (!Session.Instance.IsSessionCookieSet)
            {
              
                Session.Instance.SessionCookie =
                    _handler.CookieContainer.GetCookies(new Uri(new UriBuilder().GetUrl()))[
                        "_wms_svc_public_session"];
            }

            return  content.ReadAsStringAsync().Result;
       

        }

        
    }
}