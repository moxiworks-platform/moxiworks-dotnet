using Xunit;
using MoxiWorks.Platform;

namespace MoxiWorks.Test
{
    
    public class TaskServiceFixture
    {
        [Fact]
        public void ShouldReturnATask()
        {
            var taskJson = StubDataLoader.LoadJsonFile("Task.json");  
           
            var service = new TaskService(new MoxiWorksClient(new StubContextClient(taskJson)));
            var response = service.GetTaskAsync("foo", AgentIdType.AgentUuid, "1234", "12345").Result; 
            Assert.IsType<Task>(response.Item);
        }

        [Fact]
        public void ShouldHanldeApiReturnedErrors()
        {
            var json = StubDataLoader.LoadJsonFile("FailureResponse.json"); 
            var service = new TaskService(new MoxiWorksClient(new StubContextClient(json)));
            var response = service.GetTaskAsync("foo", AgentIdType.AgentUuid, "1234", "12345").Result;
            Assert.True((bool?) response.HasErrors); 
            
        }

       
    }


}
