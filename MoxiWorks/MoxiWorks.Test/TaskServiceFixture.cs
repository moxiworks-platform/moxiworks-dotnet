using System;
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
        public void ShouldReturnACollectionOfTasks()
        {
            var taskJson = StubDataLoader.LoadJsonFile("Tasks.json");  
           
            var service = new TaskService(new MoxiWorksClient(new StubContextClient(taskJson)));
            var response = service.GetTasksAsync("foo", AgentIdType.AgentUuid, DateTime.Now,DateTime.Now.AddDays(100),"FooBar",2).Result; 
            Assert.IsType<TaskResponse>(response.Item);  
            Assert.Equal(2, response.Item.PageNumber);
            Assert.Equal(2, response.Item.TotalPages);
        }
        
        
        [Fact]
        public void ShouldReturnACollectionOfTasksByStartDateEndDate()
        {
            var taskJson = StubDataLoader.LoadJsonFile("Tasks.json");  
           
            var service = new TaskService(new MoxiWorksClient(new StubContextClient(taskJson)));
            var response = service.GetTaskDueBetweenAsync("foo", AgentIdType.AgentUuid, DateTime.Now,DateTime.Now.AddDays(100),2).Result; 
            Assert.IsType<TaskResponse>(response.Item);  
            Assert.Equal(2, response.Item.PageNumber);
            Assert.Equal(2, response.Item.TotalPages);
        }
        
        
        [Fact]
        public void ShouldReturnACollectionOfTasksByContactId()
        {
            var taskJson = StubDataLoader.LoadJsonFile("Tasks.json");  
           
            var service = new TaskService(new MoxiWorksClient(new StubContextClient(taskJson)));
            var response = service.GetTasksDueForContactForAsync("foo", AgentIdType.AgentUuid,"FooBar",2).Result; 
            Assert.IsType<TaskResponse>(response.Item);  
            Assert.Equal(2, response.Item.PageNumber);
            Assert.Equal(2, response.Item.TotalPages);
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
