using System;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{


    /// <summary>
    /// Generic point of interaction to the IClientContext  
    /// </summary>
    public class MoxiWorksClient : IMoxiWorksClient
    {
      
        protected IContextClient ClientContext { get; set; } = new ContextClient();
        
        public MoxiWorksClient(IContextClient context = null)
        {
            if (context != null)
                ClientContext = context;
        }
        
        public async Task<Response<T>> GetRequestAsync<T>(string url)
        {
            var s =  await ClientContext.GetRequestAsync(url);

            return DeserializeToResponse<T>(s);
        }

        public  async Task<Response<T>> PostRequestAsync<T>(string url, T obj)
        {
            return DeserializeToResponse<T>( await ClientContext.PostRequestAsync(url,obj));
        }

        public async Task<Response<T>> PutRequestAsync<T, U>(string url, U obj)
        {
            return DeserializeToResponse<T>( await ClientContext.PutRequestAsync(url,obj));
        }

        public async  Task<Response<T>> PutRequestAsync<T>(string url, T obj)
        {
            return DeserializeToResponse<T>( await ClientContext.PutRequestAsync(url,obj));
        }

        public  async Task<Response<T>> DeleteRequestAsync<T>(string url)
        {
            return DeserializeToResponse<T>(await ClientContext.DeleteRequestAsync(url));
        }

        private Response<T> DeserializeToResponse<T>(string json)
        {
            var error = DeserializeErrors(json);
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

        private MoxiWorksError DeserializeErrors(string json)
        {
            MoxiWorksError error; 
            try
            {
                error = JsonConvert.DeserializeObject<MoxiWorksError>(json);
            }
            catch(JsonSerializationException)
            {
                error = new MoxiWorksError(); 
            }

            return error;
        }

    }
}
