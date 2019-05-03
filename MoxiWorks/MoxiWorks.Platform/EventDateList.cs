﻿using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using MoxiWorks.Platform.Serializers;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Event Collection sorted by date. 
    /// </summary>
    public class EventDateList
    {
       
        /// <summary>
        /// This is a string representing a date in MM/DD/YYYY format. 
        /// Any event Event whose duration spans or falls within this 
        /// day will be included in the results for this day.
        /// </summary>
        [JsonProperty("date")]
        [JsonConverter(typeof(MoxiDateFormatConverter), "MM/dd/yyyy")]
        public DateTime? date { get; set; } 
        
        /// <summary>
        /// This is the payload of Event objects that fall on this day. 
        /// If no Event objects span this duration, then the events array will be emtpy.
        /// </summary>
        [JsonProperty("events")]
        public List<Event> Events = new List<Event>();
       
    }
}