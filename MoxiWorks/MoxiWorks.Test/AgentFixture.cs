using System;
using System.Collections.Generic;
using Xunit; 
using MoxiWorks.Platform; 
using MoxiWorks.Platform.Interfaces;
namespace MoxiWorks.Test
{
    public class AgentFixture
    {
        [Fact]
        public void ShouldReturnAnAgent()
        {
            var agentJson = StubDataLoader.LoadJsonFile("Agent.json");  
            IAgentService service = new AgentService(new MoxiWorksClient(new StubContextClient(agentJson)));
            var response = service.GetAgentAsync("some_agent_id","some_company_id").Result;
            var agent = response.Item;
            Assert.IsType<Agent>(response.Item);
          
        }
        
    }
}