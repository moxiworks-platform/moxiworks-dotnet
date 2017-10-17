using System.Threading.Tasks;
namespace MoxiWorks.Platform
{   
    public class OfficeService : IOfficeService
    {
        public MoxiWorksClient Client {get;set;}

        public OfficeService(MoxiWorksClient client)
        {
            Client = client;
        }

        public async Task<Response<Office>> GetOfficeAsync(string moxiWorksOfficeId, string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"offices/{moxiWorksOfficeId}")
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId);
            
            return await Client.GetRequestAsync<Office>(builder.GetUrl()); 
        }

        public async Task<Response<OfficeResults>> GetCompanyOfficesAsync(string moxiWorksCompanyId, int pageNumber = 1)
        {
            var builder = new UriBuilder("offices")
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId)
                .AddQueryParameter("page_number", pageNumber);
            
            return await Client.GetRequestAsync<OfficeResults>(builder.GetUrl()); 
        }
        
        
    
    }
}