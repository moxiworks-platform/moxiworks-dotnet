namespace MoxiWorks.Platform
{
    public interface IBuyerTransactionService
    {
        MoxiWorksClient Client { get; set; }
        Response<BuyerTransaction> CreateBuyerTransaction(BuyerTransaction buyerTransaction);
        Response<BuyerTransaction> UpdateBuyerTransaction(BuyerTransaction buyerTransaction);

        Response<BuyerTransaction> GetBuyerTransaction(string agentId, AgentIdType agentIdType,
            string moxiworksTransactionId);

        Response<BuyerTransactionResults> GetBuyerTransactions(string agentId, AgentIdType agentIdType,
            string moxiworksContactId = null, string partnerContactId = null, int pageNumber = 1);
    }
}