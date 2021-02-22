﻿using Xunit; 
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
            Assert.IsType<Agent>(response.Item);
            Assert.True(response.Item.CreatedTimestamp.HasValue);
            Assert.False(response.Item.DeactivatedTimestamp.HasValue);
          
        }
        
        [Fact]
        public void ShouldReturnAnAgentNoAsync()
        {
            var agentJson = StubDataLoader.LoadJsonFile("Agent.json");  
            IAgentService service = new AgentService(new MoxiWorksClient(new StubContextClient(agentJson)));
            var response = service.GetAgent("some_agent_id","some_company_id");
            var agent = response.Item;
            Assert.True(agent.AlternateOffices.Count == 2);
            Assert.Equal(1234,agent.AlternateOffices[0].OfficeId);
        }

        [Fact]
        public void ShouldReturnAgentWithAlternateOffices()
        {
            var agentJson = StubDataLoader.LoadJsonFile("Agent.json");  
            IAgentService service = new AgentService(new MoxiWorksClient(new StubContextClient(agentJson)));
            var response = service.GetAgentAsync("some_agent_id","some_company_id").Result;
            var agent = response.Item;
            Assert.True(agent.AlternateOffices.Count == 2);
            Assert.Equal(1234,agent.AlternateOffices[0].OfficeId);
        }
        
        
        
        [Fact]
        public void ShouldReturnAnAgentWithGoals()
        {
            var agentJson = StubDataLoader.LoadJsonFile("Agent.json");  
            IAgentService service = new AgentService(new MoxiWorksClient(new StubContextClient(agentJson)));
            var response = service.GetAgentWithGoalsAsync("some_agent_id","some_company_id", true).Result;
            var agent = response.Item;
            Assert.IsType<Agent>(response.Item);
            Assert.Equal(122131,agent.GciGoal);
            Assert.Equal("YERP",agent.AccessLevel);
            Assert.Equal(1.25f,agent.BuyerCommissionRate); 
            Assert.Equal(1.25f,agent.SellerCommissionRate); 
          
        }
        
        [Fact]
        public void ShouldReturnAnAgentWithAccessLevel()
        {
            var agentJson = StubDataLoader.LoadJsonFile("Agent.json");  
            IAgentService service = new AgentService(new MoxiWorksClient(new StubContextClient(agentJson)));
            var response = service.GetAgentWithAccessLevelAsync("some_agent_id","some_company_id", true).Result;
            var agent = response.Item;
            Assert.IsType<Agent>(response.Item);
            Assert.Equal("YERP",agent.AccessLevel);
            Assert.Equal(1.25f,agent.BuyerCommissionRate); 
            Assert.Equal(1.25f,agent.SellerCommissionRate); 
          
        }
    }
}