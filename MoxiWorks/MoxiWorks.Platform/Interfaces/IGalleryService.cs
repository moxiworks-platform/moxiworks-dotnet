using System.Threading.Tasks;
namespace MoxiWorks.Platform.Interfaces
{
    public interface IGalleryService
    {
        IMoxiWorksClient Client { get; set; }
        Task<Response<GalleryResults>> GetAgentGalleries(string agentId, AgentIdType agentIdType,
            string moxiWorksCompanyId);

    }
}