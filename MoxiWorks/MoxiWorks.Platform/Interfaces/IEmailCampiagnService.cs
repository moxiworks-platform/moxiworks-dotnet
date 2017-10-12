namespace MoxiWorks.Platform
{
    public interface IEmailCampiagnService
    {
        MoxiWorksClient Client { get; set; }

        Response<EmailCampaignResults> GetEmailCampaign(string agentId, AgentIdType agentIdType,
            string partnerContactId);
    }
}