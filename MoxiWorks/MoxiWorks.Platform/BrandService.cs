using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;
namespace MoxiWorks.Platform
{
    /// <summary>
    /// Moxi Works Brand objects contain data about brand colors & logos associated 
    /// with a company. For example, you can get a Company’s logo for use within 
    /// your own product.
    /// </summary>
    public class BrandService : IBrandService
    {
        public IMoxiWorksClient Client { get; set; }

        public BrandService(IMoxiWorksClient client)
        {
            Client = client; 
        }
        
        /// <summary>
        /// Find compnay brand
        /// </summary>
        /// <param name="moxiWorksCompanyId">
        /// A valid Moxi Works Company ID. Use Company Endpoint to 
        /// determine what MoxiWorksCompanyID you can use.
        /// </param>
        /// <returns>the Brand if exists or an empty Brand Object </returns>
        public async Task<Response<Brand>> GetCompanyBrandAsync(string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"brands/{moxiWorksCompanyId}");
            return await Client.GetRequestAsync<Brand>(builder.GetUrl());
        }
    }
}