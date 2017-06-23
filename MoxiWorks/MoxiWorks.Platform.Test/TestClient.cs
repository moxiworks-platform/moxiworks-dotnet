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
        public void GetListings()
        {
            var d = new DateTime(2017, 1, 1, 00, 00, 00);
            List<ListingResults> results = new List<ListingResults>();
            results.Add(Client.GetListingsUpdateSince("windermere", d));



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
            Assert.AreEqual(expectedId, l.MoxiWorksListingId );
        }

        //[Test]
        //public void ShouldBeAbleToGetCookes()m
        //{

        //    var cookie = new Cookie("foo", "bar");
        //    Client.Cookies.Add(cookie);

        //    Client.Context

        //}


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