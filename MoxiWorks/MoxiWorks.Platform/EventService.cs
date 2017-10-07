using System.Collections.Generic;
namespace MoxiWorks.Platform
{

    public class EventService
    {
        public MoxiWorksClient Client { get; set; }

        public EventService(MoxiWorksClient client)
        {
            Client = client; 
        }

        public Response<Event> CreateEvent(Event cmaEvent)
        {
            var builder = new UriBuilder("/events");

            return Client.PostRequest(builder.GetUrl(), cmaEvent);
        }

        public Response<Event> UpdateEvent(Event updateEvent)
        {
            var builder = new UriBuilder($"/events/{updateEvent.PartnerEventId}");
            return Client.PutRequest(builder.GetUrl(), updateEvent);
        }

        public Response<Event> GetEvent(string agentId, AgentIdType agentIdType, string partnerEventId)
        {
            var builder = new UriBuilder($"/events/{partnerEventId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
            return Client.GetRequest<Event>(builder.GetUrl());
        }

        public Response<EventResults> GetEventsByDate(string agentId, AgentIdType agentIdType, int eventStart, int eventEnd)
        {
            var builder = new UriBuilder($"/events");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);
            builder.AddQueryParameter("date_start", eventStart);
            builder.AddQueryParameter("date_end", eventEnd);

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
            var builder = new UriBuilder($"/events/{eventId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);


            return Client.DeleteRequest<EventDeleteResult>(builder.GetUrl());

        }


    }
}
