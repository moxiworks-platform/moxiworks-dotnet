using System;
using System.Collections.Generic;

using Newtonsoft.Json;
    namespace MoxiWorks.Platform
    {

        /// <summary>
        /// Entity representing buyer-side of transactions that agents are working on.
        /// </summary>
        public class BuyerTransaction
        {

            /// <summary>
            /// This is the Moxi Works Platform ID of the Agent which the 
            /// BuyerTransaction entry is associated with. 
            /// This will be an RFC 4122 compliant UUID. agent_uuid or MoxiWorksAgentId is 
            /// required and must reference a valid Moxi Works Agent ID for your BuyerTransaction 
            /// request to be accepted.
            /// </summary>
            [JsonProperty("agent_uuid")]
            public string AgentUuid { get; set; }
            /// <summary>
            /// This is the Moxi Works Platform ID of the Agent which this BuyerTransaction 
            /// object is to be associated with. This will be a string that may take the form 
            /// of an email address, or a unique identification string. agent_uuid or 
            /// MoxiWorksAgentId is required and must reference a valid Moxi Works 
            /// Agent ID for your BuyerTransaction request to be accepted.
            /// </summary>
            [JsonProperty("moxi_works_agent_id")]
            public string MoxiWorksAgentId { get; set; }
            /// <summary>
            /// This is the Moxi Works Platform ID of the Contact which this BuyerTransaction 
            /// object is to be associated with. This will be an RFC 4122 compliant UUID. 
            /// This data is required and must reference a valid Moxi Works Contact ID for your 
            /// BuyerTransaction Create request to be accepted. This is the same as the 
            /// MoxiWorksContactId attribute of the Contact response.
            /// </summary>
            [JsonProperty("moxi_works_contact_id")]    
            public string MoxiWorksContactId { get; set; }
            /// <summary>
            /// This is the Moxi Works Platform ID of the Contact which this BuyerTransaction 
            /// object is to be associated with. This will be an RFC 4122 compliant UUID. 
            /// This data is required and must reference a valid Moxi Works Contact ID 
            /// for your BuyerTransaction Create request to be accepted. 
            /// This is the same as the moxi_works_contact_id attribute of 
            /// the Contact response.
            /// </summary>
            [JsonProperty("moxi_works_transaction_id")]
            public string MoxiWorksTransactionId { get; set; }   
            /// <summary>
            /// This is the unique identifer you use in your system that has been associated 
            /// with the Contact that this BuyerTransaction regards. 
            /// If the referenced contact was not created by you, 
            /// then this should not be used, instead use moxi_works_contact_id.
            /// </summary>
            [JsonProperty("partner_contact_id")]    
            public string PartnerContactId { get; set; }
            /// <summary>
            /// A brief, human readable title that will be shown to the agent as the subject 
            /// of the BuyerTransaction that you are creating.
            /// </summary>
            [JsonProperty("transaction_name")]    
            public string TransactionName { get; set; } 
            /// <summary>
            /// Brief, human readable content that will be shown to the agent as notes about the BuyerTransaction that you are creating.
            /// </summary>
            [JsonProperty("notes")]    
            public string Notes { get; set; }
            /// <summary>
            /// The street address of the property being purchased. This should be populated 
            /// if this BuyerTransaction is_mls_transaction is false.
            /// </summary>
            [JsonProperty("address")]  
            public string Address { get; set; }
            /// <summary>
            /// The city or township of the property being purchased. This should be populated if 
            /// this BuyerTransaction is_mls_transaction is false.
            /// </summary>
            [JsonProperty("city")]  
            public string City { get; set; }
            /// <summary>
            /// The state or province of the property being purchased. This should be populated 
            /// if this BuyerTransaction is_mls_transaction is false.
            /// </summary>
            [JsonProperty("state")]  
            public string State { get; set; }
            /// <summary>
            /// The postal code of the property being purchased. This should be populated if 
            /// this BuyerTransaction is_mls_transaction is false.
            /// </summary>
            [JsonProperty("zip_code")]  
            public string ZipCode { get; set; }
            /// <summary>
            /// The minimum desired living area for prospective properties.
            /// </summary>
            [JsonProperty("min_sqft")]
            public int? MinSqft { get; set; } 
            /// <summary>
            /// The maximum desired living area for prospective properties.
            /// </summary>
            [JsonProperty("max_sqft")]
            public int? MiniSqft { get; set; }
            /// <summary>
            /// The minimum number of bedrooms for prospective properties.
            /// </summary>
            [JsonProperty("min_beds")]
            public decimal? MinBeds { get; set; }
            /// <summary>
            /// The maximum number of bedrooms for prospective properties.
            /// </summary>
            [JsonProperty("max_beds")]
            public decimal? MaxBeds { get; set; }
            /// <summary>
            /// The minimum number of bathrooms for prospective properties.
            /// </summary>
            [JsonProperty("min_baths")]
            public decimal? MinBaths { get; set; }
            /// <summary>
            /// The maximum number of bathrooms for prospective properties.
            /// </summary>
            [JsonProperty("max_baths")]
            public decimal? MaxBaths { get; set; }
            /// <summary>
            /// The name of a locality representing an area of interest for prospective properties.
            /// </summary>
            [JsonProperty("area_of_interest")]
            public string AreaOfInterest { get; set; }
            /// <summary>
            /// Whether the property being purchased is being listed on an MLS. 
            /// This should be false for paperwork-only, for sale by owner, off-market, 
            /// or pocket listing type transactions or any transactions that will not be tracked 
            /// through an MLS.
            /// </summary>
            [JsonProperty("is_mls_transaction")]
            public bool?  IsMlsTransaction  { get; set; }
            /// <summary>
            /// The MLS number of the the property being purchased.
            /// </summary>
            [JsonProperty("mls_number")]
            public string MlsNumber { get; set; }
            /// <summary>
            /// This is the Unix timestamp representing the date that the agent initiated 
            /// transaction discussions with the client.
            /// </summary>
            [JsonProperty("start_timestamp")]
            public int? StartTimeStamp { get; set; }
            /// <summary>
            /// Commission for the transaction. If the commission for the transaction is based on a percentage 
            /// of the purchase amount, use this attribute. If no commission 
            /// (either commission_percentage or commission_flat_fee) is supplied during creation, 
            /// commission_percentage is set to the default commission_percentage for the associated 
            /// </summary>
            [JsonProperty("commission_percentage")]
            public decimal? CommissionPercentage { get; set; }
            /// <summary>
            /// Commission for the transaction. If the commission for the transaction is based on a flat dollar amount, 
            /// use this attribute.
            /// </summary>
            [JsonProperty("commission_flat_fee")]
            public decimal? CommissionFlatFee { get; set; }
            /// <summary>
            /// The desired purchase price for a property if using target rather than range.
            /// 
            /// A BuyerTransaction can only have either CommissionPercentage or 
            /// CommissionFlatFee populated. Both can not be populated.
            /// </summary>
            [JsonProperty("target_price")]
            public decimal?  TargetPrice { get; set; }
            /// <summary>
            /// The minimum price range for a property if using a price range rather than target price.
            /// </summary>
            [JsonProperty("min_price")]
            public decimal? MinPrice { get; set; }
            /// <summary>
            /// The maximum price range for a property if using a price range rather than target price.
            /// </summary>
            [JsonProperty("max_price")]
            public decimal? MaxPrice { get; set; }

            /// <summary>
            /// List of erros found while trying to validate this object.
            /// </summary>
            [JsonIgnore]
            public List<string> Errors = new List<string>();
            
            /// <summary>
            /// Check if we have any errors.
            /// </summary>
            [JsonIgnore]
            public bool HasErrors => Errors.Count > 0;

            /// <summary>
            /// Validates the following:
            ///  
            /// Either MoxiWorksContactId or partner_contact_id must be populated; 
            /// however, you should only populate one of these attributes.
            /// 
            /// MlsNumber should be populated only if IsMlsTransaction is true.
            /// 
            /// A BuyerTransaction can only have either CommissionPercentage or CommissionFlatFee populated. 
            /// Both can not be populated.
            ///
            /// When setting a BuyerTransaction price, you can set either a target price or a price range, 
            /// but not both. If using target_price then min_price and max_price should not be populated. 
            /// If using either min_price or max_price, then target_price should not be populated.
            /// </summary>
            /// <returns>whether BuyerTransaction is valid</returns>
            public bool Validate()
            {
                Errors.Clear();
                
                if (! string.IsNullOrWhiteSpace(MoxiWorksContactId) && ! String.IsNullOrWhiteSpace(PartnerContactId))
                {
                    Errors.Add("Cannot Include both PartnereContactId and MoxiworksContactId");
                }

                if (IsMlsTransaction.HasValue && string.IsNullOrWhiteSpace(MlsNumber))
                {
                    Errors.Add("If IsMlsTransaction is true a Mls Number must be included");
                }

                if (CommissionPercentage > 0 && CommissionFlatFee > 0)
                {
                    Errors.Add("Can only include CommissionPercentage or CommissionFlatFee not both");
                }

                if (TargetPrice > 0 && (MaxPrice > 0 || MinPrice > 0))
                {
                    Errors.Add("Can only set TargePrice or MinPrice and MaxPrice");
                }

                return !(Errors.Count > 0);
            }

        }
    }