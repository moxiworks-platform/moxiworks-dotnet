using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;
namespace MoxiWorks.Platform
{

    /// <summary>
    /// Finding an Company using the Moxi Works platform.
    /// </summary>
    public class CompanyService : ICompanyService
    {
        public IMoxiWorksClient Client { get; set; }

        public CompanyService(IMoxiWorksClient client)
        {
            Client = client; 
        }

        /// <summary>
        /// Finding an Company using the Moxi Works platform.
        /// </summary>
        /// <param name="moxiWorksCompanyId">
        /// A valid Moxi Works Company ID. Use Company Endpoint to 
        /// determine what MoxiWorksCompanyId you can use.
        /// </param>
        /// <returns>a company or and empty Company object</returns>
        public async Task<Response<Company>> GetCompanyAsync(string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"/companies/{moxiWorksCompanyId}");
            return await Client.GetRequestAsync<Company>(builder.GetUrl());
        }

    }
}
