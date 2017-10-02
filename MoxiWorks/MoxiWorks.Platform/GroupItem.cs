using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    public class GroupItem
    {
        [JsonProperty("moxi_works_group_name")]
        public string MoxiWorksGroupName { get; set; }
        [JsonProperty("moxi_works_group_id")]
        public string MoxiWorksGroupId { get; set; }
        [JsonProperty("transient")]
        public bool? Transient { get; set; }
    }
}