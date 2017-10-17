using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    public interface IOfficeService
    {
        MoxiWorksClient Client { get; set; }
        Task<Response<Office>> GetOfficeAsync(string moxiWorksOfficeId, string moxiWorksCompanyId);
        Task<Response<OfficeResults>> GetCompanyOfficesAsync(string moxiWorksCompanyId, int pageNumber = 1);
    }
}