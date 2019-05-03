using System.Collections.Generic;

namespace MoxiWorks.Platform
{   
    /// <summary>
    /// Collection of features of a listing
    /// </summary>
    public class PropertyFeatures
    {
        /// <summary>
        /// Human readable name associated with the feature.
        /// </summary>
        public string PropertyFeatureName { get; set; }
        /// <summary>
        /// An array of strings which are human readable values associated with the feature.
        /// </summary>
        public List<string> PropertyFeatureValues { get; set; }
    }
}
