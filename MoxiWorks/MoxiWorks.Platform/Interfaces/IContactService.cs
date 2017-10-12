using System;

namespace MoxiWorks.Platform
{
    public interface IContactService
    {
        MoxiWorksClient Client { get; set; }
        Response<Contact> GetContact(string agentId, AgentIdType agentIdType, string partnerContactId);
        Response<Contact> CreateContact(Contact contact);
        Response<Contact> UpdateContact(Contact contact);

        Response<ContactResults> GetContactResultsAgentUuid(string AgentId, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1);

        Response<ContactResults> GetContactResultsMoxiWorksagentId(string AgentId, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1);

        Response<ContactResults> GetContactsUpdatedSince(string AgentId, AgentIdType agentIdType,
            string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1);
    }
}