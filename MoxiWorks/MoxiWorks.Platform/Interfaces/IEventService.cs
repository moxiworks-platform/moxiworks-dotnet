using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    /// <summary>
    /// Wrapper around the service to allow stubbing of the service.
    /// </summary>
    public interface IEventService
    {
        MoxiWorksClient Client { get; set; }
        Task<Response<Event>> CreateEventAsync(Event cmaEvent);
        Task<Response<Event>> UpdateEventAsync(Event updateEvent);
        Task<Response<Event>> GetEventAsync(string agentId, AgentIdType agentIdType, string partnerEventId);
        Task<Response<EventResults>> GetEventsByDateAsync(string agentId, AgentIdType agentIdType, int eventStart, int eventEnd);
        Task<Response<EventDeleteResult>> DeleteEventAsync(string agentId, AgentIdType agentIdType, string eventId);
    }
}