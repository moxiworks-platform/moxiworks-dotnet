using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    public interface IActionLogService
    {
        MoxiWorksClient Client { get; set; }
        Task<Response<ActionLog>> CreateActionLogAsync(ActionLog actionLog);

        Task<Response<ActionLogResults>> GetActionLogsAsync(string agentId, AgentIdType agentIdType,
            string moxiWorksContactId, string partnerContactId);
    }
}