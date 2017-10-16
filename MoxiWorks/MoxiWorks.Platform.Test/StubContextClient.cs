using System.IO.Pipes;
using System.Threading.Tasks;
using MoxiWorks.Platform;
using Newtonsoft.Json;
using NUnit.Framework.Internal;

namespace MoxiWorks.Platform.Test
{
    public class StubContextClient: IContextClient 
    {
        public string Json { get; set; }
        public  StubContextClient(string json = null)
        {
            Json = json;
        }
        public async Task<string> GetRequestAsync<T>(string url)
        {
            
            var mockTask = new Task<FooBar>(() => new FooBar(Json));
            mockTask.Start();

            return  mockTask.Result.get_test_json();
        }

        public string PostRequest<T>(string url, T obj)
        {
            return Json;
        }

        public string PutRequest<T>(string url, T obj)
        {
            return Json;
        }

        public string DeleteRequest<T>(string url)
        {
            return Json;
        }

        

        
    }

    internal class FooBar
    {
        private string Json = null;

        public FooBar(string json)
        {
            Json = json; 
        }
        public string get_test_json()
        {
            return Json;
        }
    }
}