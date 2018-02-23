using System.Collections.Immutable;
using Xunit;
using System.Configuration;
using MoxiWorks.Platform;

namespace MoxiWorks.Test
{
    public class URlBuilderFixture
    {
        [Fact]
        public void ShouldReturnDefaultUrl()
        {
            var builder = new UriBuilder(); 
            Assert.Equal("https://api.moxiworks.com/api/",builder.GetUrl());
        }

        [Fact]
        public void ShouldIncludeAgentUuidByType()
        {
            var builder = new UriBuilder();
            builder.AddQueryPerameterAgentId("foo", AgentIdType.AgentUuid); 
            
            Assert.Contains("agent_uuid=foo",builder.GetUrl());
        }
        
        [Fact]
        public void ShouldIncludeMoxiWorksAgentId()
        {
            var builder = new UriBuilder();
            builder.AddQueryPerameterAgentId("foo", AgentIdType.MoxiWorksagentId); 
            
            Assert.Contains("moxi_works_agent_id=foo",builder.GetUrl());
        }

        [Fact]
        public void ShouldNotIncludeAgentId()
        {
            var builder = new UriBuilder();
            builder.AddQueryPerameterAgentId("foo", AgentIdType.NotAvaliable); 
            
            Assert.DoesNotContain("moxi_works_agent_id=foo",builder.GetUrl());
            Assert.DoesNotContain("agent_uuid=foo",builder.GetUrl());
        }
        
        
    }
}