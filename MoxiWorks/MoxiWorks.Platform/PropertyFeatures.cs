using System.Collections.Generic;

namespace MoxiWorks.Platform
{   
    /// <summary>
    /// Collection of features of a listing
    /// </summary>
    public class PropertyFeatures
    {
        public string PropertyFeatureName { get; set; } 
        public List<string> PropertyFeatureValues { get; set; }
    }
}
