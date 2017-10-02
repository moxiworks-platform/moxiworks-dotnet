using System.Collections.Generic;
using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    public class Event
    {
        
        [JsonProperty("partner_event_id")]
        public string PartnerEventId { get; set; }
        [JsonProperty("agent_uuid")]
        public string AgentUuId { get; set; }
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }
        [JsonProperty("event_subject")]
        public string EventSubject { get; set; }
        [JsonProperty("event_location")]
        public string EventLocation { get; set; }
        [JsonProperty("note")]
        public string Note { get; set; }
        [JsonProperty("send_reminder")]
        public bool? SendReminder { get; set; }
        [JsonProperty("remind_minutes_before")]
        public int? RemindMinutesBefore { get; set; }
        [JsonProperty("event_start")]
        public int? EventStart { get; set; }
        [JsonProperty("event_end")]
        public int? EventEnd { get; set; }
        [JsonProperty("all_day")]
        public bool? AllDay { get; set; }
        [JsonProperty("attendees")]
        public List<string> Attendees { get; set; } = new List<string>();

    }
}