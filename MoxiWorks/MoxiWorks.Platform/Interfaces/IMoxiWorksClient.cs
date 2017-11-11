using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    /// <summary>
    /// Wrapper around the service for allow better Dependancy Injection.
    /// </summary>
    public interface IMoxiWorksClient
    {
        Task<Response<T>> GetRequestAsync<T>(string url);
        Task<Response<T>> PostRequestAsync<T>(string url, T obj);
        Task<Response<T>> PutRequestAsync<T>(string url, T obj);
        Task<Response<T>> DeleteRequestAsync<T>(string url);
    }
}
