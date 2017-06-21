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
    }


    public class ClientTester
    {
        public  void  run()
        {
            CookieContainer cookies = new CookieContainer();

            using (var handler = new HttpClientHandler()) {
                handler.CookieContainer = cookies;
                using (var client = new HttpClient(handler))
                {

                    var cred = new Credentials("5d39ba58-bfc3-11e5-a4e3-d0e1408e8026", "a56sthhidTlUsLyp8eFZBQtt");
                    var auth = AuthenticationHeaderValue.Parse("Basic " + cred.ToBase64());
                    client.DefaultRequestHeaders.Authorization = auth;
                    client.DefaultRequestHeaders.Add("Accept", "application/vnd.moxi-platform+json;version=1");
                    HttpResponseMessage result = client.GetAsync("https://api-qa.moxiworks.com/api/listings?moxi_works_company_id=windermere&updated_since=1461108284").Result;

                    IEnumerable<Cookie> responseCookies = cookies.GetCookies(new Uri("https://api-qa.moxiworks.com")).Cast<Cookie>();


                    HttpContent content = result.Content;
                    string test = content.ReadAsStringAsync().Result;

                    var listings = JsonConvert.DeserializeObject<ListingResults>(test);
                    Console.Write(test);
                }
            }
        }
    }
}
