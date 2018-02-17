using System.Threading.Tasks;
using MoxiWorks.Platform.Interfaces;

namespace MoxiWorks.Platform.Interfaces
{
    public interface IBrandService
    {
        IMoxiWorksClient Client { get; set; }

        /// <summary>
        /// Find compnay brand
        /// </summary>
        /// <param name="moxiWorksCompanyId">
        /// A valid Moxi Works Company ID. Use Company Endpoint to 
        /// determine what MoxiWorksCompanyID you can use.
        /// </param>
        /// <returns>the Brand if exists or an empty Brand Object </returns>
        Task<Response<Brand>> GetCompanyBrandAsync(string moxiWorksCompanyId);
    }
}