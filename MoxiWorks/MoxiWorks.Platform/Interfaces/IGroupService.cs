using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoxiWorks.Platform
{
    public interface IGroupService
    {
        MoxiWorksClient Client { get; set; }
        Task<Response<Group>> GetGroupAsync(string agentId, AgentIdType agentIdType, string moxiWorksGroupId);
        Task<Response<ICollection<GroupItem>>> GetGroupsAsync(string agentId, AgentIdType agentIdType, string name = null);
    }
}