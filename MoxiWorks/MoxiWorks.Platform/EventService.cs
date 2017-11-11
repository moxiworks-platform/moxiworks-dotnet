using System.Collections.Generic;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Moxi Works Platform Event entities represent appointments, 
    /// meetings or other events scheduled for an agent.
    /// </summary>
    public class EventService : IEventService
    {
        public IMoxiWorksClient Client { get; set; }

        public EventService(IMoxiWorksClient client)
        {
            Client = client; 
        }

        /// <summary>
        /// Create an event
        /// </summary>
        /// <param name="cmaEvent"> The Event you want to create</param>
        /// <returns>The event you create.</returns>
        public async Task<Response<Event>> CreateEventAsync(Event cmaEvent)
        {
            var builder = new UriBuilder("events");

            return await Client.PostRequestAsync(builder.GetUrl(), cmaEvent);
        }

        /// <summary>
        /// Update an existing event.
        /// </summary>
        /// <param name="updateEvent">Event you want to update.</param>
        /// <returns></returns>
        public async Task<Response<Event>> UpdateEventAsync(Event updateEvent)
        {
            var builder = new UriBuilder($"events/{updateEvent.PartnerEventId}");
            return await Client.PutRequestAsync(builder.GetUrl(), updateEvent);
        }

        /// <summary>
        /// Get an Event if exists. 
        /// </summary>
        /// <param name="agentId">
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an Event entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your Event entry  request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an Event entry  entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or MoxiWorksAgentID is required 
        /// and must reference a valid Moxi Works Agent ID for your Event entry  request to be accepted.
        /// Agent ID for your Buyer Transaction entry  request to be accepted.
        /// </param>
        /// <param name="agentIdType">What agentId type you are using.</param>
        /// <param name="partnerEventId">This is the unique identifer you 
        /// use in your system that has been associated with the Event that you are 
        /// searching for.</param>
        /// <returns>returns the Event or an empty Event if not </returns>
        public async Task<Response<Event>> GetEventAsync(string agentId, AgentIdType agentIdType, string partnerEventId)
        {
            var builder = new UriBuilder($"events/{partnerEventId}")
            .AddQueryPerameterAgentId(agentId,agentIdType);
            return await Client.GetRequestAsync<Event>(builder.GetUrl());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="agentId">
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an Event entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your Event entry  request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an Event entry  entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or MoxiWorksAgentID is required 
        /// and must reference a valid Moxi Works Agent ID for your Event entry  request to be accepted.
        /// Agent ID for your Buyer Transaction entry  request to be accepted.
        /// </param>
        /// <param name="agentIdType">What agentId type you are using.</param>
        /// <param name="eventStart">This is the earliest time that you are searching 
        /// for an Event to be in. This data is required and must be a 
        /// Unix timestamp before eventEnd.</param>
        /// <param name="eventEnd">
        /// This is the latest time that you are searching for an Event to be in. 
        /// This data is required and must be a Unix timestamp after evntStart.</param>
        /// <returns>List of event within the date params</returns>
        public  async Task<Response<EventResults>> GetEventsByDateAsync(string agentId, AgentIdType agentIdType, int eventStart, int eventEnd)
        {
            var builder = new UriBuilder("events")
            .AddQueryPerameterAgentId(agentId, agentIdType)
            .AddQueryParameter("date_start", eventStart)
            .AddQueryParameter("date_end", eventEnd);

            var resultsList = await Client.GetRequestAsync<List<EventDateList>>(builder.GetUrl());

            var results = new EventResults
            {
                EventListDates = resultsList.Item
            };

            return new Response<EventResults>
            {
                Errors = resultsList.Errors,
                Item = results
            };
        }

        /// <summary>
        /// Delete an existing event
        /// </summary>
        /// <param name="agentId">
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an Event entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your Event entry  request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an Event entry  entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or MoxiWorksAgentID is required 
        /// and must reference a valid Moxi Works Agent ID for your Event entry  request to be accepted.
        /// Agent ID for your Buyer Transaction entry  request to be accepted.
        /// </param>
        /// <param name="agentIdType">What agentId type you are using.</param>
        /// <param name="eventId">This is the unique identifer you use in your system that has been associated with the Event. This data is required and must reference a previously created Event you have created on The Moxi Works Platform.</param>
        /// <returns> if the delete was successful.</returns>
        public async Task<Response<EventDeleteResult>> DeleteEventAsync(string agentId, AgentIdType agentIdType, string eventId)
        {
            var builder = new UriBuilder($"events/{eventId}")
            .AddQueryPerameterAgentId(agentId, agentIdType);

            return await Client.DeleteRequestAsync<EventDeleteResult>(builder.GetUrl());

        }


    }
}
