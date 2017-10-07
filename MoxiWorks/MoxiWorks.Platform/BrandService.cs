namespace MoxiWorks.Platform
{
    public class BrandService
    {
        public MoxiWorksClient Client { get; set; }

        public BrandService(MoxiWorksClient client)
        {
            Client = client; 
        }
        
        public  Response<Brand> GetCompanyBrand(string moxiWorksCompanyId)
        {
            var builder = new UriBuilder($"brands/{moxiWorksCompanyId}");
            return Client.GetRequest<Brand>(builder.GetUrl());
        }
    }
}