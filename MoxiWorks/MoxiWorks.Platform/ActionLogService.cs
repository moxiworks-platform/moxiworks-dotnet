namespace MoxiWorks.Platform
{
    public class ActionLogService
    {

        public MoxiWorksClient Client { get; set; }
        
        public ActionLogService(MoxiWorksClient client)
        {
            Client = client;
        }

        public Response<ActionLog> CreateActionLog(ActionLog actionLog)
        {
            var builder = new UriBuilder("action_logs");
            return Client.PostRequest(builder.GetUrl(), actionLog);
        }

        public Response<ActionLogResults> GetActionLogs(string agentId, AgentIdType agentIdType,
            string moxiWorksContactId, string partnerContactId)
        {
            var builder = new UriBuilder("action_logs")
                .AddQueryPerameterAgentId(agentId, agentIdType)
                .AddQueryParameter("moxi_works_contact_id", moxiWorksContactId)
                .AddQueryParameter("partner_contact_id", partnerContactId);
            return Client.GetRequest<ActionLogResults>(builder.GetUrl());
        }
        
        
    }
}