using System;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{
    public class TaskService : ITaskService
    {
        private readonly MoxiWorksClient Client; 

        public TaskService(MoxiWorksClient client)
        {
            Client = client; 
        }

        public async Task<Response<Task>> GetTaskAsync(string agentId, AgentIdType agentIdType, string partnerContactId,
            string partnerTaskId)
        {
            var builder = new UriBuilder($"task/{partnerTaskId}")
            .AddQueryPerameterAgentId(agentId,agentIdType)
            .AddQueryParameter("partner_contact_id", partnerContactId);

            return await Client.GetRequestAsync<Task>(builder.GetUrl()); 
        }

        public async  Task<Response<Task>> UpdateTaskAsync(Task task)
        {
            var builder = new UriBuilder($"task/{task.PartnerTaskId}");
            return  await Client.PutRequestAsync(builder.GetUrl(),task);
        }

        public async Task<Response<Task>> CreateTaskAsync(Task task)
        {
            var builder = new UriBuilder($"task");
            return await Client.PostRequestAsync(builder.GetUrl(), task);
        }

        public async Task<Response<TaskResponse>> GetTaskDueBetweenAsync(string agentId, AgentIdType agentIdType, DateTime startDate,
            DateTime endDate, string partnerContactId, int pageNumber =1)
        {
            var builder = new UriBuilder("task")
            .AddQueryPerameterAgentId(agentId,agentIdType)
            .AddQueryParameter("start_date",startDate)
            .AddQueryParameter("start_date", endDate)
            .AddQueryParameter("partner_contact_id", partnerContactId)
            .AddQueryParameter("page_number", pageNumber);

            return await Client.GetRequestAsync<TaskResponse>(builder.GetUrl());
        }

    }
}
