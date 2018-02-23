using System.Collections.Generic;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;
namespace MoxiWorks.Platform
{
  

    /// <summary>
    /// Moxi Works Platform EmailCampign entities represent email campaigns established between agents and contacts via Moxi Works.
    /// </summary>
    public class EmailCampiagnService //: IEmailCampiagnService
    {
        public IMoxiWorksClient Client { get; set; }

        public EmailCampiagnService(IMoxiWorksClient client)
        {
            Client = client; 
        }

        /// <summary>
        /// Searches  Moxi Works platform API for EmailCampaign entities.
        /// </summary>
        /// <param name="agentId">
        /// Must include either:
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an EmailCampaignentry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your EmailCampaignentry request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an  EmailCampaign entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or moxi_works_agent_id is required 
        /// and must reference a valid Moxi Works Agent ID for your  EmailCampaign request to be accepted.
        /// Agent ID for your  EmailCampaign  request to be accepted.
        /// </param>
        /// <param name="agentIdType">What agentId type you are using.</param>
        /// <param name="partnerContactId">
        /// This is the unique identifer you use in your system that has been associated 
        /// with the w that you are creating an EmailCampaign entry about. 
        /// You should have already created the Contact record on the Moxi Works 
        /// Platform using Contact Create before attempting to use your system’s contact ID 
        /// to show EmailCampaign entries for the Contact. Your request will be rejected if 
        /// the Contact record does not exist.
        /// </param>
        /// <returns></returns>
        public async Task<Response<EmailCampaignResults>> GetEmailCampaignsAsync(string agentId, AgentIdType agentIdType,
            string partnerContactId)
        {
            var builder = new UriBuilder("email_campaigns")
            .AddQueryPerameterAgentId(agentId, agentIdType)
            .AddQueryParameter("partner_contact_id", partnerContactId);

            var res =  await Client.GetRequestAsync<List<EmailCampaign>>(builder.GetUrl());

            var campaigns = new EmailCampaignResults
            {
                EmailCampaigns = res.Item
            };

            var response = new Response<EmailCampaignResults>
            {
                Errors = res.Errors,
                Item = campaigns
            };

            return response;

        }
    }
}
