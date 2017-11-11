using System.Collections.Generic;
using System.Threading.Tasks;


namespace MoxiWorks.Platform.Interfaces
{
    /// <summary>
    /// Wrapper around the service to allow stubbing of the service.
    /// </summary>
    public interface IGroupService
    {
        IMoxiWorksClient Client { get; set; }
        Task<Response<Group>> GetGroupAsync(string agentId, AgentIdType agentIdType, string moxiWorksGroupId);
        Task<Response<ICollection<GroupItem>>> GetGroupsAsync(string agentId, AgentIdType agentIdType, string name = null);
    }
}