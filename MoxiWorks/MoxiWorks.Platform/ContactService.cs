using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Moxi Works Platform Contact entities represent an agent’s contacts in the 
    /// Moxi Works Platform.
    /// </summary>
    public class ContactService : IContactService
    {
        public IMoxiWorksClient Client { get; set; }
        public ContactService(IMoxiWorksClient client)
        {
            Client = client;
        }
        
        /// <summary>
        /// Returns the specified Contact if it exist.
        /// </summary>
        /// <param name="agentId">
        /// Must include either:
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an Contact entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your Contact request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an Contact entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or moxi_works_agent_id is required 
        /// and must reference a valid Moxi Works Agent ID for your Contact request to be accepted.
        /// Agent ID for your Contact request to be accepted.
        /// </param>
        /// <param name="agentIdType">What agentId type you are using.</param>
        /// <param name="partnerContactId">
        /// This is the unique identifer you use in your system that has been associated 
        /// with the Contact that you are finding.
        /// </param>
        /// <returns> Conact Response empty if contact not found</returns>
        public async Task<Response<Contact>> GetContactAsync(string agentId, AgentIdType agentIdType, string partnerContactId)
        {
            var builder = new UriBuilder($"contacts/{partnerContactId}")
            .AddQueryPerameterAgentId(agentId,agentIdType);

            return await Client.GetRequestAsync<Contact>(builder.GetUrl());
        }
        
        /// <summary>
        /// Synchronous wrapper for GetContactAsync
        /// </summary>
        public Response<Contact> GetContact(string agentId, AgentIdType agentIdType, string partnerContactId)
        {
            return System.Threading.Tasks.Task.Run(() => GetContactAsync(agentId,agentIdType, partnerContactId)).Result; 
        }
        
        /// <summary>
        /// Create and returns a new Contact.
        /// </summary>
        /// <param name="contact">
        /// Contact to create. 
        /// </param>
        /// <returns>a Contact Response</returns>
        public async Task<Response<Contact>> CreateContactAsync(Contact contact)
        {
            var builder = new UriBuilder("contacts");

            return await Client.PostRequestAsync(builder.GetUrl(), contact);
        }
        
        /// <summary>
        /// Synchronous wrapper for CreateContactAsync
        /// </summary>
        public Response<Contact> CreateContact(Contact contact)
        {
            return System.Threading.Tasks.Task.Run(() => CreateContactAsync(contact)).Result; 
        }

        /// <summary>
        /// Update an existing contact
        /// </summary>
        /// <param name="contact">
        /// Contact to update
        /// </param>
        /// <returns>a Contact response.</returns>
        public async Task<Response<Contact>> UpdateContactAsync(Contact contact)
        {
            var builder = new UriBuilder($"contacts/{contact.PartnerContactId}");
            
            return await Client.PutRequestAsync(builder.GetUrl(), contact);
        }
        
        /// <summary>
        /// Synchronous wrapper for UpdateContactAsync
        /// </summary>
        public Response<Contact> UpdateContact(Contact contact)
        {
            return System.Threading.Tasks.Task.Run(() => UpdateContactAsync(contact)).Result; 
        }
      
        
        /// <summary>
        /// Gets Contact through the specified ID type.
        /// </summary>
        /// <param name="agentId">
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your ActionLog request to be accepted.
        /// </param>
        /// <param name="emailAddress">An email address associated with the Contact record. May be primary or secondary.</param>
        /// <param name="contactName">The full name of the contact which you are trying to find the Contact record for.</param>
        /// <param name="phoneNumber">A phone number associated with the Contact record. May be primary or secondary.</param>
        /// <param name="updatedSince">Paged responses of all Contact objects updated after this Unix timestamp will be returned in the response.</param>
        /// <param name="pageNumber">Page of Contact records to return. Use if total_pages indicates that there is more than one page of data available.</param>
        /// <returns>response of contacts</returns>
        public async Task<Response<ContactResults>> GetContactsAsync(string agentId, AgentIdType agentIdType, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            return await GetContactsUpdatedSinceAsync(agentId, agentIdType, emailAddress, contactName, phoneNumber,
                updatedSince, pageNumber);
        }
        
        /// <summary>
        /// Synchronous wrapper for GetContactsAsync
        /// </summary>
        public Response<ContactResults> GetContacts(string agentId, AgentIdType agentIdType, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            return System.Threading.Tasks.Task.Run(() => GetContactsUpdatedSinceAsync( 
                agentId,  
                agentIdType,  
                emailAddress,
                contactName,  
                phoneNumber, 
                updatedSince, 
                pageNumber)).Result; 
        }
        
        
        /// <summary>
        /// Gets Contact through the AgentUuid.
        /// </summary>
        /// <param name="agentId">
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your ActionLog request to be accepted.
        /// </param>
        /// <param name="emailAddress">An email address associated with the Contact record. May be primary or secondary.</param>
        /// <param name="contactName">The full name of the contact which you are trying to find the Contact record for.</param>
        /// <param name="phoneNumber">A phone number associated with the Contact record. May be primary or secondary.</param>
        /// <param name="updatedSince">Paged responses of all Contact objects updated after this Unix timestamp will be returned in the response.</param>
        /// <param name="pageNumber">Page of Contact records to return. Use if total_pages indicates that there is more than one page of data available.</param>
        /// <returns>response of contacts</returns>
        public async Task<Response<ContactResults>> GetContactResultsAgentUuidAsync(string AgentId, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            return await GetContactsUpdatedSinceAsync(AgentId, AgentIdType.AgentUuid, emailAddress, contactName, phoneNumber,
                updatedSince, pageNumber);
        }

        /// <summary>
        /// Synchronous wrapper for GetContactResultsAgentUuidAsync
        /// </summary>
        public Response<ContactResults> GetContactResultsAgentUuid(string AgentId, string emailAddress = null, string contactName = null,
            string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            return System.Threading.Tasks.Task.Run(() => GetContactResultsAgentUuidAsync( 
                AgentId,  
                emailAddress,
                contactName,  
                phoneNumber, 
                updatedSince, 
                pageNumber)).Result; 
        }

        
        /// <summary>
        /// Gets Contact through the MoxiWorksAgentId.
        /// </summary>
        /// <param name="agentId">
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or moxi_works_agent_id is required 
        /// and must reference a valid Moxi Works Agent ID for your ActionLog request to be accepted.
        /// Agent ID for your ActionLog request to be accepted.
        /// </param>
        /// <param name="emailAddress">An email address associated with the Contact record. May be primary or secondary.</param>
        /// <param name="contactName">The full name of the contact which you are trying to find the Contact record for.</param>
        /// <param name="phoneNumber">A phone number associated with the Contact record. May be primary or secondary.</param>
        /// <param name="updatedSince">Paged responses of all Contact objects updated after this Unix timestamp will be returned in the response.</param>
        /// <param name="pageNumber">Page of Contact records to return. Use if total_pages indicates that there is more than one page of data available.</param>
        /// <returns>response of contacts</returns>
        public async Task<Response<ContactResults>> GetContactResultsMoxiWorksAgentIdAsync(string AgentId, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            return await GetContactsUpdatedSinceAsync(AgentId, AgentIdType.MoxiWorksagentId, emailAddress, contactName,
                phoneNumber, updatedSince, pageNumber);
        }

        public Response<ContactResults> GetContactResultsMoxiWorksAgentId(string AgentId, string emailAddress = null, string contactName = null,
            string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Synchronous wrapper for GetContactResultsMoxiWorksAgentId
        /// </summary>
        public  Response<ContactResults> GetContactResultsMoxiWorksAgentId(string agentId, AgentIdType agentIdType, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            return System.Threading.Tasks.Task.Run(() => GetContactsUpdatedSinceAsync( 
                agentId,  
                agentIdType,  
                emailAddress,
                contactName,  
                phoneNumber, 
                updatedSince, 
                pageNumber)).Result; 

        }

        /// <summary>
        /// Gets Contact either through the AgentUuid or MoxiWorksAgentId.
        /// </summary>
        /// <param name="agentId">
        /// Must include either:
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your ActionLog request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or moxi_works_agent_id is required 
        /// and must reference a valid Moxi Works Agent ID for your ActionLog request to be accepted.
        /// Agent ID for your ActionLog request to be accepted.
        /// </param>
        /// <param name="emailAddress">An email address associated with the Contact record. May be primary or secondary.</param>
        /// <param name="contactName">The full name of the contact which you are trying to find the Contact record for.</param>
        /// <param name="phoneNumber">A phone number associated with the Contact record. May be primary or secondary.</param>
        /// <param name="updatedSince">Paged responses of all Contact objects updated after this Unix timestamp will be returned in the response.</param>
        /// <param name="pageNumber">Page of Contact records to return. Use if total_pages indicates that there is more than one page of data available.</param>
        /// <returns>response of contacts</returns>
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
        
        /// <summary>
        /// Synchronous wrapper for GetContactsUpdatedSinceAsync
        /// </summary>
        public  Response<ContactResults> GetContactsUpdatedSince(string agentId, AgentIdType agentIdType, string emailAddress = null,
            string contactName = null, string phoneNumber = null, DateTime? updatedSince = null, int pageNumber = 1)
        {
            return System.Threading.Tasks.Task.Run(() => GetContactsUpdatedSinceAsync( 
                agentId,  
                agentIdType,  
                emailAddress,
                contactName,  
                phoneNumber, 
                updatedSince, 
                pageNumber)).Result; 

        }

   
    }
}
