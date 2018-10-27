using MoxiWorks.Platform;
using Xunit;

namespace MoxiWorks.Test
{
    public class BrandServiceFixture
    {
        [Fact]
        public void ShouldReturnCompanyBrand()
        {
            var brandingJson = StubDataLoader.LoadJsonFile("Brand.json");  
            var service = new BrandService(new MoxiWorksClient(new StubContextClient(brandingJson)));
            var fake = service.GetCompanyBrand("moxiworksCompanyid");
            Assert.Equal(fake.Item.DisplayName,"Company Display Name");
            Assert.Equal(fake.Item.ImageLogo , "http://image.url/image.png");
        }

        [Fact]
        public void ShouldReturnBrand()
        {
            var brandingJson = StubDataLoader.LoadJsonFile("Brands.json");  
            var service = new BrandService(new MoxiWorksClient(new StubContextClient(brandingJson)));
            var fake = service.GetBrands("moxiworksCompanyid","agent_id");
            Assert.Single(fake.Item.Brands);
        }
    }
}