namespace MoxiWorks.Platform
{   
    public class OfficeService
    {
        public MoxiWorksClient Client {get;set;}

        public OfficeService(MoxiWorksClient client)
        {
            Client = client;
        }

        public Response<Office> GetOffice(string moxiWorksOfficeId, string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"offices/{moxiWorksOfficeId}")
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId);
            return Client.GetRequest<Office>(builder.GetUrl()); 
        }

        public Response<OfficeResults> GetCompanyOffices(string moxiWorksCompanyId, int pageNumber = 1)
        {
            var builder = new UriBuilder("offices")
                .AddQueryParameter("moxi_works_company_id", moxiWorksCompanyId)
                .AddQueryParameter("page_number", pageNumber);
            
            return Client.GetRequest<OfficeResults>(builder.GetUrl()); 
        }
        
        
    
    }
}