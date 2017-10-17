using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    public interface IBuyerTransactionService
    {
        MoxiWorksClient Client { get; set; }
        Task<Response<BuyerTransaction>> CreateBuyerTransactionAsync(BuyerTransaction buyerTransaction);
        Task<Response<BuyerTransaction>> UpdateBuyerTransactionAsync(BuyerTransaction buyerTransaction);

        Task<Response<BuyerTransaction>> GetBuyerTransactionAsync(string agentId, AgentIdType agentIdType,
            string moxiworksTransactionId);

        Task<Response<BuyerTransactionResults>> GetBuyerTransactionsAsync(string agentId, AgentIdType agentIdType,
            string moxiworksContactId = null, string partnerContactId = null, int pageNumber = 1);
    }
}