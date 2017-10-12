using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    public interface IGroupService
    {
        MoxiWorksClient Client { get; set; }
        Response<Group> GetGroup(string agentId, AgentIdType agentIdType, string moxiWorksGroupId);
        Response<ICollection<GroupItem>> GetGroups(string agentId, AgentIdType agentIdType, string name = null);
    }
}