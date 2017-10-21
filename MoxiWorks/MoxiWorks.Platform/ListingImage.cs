
namespace MoxiWorks.Platform
{
    /// <summary>
    /// Meta data around an image for a listing property 
    /// </summary>
    public class ListingImage
    {
        /// <summary>
        /// This is a valid URL that can be used for img src to a thumbnail sized representation of the image. 
        /// This is the smallest size image returned in each object in the ListingImages array.
        /// </summary>
        public string ThumbURL { get; set; }
        /// <summary>
        /// This is a valid URL that can be used for img src to a small sized representation of the image. 
        /// This is the small size image returned in each object in the ListingImages array.
        /// </summary>
        public string SmallURL { get; set; }
        /// <summary>
        /// This is a valid URL that can be used for img src to a medium sized representation of the image. 
        /// This is the medium size image returned in each object in the ListingImages array.
        /// </summary>
        public string FullURL { get; set; }
        /// <summary>
        /// This is a valid URL that can be used for img src to a large sized representation of the image. 
        /// This is the large size image returned in each object in the ListingImages array.
        /// </summary>
        public string GalleryURL { get; set; }
        /// <summary>
        /// This is a valid URL to the raw image as uploaded. 
        /// This is the largest size image returned in each object in the ListingImages array. 
        /// Due to variation in size, this image should not be considered for use when displaying images rendered in a browser.
        /// </summary>
        public string RawURL { get; set; }
        /// <summary>
        /// Human readable title of image.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Whether this image is considered the primary image for the listing.
        /// </summary>
        public bool? IsMainListingImage { get; set; }
        /// <summary>
        /// Human readable caption for the image.
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// Human readable description of image.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Width of the raw image.
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// Height of the raw image.
        /// </summary>
        public int? Height { get; set; }
        /// <summary>
        /// MIME or media type of the image.
        /// </summary>
        public string MimeType { get; set; }
    }
}
