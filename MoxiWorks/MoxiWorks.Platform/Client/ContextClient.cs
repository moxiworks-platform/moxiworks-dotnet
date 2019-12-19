﻿using System;
using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;
using UrlBuilder; 
[assembly:InternalsVisibleTo("MoxiWorks.Test")]
namespace MoxiWorks.Platform
{
    internal class ContextClient : IContextClient
    {
        private static HttpClient _context;
        public static HttpClient Context => _context ?? (_context = GetContext());

        private static CookieContainer _cookies;
        public static CookieContainer Cookies => _cookies ?? (_cookies = new CookieContainer());

        public static void ResetClient()
        {
            _context = GetContext();
        }

       

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
        
        public static HttpClient RequestClient(IMoxiWorksCredentials credentials = null)
        {
            var cred = credentials ?? new Credentials(); 
            
            var client = Context;
        
            var auth = AuthenticationHeaderValue.Parse("Basic " + cred.ToBase64());
            client.DefaultRequestHeaders.Authorization = auth;

            if (client.DefaultRequestHeaders.Accept.Count == 0)
            {
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.moxi-platform+json;version=1");
            }

            if (client.DefaultRequestHeaders.UserAgent.Count == 0)
            {
                client.DefaultRequestHeaders.Add("User-Agent", "moxiworks_platform dotnet client");
            }

            if (!Session.Instance.IsSessionCookieSet) return client;

            var cookie = Session.Instance.SessionCookie;
            client.DefaultRequestHeaders.Add("Cookie", $"{cookie.Name}={cookie.Value}; path=/; HttpOnly");          
            return client;
        }

        private readonly IMoxiWorksCredentials _credentials; 
        public ContextClient(IMoxiWorksCredentials credentials)
        {
            _credentials = credentials; 
        }

        public ContextClient()
        {
            _credentials = new Credentials();
        }

        public async Task<string>  GetRequestAsync(string url)
        {

            var client = RequestClient(_credentials);
            var result = await client.GetAsync(new Uri(url));
            var content = result.Content;

            if (Session.Instance.IsSessionCookieSet) return await content.ReadAsStringAsync();

            
            Session.Instance.SessionCookie =
                _handler.CookieContainer.GetCookies(new Uri(new UriBuilder().GetUrl()))[
                    "_wms_svc_public_session"];

            return await content.ReadAsStringAsync();
        }

        public async Task<string> PostRequestAsync<T>(string url, T obj)
        {
            var client = RequestClient(_credentials);
            var result =  await client.PostAsJsonAsync(url, obj);
            var content = result.Content;


            if (!Session.Instance.IsSessionCookieSet)
            {
                Session.Instance.SessionCookie =
                    _handler.CookieContainer.GetCookies(new Uri(new UriBuilder().GetUrl()))[
                        "_wms_svc_public_session"];
            }

            return  await content.ReadAsStringAsync();

        }

        public async Task<string> PutRequestAsync<T>(string url, T obj)
        {
            var client = RequestClient(_credentials);
            var result = await client.PutAsJsonAsync(url, obj);
            var content = result.Content;
           

            if (!Session.Instance.IsSessionCookieSet)
            {
                Session.Instance.SessionCookie =
                    _handler.CookieContainer.GetCookies(new Uri(new UriBuilder().GetUrl()))[
                        "_wms_svc_public_session"];
            }
            
            return  await content.ReadAsStringAsync();
        }

        public async Task<string>  DeleteRequestAsync(string url)
        {
            var client = RequestClient(_credentials);
            var result = await client.DeleteAsync(new Uri(url));
            var content = result.Content;

            if (!Session.Instance.IsSessionCookieSet)
            {
                Session.Instance.SessionCookie =
                    _handler.CookieContainer.GetCookies(new Uri(new UriBuilder().GetUrl()))[
                        "_wms_svc_public_session"];
            }

            return  await content.ReadAsStringAsync();
        }

        
    }
}