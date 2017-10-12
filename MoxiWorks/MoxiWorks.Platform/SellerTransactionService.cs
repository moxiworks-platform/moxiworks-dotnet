namespace MoxiWorks.Platform
{
    public class SellerTransactionService
    {
        public MoxiWorksClient Client { get; set; }

        public SellerTransactionService(MoxiWorksClient client)
        {
            Client = client;
        }

        public Response<BuyerTransaction> CreateSellerTransaction(BuyerTransaction buyerTransaction)
        {
            var builder = new UriBuilder("seller_transactions");
            return Client.PostRequest(builder.GetUrl(), buyerTransaction);
        }

        public Response<SellerTransaction> UpdateSellerTransaction(SellerTransaction sellerTransaction)
        {
            sellerTransaction.Validate();

            if (sellerTransaction.HasErrors)
            {
                

            }
            var builder =
                new UriBuilder(
                    $"seller_transactions/{sellerTransaction.MoxiWorksTransactionId}");
            return Client.PutRequest(builder.GetUrl(), sellerTransaction);
        }

        public Response<SellerTransaction> GetSellerTransaction(string agentId, AgentIdType agentIdType,
            string moxiworksTransactionId)
        {
            var builder =
                new UriBuilder($"seller_transactions/{moxiworksTransactionId}");
            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            return Client.GetRequest<SellerTransaction>(builder.GetUrl());
        }

        public Response<SellerTransactionResults> GetSellerTransactions(string agentId, AgentIdType agentIdType,
            string moxiworksContactId = null, string partnerContactId = null, int pageNumber = 1)
        {
            var builder = new UriBuilder("seller_transactions");

            builder.AddQueryParameter(agentIdType == AgentIdType.AgentUuid ? "agent_uuid" : "moxi_works_agent_id",
                agentId);

            builder.AddQueryParameter("partner_contact_id", partnerContactId);
            builder.AddQueryParameter("moxi_works_contact_id", moxiworksContactId);
            builder.AddQueryParameter("page_number", pageNumber);

            return Client.GetRequest<SellerTransactionResults>(builder.GetUrl());
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
