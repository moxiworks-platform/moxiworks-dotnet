using System;
using MoxiWorks.Platform.Serializers;
using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    public class SoldListing : ListingBase
    {
        /// <summary>
        /// Date on which this listing was sold.
        /// </summary>
        [JsonConverter(typeof(MoxiDateFormatConverter), "MM/dd/yyyy")]
        public DateTime? SoldDate { get; set; }
        /// <summary>
        /// Price for which this listing was sold.
        /// </summary>
        public int? SoldPrice { get; set; }
        /// <summary>
        /// Full name of the buyer’s agent
        /// </summary>
        public string BuyerAgentFullName { get; set; }
        /// <summary>
        /// A unique identifier for the buyer’s agent. This will correspond to the uuid field of an Agent.
        /// </summary>
        public string BuyerAgentUUID { get; set; }
        /// <summary>
        /// The name of the buyer agent’s office.
        /// </summary>
        public string BuyerAgentOfficeName { get; set; }
        /// <summary>
        /// The ID of the buyer agent’s office.
        /// </summary>
        public string BuyerAgentOfficeID { get; set; }
        /// <summary>
        /// The MoxiWorks ID of the buyer agent’s office.
        /// </summary>
        public string BuyerAgentMoxiWorksOfficeID { get; set; }
    }
}