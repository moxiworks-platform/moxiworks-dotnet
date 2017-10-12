using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    public class EmailCampiagnService : IEmailCampiagnService
    {
        public MoxiWorksClient Client { get; set; }

        public EmailCampiagnService(MoxiWorksClient client)
        {
            Client = client; 
        }

        public Response<EmailCampaignResults> GetEmailCampaign(string agentId, AgentIdType agentIdType,
            string partnerContactId)
        {
            var builder = new UriBuilder("email_campaigns");
            builder.AddQueryPerameterAgentId(agentId, agentIdType);
            builder.AddQueryParameter("partner_contact_id", partnerContactId);

            var res = Client.GetRequest<List<EmailCampaign>>(builder.GetUrl());

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
