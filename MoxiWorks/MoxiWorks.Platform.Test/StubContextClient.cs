using MoxiWorks.Platform;
using Newtonsoft.Json;

namespace MoxiWorks.Platform.Test
{
    public class StubContextClient: IContextClient 
    {
        public string Json { get; set; }
        public void SubContextClient(string json = null)
        {
            Json = json;
        }
        public string GetRequest<T>(string url)
        {
            return Json;
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
}