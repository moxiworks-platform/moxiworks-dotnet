using System;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace MoxiWorks.Platform
{
    public class EventDateList
    {
       
        [JsonProperty("date")]
        public DateTime? date { get; set; } 
        
        [JsonProperty("events")]
        public List<Event> Events = new List<Event>();
       
    }
}