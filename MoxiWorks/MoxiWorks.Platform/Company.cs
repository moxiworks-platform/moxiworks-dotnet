using Newtonsoft.Json; 
namespace MoxiWorks.Platform
{
    /// <summary>
    /// Makes up the payload of the Company response for a Show request.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// This is the Moxi Works Platform ID of the Company. 
        /// This will be an alphanumeric identification string which will be similar 
        /// to the company name.
        /// </summary>
        [JsonProperty("moxi_works_company_id")]
        public string MoxiWorksCompanyId { get; set; }
        /// <summary>
        /// This is a human readable name of the company which this Company object represents.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }            
    }
}