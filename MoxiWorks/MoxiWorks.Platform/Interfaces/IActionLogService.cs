namespace MoxiWorks.Platform
{
    public interface IActionLogService
    {
        MoxiWorksClient Client { get; set; }
        Response<ActionLog> CreateActionLog(ActionLog actionLog);

        Response<ActionLogResults> GetActionLogs(string agentId, AgentIdType agentIdType,
            string moxiWorksContactId, string partnerContactId);
    }
}