using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    /// <summary>
    ///  Wrapper around the Client to allow stubbing of client interactions.
    /// </summary>
    public interface IContextClient

    {
        Task<string> GetRequestAsync<T>(string url);
        Task<string> PostRequestAsync<T>(string url, T obj);
        Task<string> PutRequestAsync<T>(string url, T obj);
        Task<string> DeleteRequestAsync<T>(string url);
    }
}
