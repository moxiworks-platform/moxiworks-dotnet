using System.Threading.Tasks;
namespace MoxiWorks.Platform
{
    public interface ICompanyService
    {
        MoxiWorksClient Client { get; set; }
        Task<Response<Company>> GetCompanyAsync(string moxiWorksCompanyId);
    }

    public class CompanyService : ICompanyService
    {
        public MoxiWorksClient Client { get; set; }

        public CompanyService(MoxiWorksClient client)
        {
            Client = client; 
        }

        public async Task<Response<Company>> GetCompanyAsync(string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"/companies/{moxiWorksCompanyId}");
            return await Client.GetRequestAsync<Company>(builder.GetUrl());
        }

    }
}
