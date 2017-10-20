using System.Collections.Generic;
namespace MoxiWorks.Platform
{
    public class EmailCampaignResults
    {
        /// <summary>
        /// Total pages avaliable (always 1)
        /// </summary>
        public int TotalPages { get; set; } = 1;
        
        /// <summary>
        /// current page (always 1)
        /// </summary>
        public int PageNumber { get; set; } = 1; 

        /// <summary>
        /// List of EmailCampaigns 
        /// </summary>
        public List<EmailCampaign> EmailCampaigns { get; set; } = new List<EmailCampaign>();
    }
}