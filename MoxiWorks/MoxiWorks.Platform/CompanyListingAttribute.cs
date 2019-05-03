namespace MoxiWorks.Platform
{
    /// <summary>
    /// Each object in the CompanyListingAttributes array will have the following structure.
    /// </summary>
    public class CompanyListingAttribute
    {
        /// <summary>
        /// Unique ID for the attribute.
        /// </summary>
        public string AttributeId { get; set; }
        /// <summary>
        /// Human readable name of the company specific listing attribute.
        /// </summary>
        public string AttributeName { get; set; }
    }
}
