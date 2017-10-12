using System;

namespace MoxiWorks.Platform
{
    public interface ITaskService
    {
        Response<Task> GetTask(string agentId, AgentIdType agentIdType, string partnerContactId,
            string partnerTaskId);

        Response<Task> UpdateTask(Task task);
        Response<Task> CreateTask(Task task);

        Response<TaskResponse> GetTaskDueBetween(string agentId, AgentIdType agentIdType, DateTime startDate,
            DateTime endDate, string partnerContactId, int pageNumber =1);
    }
}