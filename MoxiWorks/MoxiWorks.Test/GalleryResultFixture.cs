using Xunit; 
using MoxiWorks.Platform;
namespace MoxiWorks.Test
{
    public class GalleryResultFixture
    {
        [Fact]
        public void ShouldCreateSomeGalleries()
        {
            var galleryJson = StubDataLoader.LoadJsonFile("Gallery.json");  
           
            var service = new GalleryService(new MoxiWorksClient(new StubContextClient(galleryJson)));

            var response = service.GetAgentGalleries("FooBarBazGoo", AgentIdType.MoxiWorksagentId, "company_id").Result;
            Assert.IsType<GalleryResults>(response.Item);
            Assert.True(response.Item.Galleries.Count == 1);
        }
    }
}