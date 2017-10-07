
namespace MoxiWorks.Platform
{
    public class CompanyService
    {
        public MoxiWorksClient Client { get; set; }

        public CompanyService(MoxiWorksClient client)
        {
            Client = client; 
        }

        public Response<Company> GetCompany(string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"/companies/{moxiWorksCompanyId}");
            return Client.GetRequest<Company>(builder.GetUrl());
        }

    }
}
