using System.Threading.Tasks;
namespace MoxiWorks.Platform
{
    /// <summary>
    /// Moxi Works ActionLog entries record actions that contacts take that an 
    /// agent might want to see to increase their effectivity. 
    /// For example, if a contact sends an email to an agent asking 
    /// a question, Moxi Works ActionLog will record that interaction 
    /// and display it to the agent.
    /// </summary>
    public class ActionLogService : IActionLogService
    {

        public MoxiWorksClient Client { get; set; }
        
        public ActionLogService(MoxiWorksClient client)
        {
            Client = client;
        }

        public async Task<Response<ActionLog>> CreateActionLogAsync(ActionLog actionLog)
        {
            var builder = new UriBuilder("action_logs");
            return await Client.PostRequestAsync(builder.GetUrl(), actionLog);
        }

        public async Task<Response<ActionLogResults>> GetActionLogsAsync(string agentId, AgentIdType agentIdType,
            string moxiWorksContactId, string partnerContactId)
        {
            var builder = new UriBuilder("action_logs")
                .AddQueryPerameterAgentId(agentId, agentIdType)
                .AddQueryParameter("moxi_works_contact_id", moxiWorksContactId)
                .AddQueryParameter("partner_contact_id", partnerContactId);
            return await Client.GetRequestAsync<ActionLogResults>(builder.GetUrl());
        }
        
        
    }
}