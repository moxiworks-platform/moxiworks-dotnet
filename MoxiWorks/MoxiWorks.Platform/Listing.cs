using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Listing entity representing a Brokerage’s listing.
    /// </summary>
    public class Listing : ListingBase
    {
        /// <summary>
        /// Partner specific listing information in a json formatted string.
        /// The json data is deserialized into an Expando object.
        /// </summary>
        [JsonConverter(typeof(ExpandoObjectConverter))]
        public dynamic SharedPartnerData { get; set; }
    }
}