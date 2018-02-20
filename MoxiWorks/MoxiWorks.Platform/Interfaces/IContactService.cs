using System;
using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    /// <summary>
    /// Wrapper around the service to allow stubbing of the service.
    /// </summary>
    public interface IContactService
    {
        IMoxiWorksClient Client { get; set; }
        Task<Response<Contact>> GetContactAsync(string agentId, AgentIdType agentIdType, string partnerContactId);
        Task<Response<Contact>> CreateContactAsync(Contact contact);
        Task<Response<Contact>> UpdateContactAsync(Contact contact);

               
        Task<Response<ContactResults>> GetContactsAsync(string agentId, AgentIdType agentIdType, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1); 
        
        Task<Response<ContactResults>> GetContactResultsAgentUuidAsync(string AgentId, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1);

        Task<Response<ContactResults>> GetContactResultsMoxiWorksAgentIdAsync(string AgentId, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1);

        Task<Response<ContactResults>> GetContactsUpdatedSinceAsync(string agentId, AgentIdType agentIdType,
            string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1);
    }
}