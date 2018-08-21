using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// MLS Entry basic Moxi Works mls data
    /// </summary>
    public class MlsEntry
    {
        /// <summary>
        /// The Moxi Works internal unique name for the MLS.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// The name of the MLS as it is to be displayed to users.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        /// <summary>
        /// The abbreviation of the MLS.
        /// </summary>
        [JsonProperty("mls_abbreviation")]
        public string MlsAbbreviation { get; set; }

    }
}