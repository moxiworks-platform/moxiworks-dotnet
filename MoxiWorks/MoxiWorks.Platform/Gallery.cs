using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MoxiWorks.Platform
{
    
    public class Gallery
    {
        
        /// <summary>
        /// The MLS number for the listing. 
        /// </summary>
        public string ListingID { get; set; }
        
        /// <summary>
        /// The name of the MLS which this listing is listed with.
        /// </summary>
        public string ListOfficeAOR { get; set; }
        
        /// <summary>
        /// List of listing images
        /// </summary>
        public List<ListingImage> ListingImages { get; set; } = new List<ListingImage>();

    }
}