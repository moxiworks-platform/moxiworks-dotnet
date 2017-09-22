using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Web.UI.WebControls;
using System.Xml.Xsl.Runtime;
using Newtonsoft.Json;
    namespace MoxiWorks.Platform
    {
        public class BuyerTransaction
        {

            [JsonProperty("agent_uuid")]
            public string AgentUUID { get; set; }
            [JsonProperty("moxi_works_agent_id")]
            public string MoxiWorksAgentId { get; set; }
            [JsonProperty("moxi_works_transaction_id")]
            public string MoxiWorksTransactionId { get; set; }   
            [JsonProperty("moxi_works_contact_id")]    
            public string MoxiWorksContactId { get; set; }
            [JsonProperty("partner_contact_id")]    
            public string PartnerContactId { get; set; }
            [JsonProperty("transaction_name")]    
            public string TransactionName { get; set; } 
            [JsonProperty("notes")]    
            public string Notes { get; set; }
            [JsonProperty("address")]  
            public string Address { get; set; }
            [JsonProperty("city")]  
            public string City { get; set; }
            [JsonProperty("state")]  
            public string State { get; set; }
            [JsonProperty("zip_code")]  
            public string ZipCode { get; set; }
            [JsonProperty("min_sqft")]
            public int MinSqft { get; set; } 
            [JsonProperty("max_sqft")]
            public int MiniSqft { get; set; }
            [JsonProperty("min_beds")]
            public int MinBeds { get; set; }
            [JsonProperty("max_beds")]
            public int MaxBeds { get; set; }
            [JsonProperty("min_baths")]
            public decimal MinBaths { get; set; }
            [JsonProperty("max_baths")]
            public decimal MaxBaths { get; set; }
            [JsonProperty("area_of_interest")]
            public string AreaOfInterest { get; set; }
            [JsonProperty("is_mls_transaction")]
            public bool  IsMlsTransaction  { get; set; }
            [JsonProperty("mls_number")]
            public string MlsNumber { get; set; }
            [JsonProperty("start_timestamp")]
            public int StartTimeStamp { get; set; }
            [JsonProperty("commission_percentage")]
            public decimal CommisionPercentage { get; set; }
            [JsonProperty("commission_flat_fee")]
            public decimal CommissionFlatFee { get; set; }
            [JsonProperty("target_price")]
            public int  TargetPrice { get; set; }
            [JsonProperty("min_price")]
            public int MinPrice { get; set; }
            [JsonProperty("max_price")]
            public int MaxPrice { get; set; }
            
            [JsonIgnore]
            public List<string> Errors = new List<string>();

            public bool Validate()
            {
                Errors.Clear();
                
                if (! String.IsNullOrWhiteSpace(MoxiWorksContactId) && ! String.IsNullOrWhiteSpace(PartnerContactId))
                {
                    Errors.Add("Cannot Include both PartnereContactId and MoxiworksContactId");
                }

                if (IsMlsTransaction && string.IsNullOrWhiteSpace(MlsNumber))
                {
                    Errors.Add("If IsMlsTransaction is true a Mls Number must be included");
                }

                if (CommisionPercentage > 0 && CommissionFlatFee > 0)
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