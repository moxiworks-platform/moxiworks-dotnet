using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{
    public class ContactService : IContactService
    {
        public MoxiWorksClient Client { get; set; }
        public ContactService(MoxiWorksClient client)
        {
            Client = client;
        }
        public async Task<Response<Contact>> GetContactAsync(string agentId, AgentIdType agentIdType, string partnerContactId)
        {
            var builder = new UriBuilder($"contacts/{partnerContactId}")
            .AddQueryPerameterAgentId(agentId,agentIdType);

            return await Client.GetRequestAsync<Contact>(builder.GetUrl());
        }

        public async Task<Response<Contact>> CreateContactAsync(Contact contact)
        {
            var builder = new UriBuilder("contacts");

            return await Client.PostRequestAsync(builder.GetUrl(), contact);
        }

        public async Task<Response<Contact>> UpdateContactAsync(Contact contact)
        {
            var builder = new UriBuilder($"contacts/{contact.PartnerContactId}");
            
            return await Client.PutRequestAsync(builder.GetUrl(), contact);

        }

        public async Task<Response<ContactResults>> GetContactResultsAgentUuidAsync(string AgentId, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            return await GetContactsUpdatedSinceAsync(AgentId, AgentIdType.AgentUuid, emailAddress, contactName, phoneNumber,
                updatedSince, pageNumber);
        }

        public async Task<Response<ContactResults>> GetContactResultsMoxiWorksagentId(string AgentId, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            return await GetContactsUpdatedSinceAsync(AgentId, AgentIdType.MoxiWorksagentId, emailAddress, contactName,
                phoneNumber, updatedSince, pageNumber);
        }

        public async Task<Response<ContactResults>> GetContactsUpdatedSinceAsync(string agentId, AgentIdType agentIdType,
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

            return await Client.GetRequestAsync<ContactResults>(builder.GetUrl());
        }

    }
}
