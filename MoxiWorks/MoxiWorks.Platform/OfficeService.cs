using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Moxi Works Platform Office entities represent brokerage offices.
    /// </summary>
    public class OfficeService : IOfficeService
    {
        public IMoxiWorksClient Client {get;set;}

        public OfficeService(IMoxiWorksClient client)
        {
            Client = client;
        }
        /// <summary>
        /// Gets a Brockerages office 
        /// </summary>
        /// <param name="moxiWorksOfficeId">A valid Moxi Works Office ID. 
        /// Use Office Index Endpoint for a list of all Office objects associated with a Company or use the moxi_works_office_id attribute returned in an Agent response.
        /// </param>
        /// <param name="moxiWorksCompanyId">
        /// A valid Moxi Works Company ID. Use Company Endpoint to determine what moxi_works_company_id you can use.
        /// </param>
        /// <returns>Office response or an empty office if nothing is found</returns>
        public async Task<Response<Office>> GetOfficeAsync(string moxiWorksOfficeId, string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"offices/{moxiWorksOfficeId}")
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId);
            
            return await Client.GetRequestAsync<Office>(builder.GetUrl()); 
        }
        
        /// <summary>
        /// Synchronous wrapper for GetOfficeAsync
        /// </summary>
        public Response<Office> GetOffice(string moxiWorksOfficeId, string moxiWorksCompanyId)
        {
            return System.Threading.Tasks.Task.Run(() =>GetOfficeAsync(moxiWorksOfficeId,moxiWorksCompanyId)).Result; 

        }


        /// <summary>
        /// Get a list of Offices for a brockerage.
        /// </summary>
        /// <param name="moxiWorksCompanyId">A valid Moxi Works Company ID. 
        /// Use Company Endpoint to determine what moxi_works_company_id you can use.</param>
        /// <param name="pageNumber">For queries with multi-page responses, 
        /// use the page_number parameter to return data for specific pages. Data for page 1 is returned 
        /// if this parameter is not included. Use this parameter if total_pages indicates that 
        /// there is more than one page of data available.</param>
        /// <returns>List of offices for a brockerage.</returns>
        public async Task<Response<OfficeResults>> GetCompanyOfficesAsync(string moxiWorksCompanyId, int pageNumber = 1)
        {
            var builder = new UriBuilder("offices")
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId)
                .AddQueryParameter("page_number", pageNumber);
            
            return await Client.GetRequestAsync<OfficeResults>(builder.GetUrl()); 
        }
        
        /// <summary>
        /// Synchronous wrapper for GetCompanyOfficesAsync
        /// </summary>
        public Response<OfficeResults> GetCompanyOffices(string moxiWorksCompanyId, int pageNumber = 1)
        {
          return System.Threading.Tasks.Task.Run(() =>GetCompanyOfficesAsync(moxiWorksCompanyId,pageNumber)).Result; 

        }
        
        
    
    }
}