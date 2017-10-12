namespace MoxiWorks.Platform
{
    public class BuyerTransactionService : IBuyerTransactionService
    {
        public MoxiWorksClient Client { get; set; }
        public BuyerTransactionService(MoxiWorksClient client)
        {
            Client = client;
        }

        public Response<BuyerTransaction> CreateBuyerTransaction(BuyerTransaction buyerTransaction)
        {
            var builder = new UriBuilder("buyer_transactions");
            
            return Client.PostRequest(builder.GetUrl(), buyerTransaction);
        }

        public Response<BuyerTransaction> UpdateBuyerTransaction(BuyerTransaction buyerTransaction)
        {
            var builder =new UriBuilder($"buyer_transactions/{buyerTransaction.MoxiWorksTransactionId}");
            
            return Client.PutRequest(builder.GetUrl(), buyerTransaction);
        }

        public Response<BuyerTransaction> GetBuyerTransaction(string agentId, AgentIdType agentIdType,
            string moxiworksTransactionId)
        {
            var builder = new UriBuilder($"buyer_transactions/{moxiworksTransactionId}")
                .AddQueryPerameterAgentId(agentId,agentIdType);

            return Client.GetRequest<BuyerTransaction>(builder.GetUrl());
        }

        public Response<BuyerTransactionResults> GetBuyerTransactions(string agentId, AgentIdType agentIdType,
            string moxiworksContactId = null, string partnerContactId = null, int pageNumber = 1)
        {
            var builder = new UriBuilder("buyer_transactions")
            .AddQueryPerameterAgentId(agentId,agentIdType)
            .AddQueryParameter("partner_contact_id", partnerContactId)
            .AddQueryParameter("moxi_works_contact_id", moxiworksContactId)
            .AddQueryParameter("page_number", pageNumber);

            return Client.GetRequest<BuyerTransactionResults>(builder.GetUrl());
        }


    }
}
