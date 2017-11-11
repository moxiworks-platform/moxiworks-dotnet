using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Moxi Works Platform BuyerTransaction entities represent buyer-side transactions that agents are working on.
    /// </summary>
    public class BuyerTransactionService : IBuyerTransactionService
    {
        public IMoxiWorksClient Client { get; set; }
        
        public BuyerTransactionService(IMoxiWorksClient client)
        {
            Client = client;
        }

        /// <summary>
        /// Create new BuyerTransaction
        /// </summary>
        /// <param name="buyerTransaction">BuyerTransaction you want to create.</param>
        /// <returns>The created BuyerTransaction</returns>
        public async Task<Response<BuyerTransaction>> CreateBuyerTransactionAsync(BuyerTransaction buyerTransaction)
        {
            var builder = new UriBuilder("buyer_transactions");
            
            return await Client.PostRequestAsync(builder.GetUrl(), buyerTransaction);
        }

        /// <summary>
        /// Update existing BuyerTransaction
        /// </summary>
        /// <param name="buyerTransaction">BuyerTransaction you want to update.</param>
        /// <returns></returns>
        public async Task<Response<BuyerTransaction>> UpdateBuyerTransactionAsync(BuyerTransaction buyerTransaction)
        {
            var builder =new UriBuilder($"buyer_transactions/{buyerTransaction.MoxiWorksTransactionId}");
            
            return await Client.PutRequestAsync(builder.GetUrl(), buyerTransaction);
        }
        
        /// <summary>
        /// Get a BuyerTransactoin
        /// </summary>
        /// <param name="agentId">
        /// Must include either:
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an Buyer Transaction entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your Buyer Transaction entry  request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an  Buyer Transaction  entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or moxi_works_agent_id is required 
        /// and must reference a valid Moxi Works Agent ID for your  Buyer Transaction  request to be accepted.
        /// Agent ID for your  Buyer Transaction  request to be accepted.
        /// </param>
        /// <param name="agentIdType">What agentId type you are using.</param>
        /// <param name="moxiworksTransactionId">
        /// This is the Moxi Works Platform ID of the BuyerTransaction. 
        /// This will be an RFC 4122 compliant UUID.
        /// </param>
        /// <returns>Response containing the expected BuyerTransaction of an empty transaction object </returns>
        public async Task<Response<BuyerTransaction>> GetBuyerTransactionAsync(string agentId, AgentIdType agentIdType,
            string moxiworksTransactionId)
        {
            var builder = new UriBuilder($"buyer_transactions/{moxiworksTransactionId}")
                .AddQueryPerameterAgentId(agentId,agentIdType);

            return await Client.GetRequestAsync<BuyerTransaction>(builder.GetUrl());
        }

        /// <summary>
        /// Get a a Collection of BuyerTransactions.
        /// </summary>
        /// <param name="agentId">
        /// Must include either:
        /// AgentUuid
        /// This is the Moxi Works Platform ID of the agent which an Buyer Transaction entry  entry is associated 
        /// with. This will be an RFC 4122 compliant UUID. 
        /// agent_uuid or moxi_works_agent_id is required and must reference a 
        /// valid Moxi Works Agent ID for your Buyer Transaction entry  request to be accepted.
        ///
        /// MoxiWorksAgentId
        /// This is the Moxi Works Platform ID of the agent which an Buyer Transaction entry  entry is associated 
        /// with. This will be a string that may take the form of an email address, 
        /// or a unique identification string. agent_uuid or moxi_works_agent_id is required 
        /// and must reference a valid Moxi Works Agent ID for your Buyer Transaction entry  request to be accepted.
        /// Agent ID for your Buyer Transaction entry  request to be accepted.
        /// </param>
        /// <param name="agentIdType">What agentId type you are using.</param>
        /// <param name="moxiworksContactId">
        /// This is the Moxi Works Platform ID of the Contact for which you are searching associated BuyerTransaction objects. 
        /// This will be an RFC 4122 compliant UUID. 
        /// You can use either MoxiworksContactId or partner_contact_id when searching for BuyerTransaction objects associated with a specific Contact.
        /// </param>
        /// <param name="partnerContactId">
        /// This is the unique identifer you use in your system that has been associated with the 
        /// Contact you want to find BuyerTransaction objects for. You can use either 
        /// MoxiworksContactId or PartnerContactId when searching for BuyerTransaction objects associated with a specific Contact.
        /// </param>
        /// <param name="pageNumber">
        /// Page of BuyerTransaction records to return. Use if TotalPages indicates that 
        /// there is more than one page of data available.
        /// </param>
        /// <returns>A Collection of Buyer Transactions.</returns>
        public async Task<Response<BuyerTransactionResults>> GetBuyerTransactionsAsync(string agentId, AgentIdType agentIdType,
            string moxiworksContactId = null, string partnerContactId = null, int pageNumber = 1)
        {
            var builder = new UriBuilder("buyer_transactions")
            .AddQueryPerameterAgentId(agentId,agentIdType)
            .AddQueryParameter("partner_contact_id", partnerContactId)
            .AddQueryParameter("moxi_works_contact_id", moxiworksContactId)
            .AddQueryParameter("page_number", pageNumber);

            return  await Client.GetRequestAsync<BuyerTransactionResults>(builder.GetUrl());
        }


    }
}
