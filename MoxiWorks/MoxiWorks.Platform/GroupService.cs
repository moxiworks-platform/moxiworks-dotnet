using System.Collections.Generic;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{
    public class GroupService : IGroupService
    {
        public MoxiWorksClient Client { get; set; }
        public GroupService(MoxiWorksClient client)
        {
            Client = client; 
        }


        public async Task<Response<Group>> GetGroupAsync(string agentId, AgentIdType agentIdType, string moxiWorksGroupId)
        {
            var builder = new UriBuilder($"groups/{moxiWorksGroupId}")
            .AddQueryPerameterAgentId(agentId,agentIdType);

            return await Client.GetRequestAsync<Group>(builder.GetUrl());

        }

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
