
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    public class TeamResults
    {
        /// <summary>
        /// For queries with multi-page responses, use the page_number parameter to return data for specific pages. Data for page 1 is returned if this parameter is not included. 
        /// </summary>
        public int? PageNumber { get; set; } = 1;
        /// <summary>
        /// Use this parameter if total_pages indicates that there is more than one page of data available.
        /// </summary>
       
        public int? TotalPages { get; set; } = 1;
        /// <summary>
        /// List of a brockerages offices 
        /// </summary>
        public List<Team>Teams{ get; set; } = new List<Team>();

        public TeamResults()
        {
        }


        public TeamResults(IEnumerable<Team> results)
        {
            Teams = results.ToList(); 
        }
    }
}