using System.Threading.Tasks;
namespace MoxiWorks.Platform
{
    public class BuyerTransactionService : IBuyerTransactionService
    {
        public MoxiWorksClient Client { get; set; }
        public BuyerTransactionService(MoxiWorksClient client)
        {
            Client = client;
        }

        public async Task<Response<BuyerTransaction>> CreateBuyerTransactionAsync(BuyerTransaction buyerTransaction)
        {
            var builder = new UriBuilder("buyer_transactions");
            
            return await Client.PostRequestAsync(builder.GetUrl(), buyerTransaction);
        }

        public async Task<Response<BuyerTransaction>> UpdateBuyerTransactionAsync(BuyerTransaction buyerTransaction)
        {
            var builder =new UriBuilder($"buyer_transactions/{buyerTransaction.MoxiWorksTransactionId}");
            
            return await Client.PutRequestAsync(builder.GetUrl(), buyerTransaction);
        }

        public async Task<Response<BuyerTransaction>> GetBuyerTransactionAsync(string agentId, AgentIdType agentIdType,
            string moxiworksTransactionId)
        {
            var builder = new UriBuilder($"buyer_transactions/{moxiworksTransactionId}")
                .AddQueryPerameterAgentId(agentId,agentIdType);

            return await Client.GetRequestAsync<BuyerTransaction>(builder.GetUrl());
        }

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
