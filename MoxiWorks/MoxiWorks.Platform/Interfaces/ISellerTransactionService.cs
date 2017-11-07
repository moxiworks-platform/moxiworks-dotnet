using System.Threading.Tasks;

namespace MoxiWorks.Platform.Interfaces
{
    /// <summary>
    /// Wrapper around the service to allow stubbing of the service.
    /// </summary>
    public interface ISellerTransactionService
    {
        MoxiWorksClient Client { get; set; }
        Task<Response<SellerTransaction>> CreateSellerTransactionAsync(SellerTransaction sellerTransaction);
        Task<Response<SellerTransaction>> UpdateSellerTransactionAsync(SellerTransaction sellerTransaction);

        Task<Response<SellerTransaction>> GetSellerTransactionAsync(string agentId, AgentIdType agentIdType,
            string moxiworksTransactionId);

        Task<Response<SellerTransactionResults>> GetSellerTransactionsAsync(string agentId, AgentIdType agentIdType,
            string moxiworksContactId = null, string partnerContactId = null, int pageNumber = 1);
    }
}