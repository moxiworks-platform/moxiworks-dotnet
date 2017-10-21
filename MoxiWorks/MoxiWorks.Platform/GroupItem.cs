using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// light weight objext returned we searching for Groups
    /// </summary>
    public class GroupItem
    {
        /// <summary>
        /// This is a human readable string meaningful to the 
        /// agent about what kind of Contact objects are in this Group.
        /// </summary>
        [JsonProperty("moxi_works_group_name")]
        public string MoxiWorksGroupName { get; set; }
        /// <summary>
        /// This is the unique identifier for this Group.
        /// </summary>
        [JsonProperty("moxi_works_group_id")]
        public string MoxiWorksGroupId { get; set; }
        /// <summary>
        /// Whether the group ID exists beyond name change.
        /// </summary>
        [JsonProperty("transient")]
        public bool? Transient { get; set; }
    }
}