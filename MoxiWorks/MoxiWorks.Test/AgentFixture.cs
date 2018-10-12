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
            Assert.IsType<Agent>(response.Item);
          
        }
        
        [Fact]
        public void ShouldReturnAnAgentNoAsync()
        {
            var agentJson = StubDataLoader.LoadJsonFile("Agent.json");  
            IAgentService service = new AgentService(new MoxiWorksClient(new StubContextClient(agentJson)));
            var response = service.GetAgent("some_agent_id","some_company_id");
            var agent = response.Item;
            Assert.True(agent.AlternateOffices.Count == 2);
            Assert.Equal(agent.AlternateOffices[0].OfficeId, 1234);
        }

        [Fact]
        public void ShouldReternAgentWithAlternateOffices()
        {
            var agentJson = StubDataLoader.LoadJsonFile("Agent.json");  
            IAgentService service = new AgentService(new MoxiWorksClient(new StubContextClient(agentJson)));
            var response = service.GetAgentAsync("some_agent_id","some_company_id").Result;
            var agent = response.Item;
            Assert.True(agent.AlternateOffices.Count == 2);
            Assert.Equal(agent.AlternateOffices[0].OfficeId, 1234);
        }
        
        
        
        [Fact]
        public void ShouldReturnAnAgentWithGoals()
        {
            var agentJson = StubDataLoader.LoadJsonFile("Agent.json");  
            IAgentService service = new AgentService(new MoxiWorksClient(new StubContextClient(agentJson)));
            var response = service.GetAgentWithGoalsAsync("some_agent_id","some_company_id", true).Result;
            var agent = response.Item;
            Assert.IsType<Agent>(response.Item);
            Assert.Equal(agent.GciGoal,122131);
            Assert.Equal(agent.BuyerCommissionRate, 1.25f); 
            Assert.Equal(agent.SellerCommisionRate,1.25f); 
          
        }
        
    }
}