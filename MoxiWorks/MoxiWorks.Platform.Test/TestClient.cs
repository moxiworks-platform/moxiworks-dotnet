using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; 
using System.Net.Http;
using System.Net.Http.Headers;
using NUnit.Framework;
using MoxiWorks.Platform;
using Newtonsoft.Json;
namespace MoxiWorks.Platform.Test
{
    [TestFixture]
    class TestClient
    {
        [Test]
        public void RunHackedClient()
        {
            var test = new ClientTester();
            test.run();
        }

        //[Test]
        //public void ShouldBeAbleToGetCookes()
        //{
        
        //    var cookie = new Cookie("foo", "bar");
        //    Client.Cookies.Add(cookie);

        //    Client.Context
            
        //}


    }

  
    



    public class ClientTester
    {
        public  void  run()
        {


            var client = Client.Context; 
            var cred = new Credentials("5d39ba58-bfc3-11e5-a4e3-d0e1408e8026", "a56sthhidTlUsLyp8eFZBQtt");
            var auth = AuthenticationHeaderValue.Parse("Basic " + cred.ToBase64());
            client.DefaultRequestHeaders.Authorization = auth;
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.moxi-platform+json;version=1");
            HttpResponseMessage result = client.GetAsync("https://api-qa.moxiworks.com/api/listings?moxi_works_company_id=windermere&updated_since=1461108284").Result;

            //IEnumerable<Cookie> responseCookies = cookies.GetCookies(new Uri("https://api-qa.moxiworks.com")).Cast<Cookie>();

            HttpContent content = result.Content;
            string test = content.ReadAsStringAsync().Result;

            var listings = JsonConvert.DeserializeObject<ListingResults>(test);
            Console.Write(test);

            var cookies = Client.Cookies;
            IEnumerable<Cookie> responseCookies = cookies.GetCookies(new Uri("https://api-qa.moxiworks.com")).Cast<Cookie>();




            var handler2 = new HttpClientHandler();
            var cookie = responseCookies.First();
            cookie.Expires = DateTime.Now.AddHours(1);
            handler2.CookieContainer.Add(cookie);
            handler2.UseCookies = true;
            var client2 = new HttpClient(handler2);


            var auth2 = AuthenticationHeaderValue.Parse("Basic " + cred.ToBase64());
            client2.DefaultRequestHeaders.Authorization = auth2;
            client2.DefaultRequestHeaders.Add("Accept", "application/vnd.moxi-platform+json;version=1");

            HttpResponseMessage result2 = client2.GetAsync("https://api-qa.moxiworks.com/api/listings?moxi_works_company_id=windermere&updated_since=1461108284").Result;

            HttpContent content2 = result2.Content;
            string test2 = content2.ReadAsStringAsync().Result;
          
            var listings2 = JsonConvert.DeserializeObject<ListingResults>(test2);
            Console.Write(test2);

            

        }
    }
}