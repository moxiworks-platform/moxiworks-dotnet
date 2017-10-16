
using System.Threading.Tasks;

namespace MoxiWorks.Platform
{
    public interface IContextClient

    {
        Task<string> GetRequestAsync<T>(string url);
        string PostRequest<T>(string url, T obj);
        string PutRequest<T>(string url, T obj);
        string DeleteRequest<T>(string url);
    }
