using System;
using System.Linq;
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
        
        public  Response<T> GetRequest<T>(string url)
        {
            var s = ClientContext.GetRequestAsync<T>(url).Result;
            Console.WriteLine(s);
            return DeserializeToResponse<T>(s);
        }

        public  Response<T> PostRequest<T>(string url, T obj)
        {
            return DeserializeToResponse<T>(ClientContext.PostRequestAsync(url,obj).Result);
        }

        public  Response<T> PutRequest<T>(string url, T obj)
        {
            return DeserializeToResponse<T>(ClientContext.PutRequestAsync(url,obj).Result);

        }

        public  Response<T> DeleteRequest<T>(string url)
        {
            return DeserializeToResponse<T>(ClientContext.DeleteRequestAsync<T>(url).Result);
        }

        private Response<T> DeserializeToResponse<T>(string json)
        {
            var error = JsonConvert.DeserializeObject<MoxiWorksError>(json);
            Response<T> response;

            if (error.Messages.Any())
            {
                response = new Response<T>();
                response.Errors.Add(error);
            }
            else
            {
                response = new Response<T>(
                JsonConvert.DeserializeObject<T>(json,  new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = NullValueHandling.Include
                }));
            }
           
            return response;
        }

    }
}
