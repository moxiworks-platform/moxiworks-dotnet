using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform.Interfaces
{
    public interface IBrandService
    {
        IMoxiWorksClient Client { get; set; }

        Task<Response<Brand>> GetCompanyBrandAsync(string moxiWorksCompanyId);
        
        Response<Brand> GetCompanyBrand(string moxiWorksCompanyId);

        Task<Response<BrandResults>> GetBrandsAsync(string moxiWorksCompanyId, string moxiWorksAgentId = null);

        Response<BrandResults> GetBrands(string moxiWorksCompanyId, string moxiWorksAgentId = null);

    }
}