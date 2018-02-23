using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Xunit;
using static Xunit.Assert;
using MoxiWorks.Platform;
namespace MoxiWorks.Test
{
    
    public class PresentationLogFixture
    {
        [Fact]
        public void ShouldBeAbleToReturnACollectionOfSomePresentationLogs()
        {
            var presentationLogs = StubDataLoader.LoadJsonFile("PesentationLogs.json");  
           
            var service = new PresentationLogService(new MoxiWorksClient(new StubContextClient(presentationLogs)));
            var response = service.GetPresentationLogsAsync(
                "moxi_works_company_id", DateTime.Now,
                DateTime.Now.AddDays(-3), page_number:1).Result;  
               
            
            IsType<PresentationLogResults>(response.Item);
        }

       
    }
}