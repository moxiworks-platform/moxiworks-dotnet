using System;

namespace MoxiWorks.Platform
{
    public class ContactService : IContactService
    {
        public MoxiWorksClient Client { get; set; }
        public ContactService(MoxiWorksClient client)
        {
            Client = client;
        }
        public Response<Contact> GetContact(string agentId, AgentIdType agentIdType, string partnerContactId)
        {
            var builder = new UriBuilder($"contacts/{partnerContactId}")
            .AddQueryPerameterAgentId(agentId,agentIdType);

            return Client.GetRequest<Contact>(builder.GetUrl());
        }

        public Response<Contact> CreateContact(Contact contact)
        {
            var builder = new UriBuilder("contacts");

            return Client.PostRequest(builder.GetUrl(), contact);
        }

        public Response<Contact> UpdateContact(Contact contact)
        {
            var builder = new UriBuilder($"contacts/{contact.PartnerContactId}");
            
            return Client.PutRequest(builder.GetUrl(), contact);

        }

        public Response<ContactResults> GetContactResultsAgentUuid(string AgentId, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            return GetContactsUpdatedSince(AgentId, AgentIdType.AgentUuid, emailAddress, contactName, phoneNumber,
                updatedSince, pageNumber);
        }

        public Response<ContactResults> GetContactResultsMoxiWorksagentId(string AgentId, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            return GetContactsUpdatedSince(AgentId, AgentIdType.MoxiWorksagentId, emailAddress, contactName,
                phoneNumber, updatedSince, pageNumber);
        }

        public Response<ContactResults> GetContactsUpdatedSince(string agentId, AgentIdType agentIdType,
            string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {

            var builder = new UriBuilder("contacts");

            builder.AddQueryPerameterAgentId(agentId,agentIdType)
            .AddQueryParameter("email_address", emailAddress)
            .AddQueryParameter("contact_name", contactName)
            .AddQueryParameter("phone_number", phoneNumber)
            .AddQueryParameter("page_number", pageNumber);
            
            if (updatedSince != null)
            {
                builder.AddQueryParameter("updated_since", updatedSince.Value);
            }

            return Client.GetRequest<ContactResults>(builder.GetUrl());
        }

    }
}
