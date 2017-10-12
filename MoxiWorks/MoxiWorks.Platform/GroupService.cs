using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    public class GroupService : IGroupService
    {
        public MoxiWorksClient Client { get; set; }
        public GroupService(MoxiWorksClient client)
        {
            Client = client; 
        }


        public Response<Group> GetGroup(string agentId, AgentIdType agentIdType, string moxiWorksGroupId)
        {
            var builder = new UriBuilder($"groups/{moxiWorksGroupId}")
            .AddQueryPerameterAgentId(agentId,agentIdType);

            return Client.GetRequest<Group>(builder.GetUrl());

        }

        public Response<ICollection<GroupItem>> GetGroups(string agentId, AgentIdType agentIdType, string name = null)
        {
            var builder = new UriBuilder("groups")
            .AddQueryPerameterAgentId(agentId,agentIdType)
            .AddQueryParameter("name", name);
            var results = Client.GetRequest<List<GroupItem>>(builder.GetUrl());

            return new Response<ICollection<GroupItem>>
            {
                Errors = results.Errors,
                Item = results.Item
            };
        }

    }
}
