using System.Collections.Generic;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Moxi Works Platform Group entities represent groupings of an agent’s contacts.
    /// </summary>
    public class GroupService : IGroupService
    {
        public MoxiWorksClient Client { get; set; }

        public GroupService(MoxiWorksClient client)
        {
            Client = client; 
        }

        /// <summary>
        /// Get Single Group
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
        /// <param name="moxiWorksGroupId">This is the name of a Group to be shown</param>
        /// <returns></returns>
        public async Task<Response<Group>> GetGroupAsync(string agentId, AgentIdType agentIdType, string moxiWorksGroupId)
        {
            var builder = new UriBuilder($"groups/{moxiWorksGroupId}")
            .AddQueryPerameterAgentId(agentId,agentIdType);

            return await Client.GetRequestAsync<Group>(builder.GetUrl());
        }

        /// <summary>
        /// When searching for Group objects using the Moxi Works platform API, format your data using the following parameters.
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
        /// <param name="name">This is the name of a Group to be searched for.</param>
        /// <returns></returns>
        public async Task<Response<ICollection<GroupItem>>> GetGroupsAsync(string agentId, AgentIdType agentIdType, string name = null)
        {
            var builder = new UriBuilder("groups")
            .AddQueryPerameterAgentId(agentId,agentIdType)
            .AddQueryParameter("name", name);
            var results = await Client.GetRequestAsync<List<GroupItem>>(builder.GetUrl());

            return new Response<ICollection<GroupItem>>
            {
                Errors = results.Errors,
                Item = results.Item
            };
        }

    }
}
