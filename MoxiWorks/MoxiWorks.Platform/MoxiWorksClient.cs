using System;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    internal static class MoxiWorksClient
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

        public static T GetRequest<T>(string url)
        {

            var client = RequestClient();
            var result = client.GetAsync(new Uri(url)).Result;
            var content = result.Content;

            if (!Session.Instance.IsSessionCookieSet)
            {
                var builder = new UriBuilder();

                Session.Instance.SessionCookie =
                    _handler.CookieContainer.GetCookies(new Uri(builder.GetUrl()))[
                        "_wms_svc_public_session"];
            }

            var s = content.ReadAsStringAsync().Result;
            Console.Write(s);
            return JsonConvert.DeserializeObject<T>(s, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include
            });

        }

        public static T PostRequest<T>(string url, T obj)
        {
            var client = RequestClient();
            var result = client.PostAsJsonAsync(url, obj).Result;
            var content = result.Content;


            if (!Session.Instance.IsSessionCookieSet)
            {
                Session.Instance.SessionCookie =
                    _handler.CookieContainer.GetCookies(new Uri("https://api-qa.moxiworks.com"))[
                        "_wms_svc_public_session"];
            }

            var s = content.ReadAsStringAsync().Result;

            Console.WriteLine(s);
            return JsonConvert.DeserializeObject<T>(s);

        }

        public static T PutRequest<T>(string url, T obj)
        {
            var client = RequestClient();
            var result = client.PutAsJsonAsync(url, obj).Result;
            var content = result.Content;


            if (!Session.Instance.IsSessionCookieSet)
            {
                Session.Instance.SessionCookie =
                    _handler.CookieContainer.GetCookies(new Uri("https://api-qa.moxiworks.com"))[
                        "_wms_svc_public_session"];
            }
            var s = content.ReadAsStringAsync().Result;
            Console.WriteLine(s);

            return JsonConvert.DeserializeObject<T>(s);

        }

        public static T DeleteRequest<T>(string url)
        {
            var client = RequestClient();
            var result = client.DeleteAsync(new Uri(url)).Result;
            var content = result.Content;

            if (!Session.Instance.IsSessionCookieSet)
            {
              
                Session.Instance.SessionCookie =
                    _handler.CookieContainer.GetCookies(new Uri(new UriBuilder("").GetUrl()))[
                        "_wms_svc_public_session"];
            }

            var s = content.ReadAsStringAsync().Result;
            Console.WriteLine(s);

            return JsonConvert.DeserializeObject<T>(s, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include
            });

        }

    }
}
