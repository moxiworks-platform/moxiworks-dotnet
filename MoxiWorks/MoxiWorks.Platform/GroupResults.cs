using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Collection of GroupItems returned from a search.
    /// </summary>
    public class GroupResults
    {
         public List<GroupItem> Groups { get; set; }  = new List<GroupItem>();  
    }
}