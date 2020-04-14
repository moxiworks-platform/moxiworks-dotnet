using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    /// <summary>
    /// Wrapper around the service to allow stubbing of the service.
    /// </summary>
    public interface IActionLogService
    {
        IMoxiWorksClient Client { get; set; }
        Task<Response<ActionLog>> CreateActionLogAsync(ActionLog actionLog);

        Task<Response<ActionLogResults>> GetActionLogsAsync(string agentId, AgentIdType agentIdType,
            string moxiWorksContactId, string partnerContactId);
        
        Task<Response<ActionLog>> DeleteActionLogAsync(string moxiWorksActionLogId);

    }
}