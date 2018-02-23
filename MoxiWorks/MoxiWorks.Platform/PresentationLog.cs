using System;    
using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    public class PresentationLog
    {
        
        /// <summary>
        /// This is the Moxi Works Platform ID of the agent which an ActionLog entry is associated with. 
        /// This will be an RFC 4122 compliant UUID.
        /// </summary>
        [JsonProperty("agent_uuid")]
        public string AgentUuid { get; set; }
        /// <summary>
        /// First name of agent. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("agent_fname")] 
        public string AgentFname { get; set; }
        /// <summary>
        /// Last name of agent. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("agent_lname")]
        public string AgentLname { get; set; }
        /// <summary>
        /// The title of the presentation. This can be null if there is no data for this attribute.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; } 
        /// <summary>
        /// This is the Unix timestamp for the creation time of the presentation.
        /// </summary>
        [JsonProperty("created")]
        public int? Created { get; set; }  
        /// <summary>
        /// This is the Unix timestamp for the last time the presentation was edited.
        /// </summary>
        [JsonProperty("edited")]
        public int?  Edited { get; set; } 
        /// <summary>
        /// This is the ID of the office for the Agent associated with the presentation. This will be an integer.
        /// </summary>
        [JsonProperty("agent_office_id")]
        public string AgentOfficeId { get; set; }
        /// <summary>
        /// Whether the presentation is for a buyer or seller.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } 
        /// <summary>
        /// The UUID of the agent that sent the presentation to the client. This will be an RFC 4122 compliant UUID.
        /// </summary>
        [JsonProperty("sent_by_agent")]
        public string SentByAgent { get; set; }  
        /// <summary>
        /// The number of PDF documents requested.
        /// </summary>
        [JsonProperty("pdf_requested")]
        public int? PdfRequested { get; set; }   
        /// <summary>
        /// The number of Online presentations requested.
        /// </summary>
        [JsonProperty("pres_requested")]
        public int? PresRequested { get; set; }  
        /// <summary>
        /// This is the ID of the Agent utilized by their company.
        /// </summary>
        [JsonProperty("external_identifier")]
        public string ExternalIdentifier { get; set; }  
        /// <summary>
        /// This is the ID of the office for this Agent utilized by their company.
        /// </summary>
        [JsonProperty("external_office_id")]
        public string ExternalOfficeId { get; set; } 
        /// <summary>
        /// This is the ID of the office for this Agent utilized by their company.
        /// </summary>
        [JsonProperty("moxi_works_presentation_id")] 
        public string MoxiWorksPresentationId { get; set; }   
    }
}