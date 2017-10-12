namespace MoxiWorks.Platform
{
    public class SellerTransactionService 
    {
        public MoxiWorksClient Client { get; set; }

        public SellerTransactionService(MoxiWorksClient client)
        {
            Client = client;
        }

        public Response<SellerTransaction> CreateSellerTransaction(SellerTransaction sellerTransaction)
        {
            sellerTransaction.Validate();

            if (sellerTransaction.HasErrors)
            {
                return BuilderErrorResponse(sellerTransaction);

            }
            var builder = new UriBuilder("seller_transactions");
            return Client.PostRequest(builder.GetUrl(), sellerTransaction);
        }

        public Response<SellerTransaction> UpdateSellerTransaction(SellerTransaction sellerTransaction)
        {
            sellerTransaction.Validate();

            if (sellerTransaction.HasErrors)
            {
                return BuilderErrorResponse(sellerTransaction);

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
                new UriBuilder($"seller_transactions/{moxiworksTransactionId}")
            .AddQueryPerameterAgentId(agentId,agentIdType);

            return Client.GetRequest<SellerTransaction>(builder.GetUrl());
        }

        public Response<SellerTransactionResults> GetSellerTransactions(string agentId, AgentIdType agentIdType,
            string moxiworksContactId = null, string partnerContactId = null, int pageNumber = 1)
        {
            var builder = new UriBuilder("seller_transactions")
            .AddQueryPerameterAgentId(agentId,agentIdType)
            .AddQueryParameter("partner_contact_id", partnerContactId)
            .AddQueryParameter("moxi_works_contact_id", moxiworksContactId)
            .AddQueryParameter("page_number", pageNumber);

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
