using System.Threading.Tasks;
using NUnit.Framework; 

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

        public async Task<string> PostRequestAsync<T>(string url, T obj)
        {
            var mockTask = new Task<FooBar>(() => new FooBar(Json));
            mockTask.Start();

            return  mockTask.Result.get_test_json();
        }

        public async Task<string> PutRequestAsync<T>(string url, T obj)
        {
            var mockTask = new Task<FooBar>(() => new FooBar(Json));
            mockTask.Start();

            return  mockTask.Result.get_test_json();
        }

        public async Task<string> DeleteRequestAsync<T>(string url)
        {
            var mockTask = new Task<FooBar>(() => new FooBar(Json));
            mockTask.Start();

            return  mockTask.Result.get_test_json();
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