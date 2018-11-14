using System;
using System.Linq;
using Xunit;
namespace MoxiWorks.Test.Client
{
    public class ContextClientFixture
    {
        [Fact]
        public void ShouldOnlyGenerateOneSetOfUserAgentHeaders()
        {


            var expected = 3;

            // call twice to see if the headers are only added once 
            var client = MoxiWorks.Platform.ContextClient.RequestClient();
            client = MoxiWorks.Platform.ContextClient.RequestClient();
            
            var actual =  client.DefaultRequestHeaders.UserAgent.Count();
     
            
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void ShouldOnlyGenerateOneSetOfAccessHeaders()
        {

            var expected = 1;

            // call twice to see if the headers are only added once 
            var client = MoxiWorks.Platform.ContextClient.RequestClient();
            var client_2 = MoxiWorks.Platform.ContextClient.RequestClient();
            
            var actual =  client_2.DefaultRequestHeaders.Accept.Count();   
            
            Assert.Equal(expected,actual);
        }
            
    }
}