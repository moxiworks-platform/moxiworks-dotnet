using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform.Interfaces
{
    public interface IBrandService
    {
        IMoxiWorksClient Client { get; set; }

        Task<Response<Brand>> GetCompanyBrandAsync(string moxiWorksCompanyId);

        Task<Response<BrandResults>> GetBrandsAsync(string agentId, AgentIdType agentIdType,
            string moxiWorksCompanyId);
    }
}