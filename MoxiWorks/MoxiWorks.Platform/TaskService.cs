using System;

namespace MoxiWorks.Platform
{
    public class TaskService
    {
        private readonly MoxiWorksClient Client; 

        public TaskService(MoxiWorksClient client)
        {
            Client = client; 
        }

        public Response<Task> GetTask(string agentId, AgentIdType agentIdType, string partnerContactId,
            string partnerTaskId)
        {
            var builder = new UriBuilder($"task/{partnerTaskId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
            builder.AddQueryParameter("partner_contact_id", partnerContactId);

            return Client.GetRequest<Task>(builder.GetUrl()); 
        }

        public Response<Task> UpdateTask(Task task)
        {
            var builder = new UriBuilder($"task/{task.PartnerTaskId}");
            return Client.PutRequest(builder.GetUrl(),task);
        }

        public Response<Task> CreateTask(Task task)
        {
            var builder = new UriBuilder($"task");
            return Client.PostRequest(builder.GetUrl(), task);
        }

        public Response<TaskResponse> GetTaskDueBetween(string agentId, AgentIdType agentIdType, DateTime startDate,
            DateTime endDate, string partnerContactId, int pageNumber =1)
        {
            var builder = new UriBuilder($"task");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
            builder.AddQueryParameter("start_date",startDate);
            builder.AddQueryParameter("start_date", endDate);
            builder.AddQueryParameter("partner_contact_id", partnerContactId);
            builder.AddQueryParameter("page_number", pageNumber);

            return Client.GetRequest<TaskResponse>(builder.GetUrl());
        }

    }
}
