using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

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

        public IMoxiWorksClient Client { get; set; }
        
        public ActionLogService(IMoxiWorksClient client)
        {
            Client = client;
        }
        /// <summary>
        /// Create New Action Log. 
        /// </summary>
        /// <param name="actionLog"> the ActionLog you want to create.</param>
        /// <returns>The ActionLog created.</returns>
        public async Task<Response<ActionLog>> CreateActionLogAsync(ActionLog actionLog)
        {
            var builder = new UriBuilder("action_logs");
            return await Client.PostRequestAsync(builder.GetUrl(), actionLog);
        }
        
        /// <summary>
        /// Returns a ActionLogResult that contains the contacts ActionLogs
        /// </summary>
        /// <param name="agentId">
        /// Must include either:
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your ActionLog request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or moxi_works_agent_id is required 
        /// and must reference a valid Moxi Works Agent ID for your ActionLog request to be accepted.
        /// Agent ID for your ActionLog request to be accepted.
        /// </param>
        /// <param name="agentIdType">What agentId type you are using.</param>
        /// <param name="moxiWorksContactId">This is the Moxi Works Platform ID of the Contact 
        /// which the ActionLog objects are associated with. This will be an RFC 4122 compliant UUID. 
        /// This data is required and must reference a valid Moxi Works Contact ID for your 
        /// ActionLog Index request to be accepted. This is the same as the moxi_works_contact_id 
        /// attribute of the Contact response.
        /// </param>
        /// <param name="partnerContactId">
        /// This is the unique identifer you use in your system that has been associated 
        /// with the Contact that you are creating an ActionLog entry about. 
        /// You should have already created the Contact record on the Moxi Works Platform 
        /// using Contact Create before attempting to use your system’s contact ID to show 
        /// ActionLog entries for the Contact. Your request will be rejected if the Contact 
        /// record does not exist.
        /// </param>
        /// <returns>List of contact's logged actions</returns>
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