using System;
using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    public class MoxiWorksClient
    {
      
        protected IContextClient ClientContext { get; set; } = new ContextClient();
        
        public MoxiWorksClient(IContextClient context = null)
        {
            if (context != null)
                ClientContext = context;
        }
        
        public  T GetRequest<T>(string url)
        {
            var s = ClientContext.GetRequest<T>(url);
            Console.WriteLine(s);
            return JsonConvert.DeserializeObject<T>(s, new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include
            });
        }

        public  T PostRequest<T>(string url, T obj)
        {
            return JsonConvert.DeserializeObject<T>(ClientContext.PostRequest(url,obj));
        }

        public  T PutRequest<T>(string url, T obj)
        {
            return JsonConvert.DeserializeObject<T>(ClientContext.PutRequest(url,obj));

        }

        public  T DeleteRequest<T>(string url)
        {
            return JsonConvert.DeserializeObject<T>(ClientContext.DeleteRequest<T>(url), new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include
            });

        }

    }
}
