using System.Collections.Generic;

namespace MoxiWorks.Platform
{
    /// <summary>
    /// Collection of Brands dates returned by a brand query.
    /// </summary>
    public class BrandResults
    {
        /// <summary>
        /// List of Brands
        /// </summary>
        public List<Brand> Brands { get; set; } = new List<Brand>();

    }
}