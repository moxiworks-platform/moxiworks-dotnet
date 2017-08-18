using Newtonsoft.Json; 
namespace MoxiWorks.Platform
{
    public class Company
    {
        [JsonProperty("moxi_works_company_id")]
        public string MoxiWorksCompanyId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }            
    }
}