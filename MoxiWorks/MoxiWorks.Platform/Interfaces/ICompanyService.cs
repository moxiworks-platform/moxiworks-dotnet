using System.Threading.Tasks;
namespace MoxiWorks.Platform.Interfaces
{
    public interface ICompanyService
    {
        MoxiWorksClient Client { get; set; }
        Task<Response<Company>> GetCompanyAsync(string moxiWorksCompanyId);
    }
}