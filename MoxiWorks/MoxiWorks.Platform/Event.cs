using System.Collections.Generic;
using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    /// <summary>
    /// Moxi Works Platform Event entity represents appointments, 
    /// meetings or other events scheduled for an agent.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// This is the unique identifer you use in your system that has been associated with 
        /// the Event that you are creating. This data is required and must be a unique key.
        /// </summary>
        [JsonProperty("partner_event_id")]
        public string PartnerEventId { get; set; }
        /// <summary>
        /// This is the Moxi Works Platform ID of the Agent which an Event entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. agent_uuid or moxi_works_agent_id is required and must reference a valid Moxi Works Agent ID for your Event Create request to be accepted.
        /// </summary>
        [JsonProperty("agent_uuid")]
        public string AgentUuId { get; set; }
        /// <summary>
        /// This is the Moxi Works Platform ID of the Agent which this Event is to be associated 
        /// with. This will be a string that may take the form of an email address, or a 
        /// unique identification string. This data is required and must reference a valid 
        /// Moxi Works Agent ID for your Event Create request to be accepted.
        /// </summary>
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }
        /// <summary>
        /// This is a short, descriptive, human readable phrase to be displayed to the 
        /// agent which lets them know what this Event regards.
        /// </summary>
        [JsonProperty("event_subject")]
        public string EventSubject { get; set; }
        /// <summary>
        /// This is a human readable locatition reference regarding where the event 
        /// is located that will be meaningful to the agent.
        /// </summary>
        [JsonProperty("event_location")]
        public string EventLocation { get; set; }
        /// <summary>
        /// Notes about the event.
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; set; }
        /// <summary>
        /// Whether to send a reminder about the event to attendees before the event starts.
        /// </summary>
        [JsonProperty("send_reminder")]
        public bool? SendReminder { get; set; }
        /// <summary>
        /// If send_reminder is true, this is how many minutes before the start of the event 
        /// to send the reminder. Default is 15 minutes before.
        /// </summary>
        [JsonProperty("remind_minutes_before")]
        public int? RemindMinutesBefore { get; set; }
        /// <summary>
        /// This is the Unix timestamp representing the start time of the Event 
        /// that you are creating. This data is required and must be a valid Unix timestamp.
        /// </summary>
        [JsonProperty("event_start")]
        public int? EventStart { get; set; }
        /// <summary>
        /// This is the Unix timestamp representing the end time of the Event 
        /// that you are creating. This data is required and must be a valid Unix timestamp.
        /// </summary>
        [JsonProperty("event_end")]
        public int? EventEnd { get; set; }
        /// <summary>
        /// Whether the event is an all day event.
        /// </summary>
        [JsonProperty("all_day")]
        public bool? AllDay { get; set; }
        /// <summary>
        /// This is a  list of contacts that have already been added through the Moxi Works 
        /// Platform API who will be present at the referenced event. 
        /// (Use IDs from your system – i.e. partner_contact_id from Contact Create ).
        /// </summary>
        [JsonProperty("attendees")]
        public List<string> Attendees { get; set; } = new List<string>();

    }
}