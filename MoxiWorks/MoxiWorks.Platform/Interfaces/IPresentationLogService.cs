using System;
using System.Threading.Tasks;


namespace MoxiWorks.Platform.Interfaces
{
    public interface IPresentationLogService
    {
        Task<Response<PresentationLogResults>> GetPresentationLogsAsync(
            string moxiWorksCompanyId,
            DateTime? createdAfter,
            DateTime? createdBefore,
            DateTime? updatedAfter,
            DateTime? updatedBefore,
        int  page_number);
        
        
        Task<Response<PresentationLogResults>> GetPresentationLogsUpdatedAsync(
            string moxiWorksCompanyId,
            DateTime updatedAfter,
            DateTime updatedBefore,
            int  page_number);
        
        Task<Response<PresentationLogResults>> GetPresentationLogsCreatedAsync(
            string moxiWorksCompanyId,
            DateTime createdAfter,
            DateTime createdBefore,
            int  page_number);
        
        
    }
    
   
}