using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    /// <summary>
    /// Wrapper around the service to allow stubbing of the service.
    /// </summary>
    interface IEmailCampaignService
    {
         Task<Response<EmailCampaignResults>> GetEmailCampaignsAsync(string agentId, AgentIdType agentIdType,
            string partnerContactId);
    }
}
