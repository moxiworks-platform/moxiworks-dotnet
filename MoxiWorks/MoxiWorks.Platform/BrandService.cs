using System.Threading.Tasks;
namespace MoxiWorks.Platform
{
    public class BrandService
    {
        public MoxiWorksClient Client { get; set; }

        public BrandService(MoxiWorksClient client)
        {
            Client = client; 
        }
        
        public async Task<Response<Brand>> GetCompanyBrandAsync(string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"brands/{moxiWorksCompanyId}");
            return await Client.GetRequestAsync<Brand>(builder.GetUrl());
        }
    }
}