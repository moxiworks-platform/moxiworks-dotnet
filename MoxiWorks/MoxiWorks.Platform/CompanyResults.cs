using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Collection of Companies returned by a company query.
    /// </summary>
    public class CompanyResults
    {
        /// <summary>
        /// List of Companies
        /// </summary>
        public List<Company> Companies { get; set; } = new List<Company>();

    }
}