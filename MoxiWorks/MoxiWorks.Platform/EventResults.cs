using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Collection of Events dates returned by an event query.
    /// </summary>
    public class EventResults
    {
        /// <summary>
        /// List of EventDates
        /// </summary>
        public List<EventDateList> EventListDates { get; set; } = new List<EventDateList>(); 
    }
}