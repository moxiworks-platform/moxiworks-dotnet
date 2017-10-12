using System.Collections.Generic;
namespace MoxiWorks.Platform
{

    public class EventService : IEventService
    {
        public MoxiWorksClient Client { get; set; }

        public EventService(MoxiWorksClient client)
        {
            Client = client; 
        }

        public Response<Event> CreateEvent(Event cmaEvent)
        {
            var builder = new UriBuilder("events");

            return Client.PostRequest(builder.GetUrl(), cmaEvent);
        }

        public Response<Event> UpdateEvent(Event updateEvent)
        {
            var builder = new UriBuilder($"events/{updateEvent.PartnerEventId}");
            return Client.PutRequest(builder.GetUrl(), updateEvent);
        }

        public Response<Event> GetEvent(string agentId, AgentIdType agentIdType, string partnerEventId)
        {
            var builder = new UriBuilder($"events/{partnerEventId}")
            .AddQueryPerameterAgentId(agentId,agentIdType);
            return Client.GetRequest<Event>(builder.GetUrl());
        }

        public Response<EventResults> GetEventsByDate(string agentId, AgentIdType agentIdType, int eventStart, int eventEnd)
        {
            var builder = new UriBuilder("events")
            .AddQueryPerameterAgentId(agentId, agentIdType)
            .AddQueryParameter("date_start", eventStart)
            .AddQueryParameter("date_end", eventEnd);

            var resultsList = Client.GetRequest<List<EventDateList>>(builder.GetUrl());

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

        public Response<EventDeleteResult> DeleteEvent(string agentId, AgentIdType agentIdType, string eventId)
        {
            var builder = new UriBuilder($"events/{eventId}")
            .AddQueryPerameterAgentId(agentId, agentIdType);

            return Client.DeleteRequest<EventDeleteResult>(builder.GetUrl());

        }


    }
}
