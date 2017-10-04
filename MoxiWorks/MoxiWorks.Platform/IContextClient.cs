namespace MoxiWorks.Platform
{
    public interface IContextClient
    {
        string GetRequest<T>(string url);
        string PostRequest<T>(string url, T obj);
        string PutRequest<T>(string url, T obj);
        string DeleteRequest<T>(string url);
    }
}