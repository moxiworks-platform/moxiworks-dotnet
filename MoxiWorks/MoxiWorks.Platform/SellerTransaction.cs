using Newtonsoft.Json;
using System.Collections.Generic;
namespace MoxiWorks.Platform
{
    /// <summary>
    /// Entity representing seller-side of transactions that agents are working on.
    /// </summary>
    public class SellerTransaction
    {
        /// <summary>
        /// This is the Moxi Works Platform ID of the Agent which an SellerTransaction entry is associated with. This will be an RFC 4122 compliant UUID. 
        /// Agent_uuid or moxi_works_agent_id is required and must reference a valid Moxi Works Agent ID for your 
        /// SellerTransaction Create request to be accepted.
        /// </summary>
        [JsonProperty("agent_uuid")]
        public string AgentUuid { get; set; }
        /// <summary>
        /// This is the Moxi Works Platform ID of the Agent which this SellerTransaction object is to be associated with. 
        /// This will be a string that may take the form of an email address, or a unique identification string. 
        /// This data is required and must reference a valid Moxi Works Agent ID for your SellerTransaction Create request to be accepted.
        /// </summary>
        [JsonProperty("moxi_works_agent_id")]
        public string MoxiWorksAgentId { get; set; }
        /// <summary>
        /// This is the Moxi Works Platform ID of the SellerTransaction which you have created. This will be an RFC 4122 compliant UUID. 
        /// This ID should be recorded on response as it is the key ID for updating the SellerTransaction.
        /// </summary>
        [JsonProperty("moxi_works_transaction_id")]
        public string MoxiWorksTransactionId { get; set; }
        /// <summary>
        /// This is the Moxi Works Platform ID of the Contact which this SellerTransaction has been associated with. 
        /// This will be an RFC 4122 compliant UUID.
        /// </summary>
        [JsonProperty("moxi_works_contact_id")]    
        public string MoxiWorksContactId { get; set; }
        /// <summary>
        /// If this Contact was created by your sytem in the Moxi Works Platform, then this 
        /// is the unique identifer you use in your system that has been associated with the 
        /// Contact that you are creating this SellerTransaction for. 
        /// If the Contact was not created by you, then partner_contact_id will be empty.
        /// </summary>
        [JsonProperty("partner_contact_id")]    
        public string PartnerContactId { get; set; }
        /// <summary>
        /// A brief, human readable title that is shown to the agent as the subject of the SellerTransaction.
        /// </summary>
        [JsonProperty("transaction_name")]    
        public string TransactionName { get; set; }
        /// <summary>
        /// Brief, human readable content that is shown to the agent as notes about the SellerTransaction. 
        /// Use this attribute to store and display data to the agent that is not otherwise explicitly 
        /// available via attributes for the entity.
        /// </summary>
        [JsonProperty("notes")]    
        public string Notes { get; set; }
        /// <summary>
        /// The street address for the property being sold. This should be null if the SellerTransaction is an MLS sale.
        /// </summary>
        [JsonProperty("address")]  
        public string Address { get; set; }
        /// <summary>
        /// The city or township of the property being sold. This should be null if the SellerTransaction is an MLS sale.
        /// </summary>
        [JsonProperty("city")]  
        public string City { get; set; }
        /// <summary>
        /// The state or province of the property being sold. This should be null if the SellerTransaction is an MLS sale.
        /// </summary>
        [JsonProperty("state")]  
        public string State { get; set; }
        /// <summary>
        /// The postal code of the property being sold. This should be null if the SellerTransaction is an MLS sale.
        /// </summary>
        [JsonProperty("zip_code")]  
        public string ZipCode { get; set; }
        /// <summary>
        /// The living area of the property being sold.
        /// </summary>
        [JsonProperty("sqft")]
        public int? SQFT { get; set; }
        /// <summary>
        /// The number of bedroom in the property being sold.
        /// </summary>
        [JsonProperty("beds")]
        public decimal? Beds { get; set; }
        /// <summary>
        /// The number of bathrooms in the property being sold.
        /// </summary>
        [JsonProperty("baths")]
        public decimal? Baths { get; set; }
        /// <summary>
        /// Whether the property being sold is being listed on an MLS.
        /// </summary>
        [JsonProperty("is_mls_transaction")]
        public bool?  IsMlsTransaction  { get; set; }
        /// <summary>
        /// If this is an MLS sale, then this is the MLS number for the SellerTransaction.
        /// </summary>
        [JsonProperty("mls_number")]
        public string MlsNumber { get; set; }
        /// <summary>
        /// For non-MLS transactions, this is the Unix timestamp representing the date that the agent 
        /// initiated transaction discussions with the client. 
        /// This should be null if the SellerTransaction is an MLS sale.
        /// </summary>
        [JsonProperty("start_timestamp")]
        public int? StartTimeStamp { get; set; }
        /// <summary>
        /// If the agent is to receive commission based on percentage of sale price for the property associated with this SellerTransaction, 
        /// then this will represent the commission that the agent is to receive.This should be null if the SellerTransaction uses commission_flat_fee.
        /// </summary>
        [JsonProperty("commission_percentage")]
        public decimal? CommissionPercentage { get; set; }
        /// <summary>
        /// If the agent is to receive a flat-rate commission upon sale of the property associated with this SellerTransaction, 
        /// then this will represent the commission that the agent is to receive. 
        /// This should be null if the SellerTransaction uses commission_percentage.
        /// </summary>
        [JsonProperty("commission_flat_fee")]
        public decimal? CommissionFlatFee { get; set; }
        /// <summary>
        /// The desired selling price for the property if using target rather than range.
        /// </summary>
        [JsonProperty("target_price")]
        public decimal?  TargetPrice { get; set; }
        /// <summary>
        /// The minimum price range for the property if using a price range rather than target price.
        /// </summary>
        [JsonProperty("min_price")]
        public decimal? MinPrice { get; set; }
        /// <summary>
        /// The maximum price range for the property if using a price range rather than target price.
        /// </summary>
        [JsonProperty("max_price")]
        public decimal? MaxPrice { get; set; }
        
        
        [JsonIgnore]
        public List<string> Errors = new List<string>();
        [JsonIgnore]
        public  bool HasErrors => Errors.Count > 0;


        public bool Validate()
        {
            Errors.Clear();

            if (!string.IsNullOrWhiteSpace(MoxiWorksContactId) && !string.IsNullOrWhiteSpace(PartnerContactId))
            {
                Errors.Add("Cannot Include both PartnereContactId and MoxiworksContactId");
            }

            if (IsMlsTransaction.HasValue && string.IsNullOrWhiteSpace(MlsNumber))
            {
                Errors.Add("If IsMlsTransaction is true a Mls Number must be included");
            }

            if (CommissionPercentage > 0 && CommissionFlatFee > 0)
            {
                Errors.Add("Can only include CommisionPercentage or CommissionFlatFee not both");
            }

            if (TargetPrice > 0 && (MaxPrice > 0 || MinPrice > 0))
            {
                Errors.Add("Can only set TargePrice or MinPrice and MaxPrice");
            }

            return !(Errors.Count > 0);
        }

    
    }
}