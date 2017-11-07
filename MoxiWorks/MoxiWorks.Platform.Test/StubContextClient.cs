using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;
using NUnit.Framework;
using System.Net.Http.Headers;


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

            return  mockTask.Result.GetTestJson();
        }

        public async Task<string> PostRequestAsync<T>(string url, T obj)
        {
            var mockTask = new Task<FooBar>(() => new FooBar(Json));
            mockTask.Start();

            return  mockTask.Result.GetTestJson();
        }

        public async Task<string> PutRequestAsync<T>(string url, T obj)
        {
            var mockTask = new Task<FooBar>(() => new FooBar(Json));
            mockTask.Start();

            return  mockTask.Result.GetTestJson();
        }

        public async Task<string> DeleteRequestAsync<T>(string url)
        {
            var mockTask = new Task<FooBar>(() => new FooBar(Json));
            mockTask.Start();

            return  mockTask.Result.GetTestJson();
        }

        

        
    }

    internal class FooBar
    {
        private readonly string Json = null;

        public FooBar(string json)
        {
            Json = json; 
        }
        public string GetTestJson()
        {
            return Json;
        }
    }
}