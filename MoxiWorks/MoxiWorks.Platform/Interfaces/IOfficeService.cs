using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    /// <summary>
    /// Wrapper around the service to allow stubbing of the service.
    /// </summary>
    public interface IOfficeService
    {
        IMoxiWorksClient Client { get; set; }
        Task<Response<Office>> GetOfficeAsync(string moxiWorksOfficeId, string moxiWorksCompanyId);
        Task<Response<OfficeResults>> GetCompanyOfficesAsync(string moxiWorksCompanyId, int pageNumber = 1);
    }
}