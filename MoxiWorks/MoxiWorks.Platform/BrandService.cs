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
        /// Find company brand
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
        
        /// <summary>
        /// Returns BrandResults that contains associated Brands for the request query
        /// </summary>
        /// <param name="moxiWorksAgentId">
        /// This is the Moxi Works Platform ID of the Agent. 
        /// This will be a string that may take the form of an email address, or a unique identification string. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a valid Moxi Works Agent ID 
        /// for your Agent request to be accepted.
        /// </param>
        /// <param name="moxiWorksCompanyId">
        /// A valid Moxi Works Company ID. Use Company Endpoint to 
        /// determine what MoxiWorksCompanyID you can use.
        /// </param>
        /// <returns>List of brands associated with the requested Agent or Company</returns>
        public async Task<Response<BrandResults>> GetBrandsAsync(string moxiWorksCompanyId, string moxiWorksAgentId = null)
        {
            var builder = new UriBuilder($"brands")
                .AddQueryParameter("moxi_works_agent_id", moxiWorksAgentId)
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId);
            return await Client.GetRequestAsync<BrandResults>(builder.GetUrl());
        }
        
        
    }
}