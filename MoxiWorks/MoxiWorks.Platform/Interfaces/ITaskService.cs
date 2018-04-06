using System;
using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    /// <summary>
    /// Wrapper around the service to allow stubbing of the service.
    /// </summary>
    public interface ITaskService
    {
        Task<Response<Task>> GetTaskAsync(string agentId, AgentIdType agentIdType, string partnerContactId,
            string partnerTaskId);

        Task<Response<Task>> UpdateTaskAsync(Task task);
        Task<Response<Task>> CreateTaskAsync(Task task);

        Task<Response<TaskResponse>> GetTasksDueForContactForAsync(string agentId, AgentIdType agentIdType,
            string partnerContactId, int pageNumber = 1);
        
        Task<Response<TaskResponse>> GetTaskDueBetweenAsync(string agentId, AgentIdType agentIdType, DateTime startDate,
            DateTime endDate,  int pageNumber =1);

        Task<Response<TaskResponse>> GetTasksAsync(string agentId, AgentIdType agentIdType, DateTime? startDate,
            DateTime? endDate, string partnerContactId, int pageNumber = 1);
        
        
    }
}