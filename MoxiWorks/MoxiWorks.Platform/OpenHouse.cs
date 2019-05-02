using System;
using MoxiWorks.Platform.Serializers;
using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    public class OpenHouse
    {
        /// <summary>
        /// Represent the date of the open house. YYYY-MM-DD formatted string representing the date of the open house
        /// </summary>
        [JsonConverter(typeof(MoxiDateFormatConverter), "yyyy-MM-dd")]
        public DateTime Date { get; set; }
        
        /// <summary>
        /// HH:MM:SS formatted string representing the time when the open house starts. 
        /// This is expressed in the local time where the listing is located.
        /// </summary>
        public string StartTime { get; set; }
        
        /// <summary>
        /// HH:MM:SS formatted string representing the time when the open house ends. 
        /// This is expressed in the local time where the listing is located.
        /// </summary>
        public string EndTime { get; set; }
    }
}