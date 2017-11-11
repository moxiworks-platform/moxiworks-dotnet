using System;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Moxi Works Platform Task entities represent tasks that agents need to perform on behalf of, 
    /// or in relation to their contacts.
    /// </summary>
    public class TaskService : ITaskService
    {
        private readonly IMoxiWorksClient Client; 

        public TaskService(IMoxiWorksClient client)
        {
            Client = client; 
        }

        /// <summary>
        /// Returns the specified Task if it exist.
        /// </summary>
        /// <param name="agentId">
        /// Must include either:
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an Group entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your Group request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an Group entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or moxi_works_agent_id is required 
        /// and must reference a valid Moxi Works Agent ID for your Group request to be accepted.
        /// Agent ID for your Group request to be accepted.
        /// </param>
        /// <param name="agentIdType">What agentId type you are using.</param>
        /// <param name="partnerContactId">
        /// This is the unique identifer you use in your system that has been associated with the Contact that this Task regards.
        /// </param>
        /// <param name="partnerTaskId"></param>
        /// <returns>Task Response emptu if task does not exist</returns>
        public async Task<Response<Task>> GetTaskAsync(string agentId, AgentIdType agentIdType, string partnerContactId,
            string partnerTaskId)
        {
            var builder = new UriBuilder($"task/{partnerTaskId}")
            .AddQueryPerameterAgentId(agentId,agentIdType)
            .AddQueryParameter("partner_contact_id", partnerContactId);

            return await Client.GetRequestAsync<Task>(builder.GetUrl()); 
        }

        /// <summary>
        /// update an existing task
        /// </summary>
        /// <param name="task">
        /// The Task you want to update
        /// </param>
        /// <returns>The Response containing the update Task </returns>
        public async  Task<Response<Task>> UpdateTaskAsync(Task task)
        {
            var builder = new UriBuilder($"task/{task.PartnerTaskId}");
            return  await Client.PutRequestAsync(builder.GetUrl(),task);
        }
        
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="task">the task you want to create.</param>
        /// <returns>The Response containing the created Task </returns>
        public async Task<Response<Task>> CreateTaskAsync(Task task)
        {
            var builder = new UriBuilder("task");
            return await Client.PostRequestAsync(builder.GetUrl(), task);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="agentId">
        /// Must include either:
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an Group entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your Group request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an Group entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or moxi_works_agent_id is required 
        /// and must reference a valid Moxi Works Agent ID for your Group request to be accepted.
        /// Agent ID for your Group request to be accepted.
        /// </param>
        /// <param name="agentIdType">What agentId type you are using.</param>
        /// <param name="startDate">Date to start Searching</param>
        /// <param name="endDate">Date to end Search</param>
        /// <param name="partnerContactId">   
        /// This is the unique identifer you use in your system that has been associated with the Contact that this Task regards.
        /// </param>
        /// <param name="pageNumber">The page you want to view.</param>
        /// <returns>Response with a list of Task in a Task Response object </returns>
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
 