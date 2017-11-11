using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Moxi Works Platform SellerTransaction entities represent seller-side transactions that agents are working on.
    /// </summary>
    public class SellerTransactionService : ISellerTransactionService
    {
        public IMoxiWorksClient Client { get; set; }

        public SellerTransactionService(IMoxiWorksClient client)
        {
            Client = client;
        }

        /// <summary>
        /// Create new SellerTransaction
        /// </summary>
        /// <param name="sellerTransaction">The SellerTransaction to be created.</param>
        /// <returns>Created SellerTransaction</returns>
        public async Task<Response<SellerTransaction>> CreateSellerTransactionAsync(SellerTransaction sellerTransaction)
        {
            sellerTransaction.Validate();

            if (sellerTransaction.HasErrors)
            {
                return BuilderErrorResponse(sellerTransaction);

            }
            var builder = new UriBuilder("seller_transactions");
            return await Client.PostRequestAsync(builder.GetUrl(), sellerTransaction);
        }

        /// <summary>
        /// Update existing Seller Transaction
        /// </summary>
        /// <param name="sellerTransaction">The Seller Transaction to be updated.</param>
        /// <returns>Updated SellerTransaction</returns>
        public async Task<Response<SellerTransaction>> UpdateSellerTransactionAsync(SellerTransaction sellerTransaction)
        {
            sellerTransaction.Validate();

            if (sellerTransaction.HasErrors)
            {
                return BuilderErrorResponse(sellerTransaction);

            }
            var builder =
                new UriBuilder(
                    $"seller_transactions/{sellerTransaction.MoxiWorksTransactionId}");
            return await Client.PutRequestAsync(builder.GetUrl(), sellerTransaction);
        }

        /// <summary>
        /// Requests a SellerTransaction
        /// </summary>
        /// <param name="agentId">
        /// Must include either:
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an SellerTransaction entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your SellerTransaction request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an SellerTransaction entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or moxi_works_agent_id is required 
        /// and must reference a valid Moxi Works Agent ID for your SellerTransaction request to be accepted.
        /// Agent ID for your Group request to be accepted.
        /// </param>
        /// <param name="agentIdType">What agentId type you are using.</param>
        /// <param name="moxiworksTransactionId">
        /// This is the Moxi Works Platform ID of the SellerTransaction which you have created. This will be an 
        /// RFC 4122 compliant UUID.This ID should be recorded on response as it is the key ID for updating the 
        /// SellerTransaction.
        /// </param>
        /// <returns>SellerTransaction or an empty SellerTransaction of no match is found</returns>
        public async Task<Response<SellerTransaction>> GetSellerTransactionAsync(string agentId, AgentIdType agentIdType,
            string moxiworksTransactionId)
        {
            var builder =
                new UriBuilder($"seller_transactions/{moxiworksTransactionId}")
            .AddQueryPerameterAgentId(agentId,agentIdType);

            return await Client.GetRequestAsync<SellerTransaction>(builder.GetUrl());
        }

        /// <summary>
        /// Request a list of seller transactions 
        /// </summary>
        /// <param name="agentId">
        /// Must include either:
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an SellerTransaction entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your SellerTransaction request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an SellerTransaction entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or moxi_works_agent_id is required 
        /// and must reference a valid Moxi Works Agent ID for your SellerTransaction request to be accepted.
        /// Agent ID for your Group request to be accepted.
        /// </param>
        /// <param name="agentIdType">What agentId type you are using.</param>
        /// <param name="moxiworksContactId">This is the Moxi Works Platform ID of the Contact which this 
        /// SellerTransaction has been associated with. This will be an RFC 4122 compliant UUID.
        /// </param>
        /// <param name="partnerContactId">
        /// If this Contact was created by your sytem in the Moxi Works Platform, then this is the unique identifer 
        /// you use in your system that has been associated with the Contact that you are creating this 
        /// SellerTransaction for. If the Contact was not created by you, then partner_contact_id will be empty.
        /// </param>
        /// <param name="pageNumber">Page of SellerTransaction records to return. Use if total_pages indicates 
        /// that there is more than one page of data available.</param>
        /// <returns>List of SellerTransactions</returns>
        public async Task<Response<SellerTransactionResults>> GetSellerTransactionsAsync(string agentId, AgentIdType agentIdType,
            string moxiworksContactId = null, string partnerContactId = null, int pageNumber = 1)
        {
            var builder = new UriBuilder("seller_transactions")
            .AddQueryPerameterAgentId(agentId,agentIdType)
            .AddQueryParameter("partner_contact_id", partnerContactId)
            .AddQueryParameter("moxi_works_contact_id", moxiworksContactId)
            .AddQueryParameter("page_number", pageNumber);

            return await Client.GetRequestAsync<SellerTransactionResults>(builder.GetUrl());
        }

        private Response<SellerTransaction> BuilderErrorResponse(SellerTransaction transaction)
        {
            var response = new Response<SellerTransaction>
            {
                Item = transaction
            };

            foreach (var error in transaction.Errors)
            {
                var e = new MoxiWorksError
                {
                    Status = "invalid",
                    ErrorCode = "0"
                };
                e.Messages.Add(error);
                response.Errors.Add(e);

            }
            return response; 
        }

    }
}
