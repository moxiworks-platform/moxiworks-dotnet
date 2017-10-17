using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoxiWorks.Platform
{
    public interface IEmailCampiagnService
    {
    }

    public class EmailCampiagnService : IEmailCampiagnService
    {
        public MoxiWorksClient Client { get; set; }

        public EmailCampiagnService(MoxiWorksClient client)
        {
            Client = client; 
        }

        public async Task<Response<EmailCampaignResults>> GetEmailCampaignAsync(string agentId, AgentIdType agentIdType,
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
