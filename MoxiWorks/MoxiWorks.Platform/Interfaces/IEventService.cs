namespace MoxiWorks.Platform
{
    public interface IEventService
    {
        MoxiWorksClient Client { get; set; }
        Response<Event> CreateEvent(Event cmaEvent);
        Response<Event> UpdateEvent(Event updateEvent);
        Response<Event> GetEvent(string agentId, AgentIdType agentIdType, string partnerEventId);
        Response<EventResults> GetEventsByDate(string agentId, AgentIdType agentIdType, int eventStart, int eventEnd);
        Response<EventDeleteResult> DeleteEvent(string agentId, AgentIdType agentIdType, string eventId);
    }
}