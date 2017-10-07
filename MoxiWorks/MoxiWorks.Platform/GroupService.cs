using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    public class GroupService
    {
        public MoxiWorksClient Client { get; set; }
        public GroupService(MoxiWorksClient client)
        {
            Client = client; 
        }


        public Response<Group> GetGroup(string agentId, AgentIdType agentIdType, string moxiWorksGroupId)
        {
            var builder = new UriBuilder($"groups/{moxiWorksGroupId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            return Client.GetRequest<Group>(builder.GetUrl());

        }

        public Response<ICollection<GroupItem>> GetGroups(string agentId, AgentIdType agentIdType, string name = null)
        {
            var builder = new UriBuilder("groups");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
            builder.AddQueryParameter("name", name);
            var results = Client.GetRequest<List<GroupItem>>(builder.GetUrl());

            return new Response<ICollection<GroupItem>>
            {
                Errors = results.Errors,
                Item = results.Item
            };
        }

    }
}
