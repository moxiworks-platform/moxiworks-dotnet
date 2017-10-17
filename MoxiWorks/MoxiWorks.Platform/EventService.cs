using System.Collections.Generic;
using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{

    public class EventService : IEventService
    {
        public MoxiWorksClient Client { get; set; }

        public EventService(MoxiWorksClient client)
        {
            Client = client; 
        }

        public async Task<Response<Event>> CreateEventAsync(Event cmaEvent)
        {
            var builder = new UriBuilder("events");

            return await Client.PostRequestAsync(builder.GetUrl(), cmaEvent);
        }

        public async Task<Response<Event>> UpdateEventAsync(Event updateEvent)
        {
            var builder = new UriBuilder($"events/{updateEvent.PartnerEventId}");
            return await Client.PutRequestAsync(builder.GetUrl(), updateEvent);
        }

        public async Task<Response<Event>> GetEventAsync(string agentId, AgentIdType agentIdType, string partnerEventId)
        {
            var builder = new UriBuilder($"events/{partnerEventId}")
            .AddQueryPerameterAgentId(agentId,agentIdType);
            return await Client.GetRequestAsync<Event>(builder.GetUrl());
        }

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

        public async Task<Response<EventDeleteResult>> DeleteEventAsync(string agentId, AgentIdType agentIdType, string eventId)
        {
            var builder = new UriBuilder($"events/{eventId}")
            .AddQueryPerameterAgentId(agentId, agentIdType);

            return await Client.DeleteRequestAsync<EventDeleteResult>(builder.GetUrl());

        }


    }
}
