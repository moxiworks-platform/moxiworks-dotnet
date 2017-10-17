using System.Threading.Tasks;

namespace MoxiWorks.Platform
{
    public class SellerTransactionService : ISellerTransactionService
    {
        public MoxiWorksClient Client { get; set; }

        public SellerTransactionService(MoxiWorksClient client)
        {
            Client = client;
        }

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

        public async Task<Response<SellerTransaction>> GetSellerTransactionAsync(string agentId, AgentIdType agentIdType,
            string moxiworksTransactionId)
        {
            var builder =
                new UriBuilder($"seller_transactions/{moxiworksTransactionId}")
            .AddQueryPerameterAgentId(agentId,agentIdType);

            return await Client.GetRequestAsync<SellerTransaction>(builder.GetUrl());
        }

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
