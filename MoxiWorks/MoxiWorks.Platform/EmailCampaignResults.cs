using System.Collections.Generic;
namespace MoxiWorks.Platform
{
    public class EmailCampaignResults
    {
        public int TotalPages { get; set; } = 1;

        public int PageNumbe { get; set; } = 1; 
        public List<EmailCampaign> EmailCampaigns { get; set; } = new List<EmailCampaign>();
    }
}