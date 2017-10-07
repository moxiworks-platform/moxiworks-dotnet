using System;

namespace MoxiWorks.Platform
{
    public class ContactService
    {
        public MoxiWorksClient Client { get; set; }
        public ContactService(MoxiWorksClient client)
        {
            Client = client;
        }
        public Response<Contact> GetContact(string agentId, AgentIdType agentIdType, string partnerContactId)
        {
            var builder = new UriBuilder($"/contacts/{partnerContactId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            return Client.GetRequest<Contact>(builder.GetUrl());
        }

        public Response<Contact> CreateContact(Contact contact)
        {
            var builder = new UriBuilder($"/contacts");

            return Client.PostRequest(builder.GetUrl(), contact);
        }

        public Response<Contact> UpdateContact(Contact contact)
        {
            var builder = new UriBuilder($"/contacts/{contact.PartnerContactId}");
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

        public Response<ContactResults> GetContactsUpdatedSince(string AgentId, AgentIdType agentIdType,
            string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {

            var builder = new UriBuilder("/contacts/");

            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                AgentId);


            if (updatedSince != null)
            {
                builder.AddQueryParameter("updated_since", updatedSince.Value);
            }

            builder.AddQueryParameter("email_address", emailAddress);
            builder.AddQueryParameter("contact_name", contactName);
            builder.AddQueryParameter("phone_number", phoneNumber);
            builder.AddQueryParameter("page_number", pageNumber);
            return Client.GetRequest<ContactResults>(builder.GetUrl());
        }

    }
}
