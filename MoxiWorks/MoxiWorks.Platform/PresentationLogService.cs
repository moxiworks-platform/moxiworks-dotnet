using System;
using System.Threading.Tasks;
using System.Xml.Schema;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{
    public class PresentationLogService: IPresentationLogService
    {
        public IMoxiWorksClient Client { get; set; }

        public PresentationLogService(IMoxiWorksClient client)
        {
            Client = client; 
        }
        
        
        public async Task<Response<PresentationLogResults>> GetPresentationLogsAsync(
            string moxiWorksCompanyId, 
            DateTime? createdAfter = null, 
            DateTime? createdBefore = null,
            DateTime? updatedAfter = null, 
            DateTime? updatedBefore = null, 
            int page_number = 1)
        {
            var builder = new UriBuilder("presentation_logs/")
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId)
                .AddQueryParameter("created_before", createdBefore)
                .AddQueryParameter("create_after", createdAfter)
                .AddQueryParameter("updated_before", updatedBefore)
                .AddQueryParameter("updated_after", updatedAfter)
                .AddQueryParameter("page_number", page_number);

            return await Client.GetRequestAsync<PresentationLogResults>(builder.GetUrl()); 
        }

        public Task<Response<PresentationLogResults>> GetPresentationLogsUpdatedAsync( string moxiWorksCompanyId, DateTime updatedAfter, DateTime updatedBefore, int page_number)
        {
            return GetPresentationLogsAsync(moxiWorksCompanyId, null, null, updatedAfter, updatedBefore, page_number); 
        }
        
        public Task<Response<PresentationLogResults>> GetPresentationLogsCreatedAsync( string moxiWorksCompanyId, DateTime createdAfter, DateTime createdBefore, int page_number)
        {
            return GetPresentationLogsAsync(moxiWorksCompanyId, createdAfter, createdBefore, null, null, page_number); 
        }
        
        
        
    }
}