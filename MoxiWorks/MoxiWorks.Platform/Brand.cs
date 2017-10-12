using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    public class Brand 
    {
        [JsonProperty("image_logo")]
        public string ImageLogo { get; set; }
        [JsonProperty("cma_authoring_color")]
        public string CmaAuthoringColor { get; set; }
        [JsonProperty("background_color")]  
        public string BackGroundColor { get; set; }
        [JsonProperty("background_font_color_primary")]
        public string BackGroundFontColorPrimary { get; set; } 
        [JsonProperty("button_background_color")]  
        public string ButtonGroundFontColorPrimary { get; set; }
        [JsonProperty("button_font_color")]  
        public string ButtonFontColor { get; set; }
        [JsonProperty("copyright")] 
        public string CopyRight { get; set; }
        [JsonProperty("display_name")]  
        public string DisplayName { get; set; }
        [JsonProperty("email_element_background_color")]
        public string EmailElementBackGroundColor { get; set; }
        [JsonProperty("email_background_font_color")]  
        public string EmailBackGroundFontColor { get; set; }
        [JsonProperty("image_cma_pdf_logo_header")]  
        public string ImageCmaPdfLogoHeader { get; set; }
        [JsonProperty("image_email_logo_alt")]
        public string ImageEmailLogoAlt { get; set; }
        [JsonProperty("image_favicon")]  
        public string ImageFavicon { get; set; }
        [JsonProperty("image_pres_cover_logo")]
        public string ImagePresCoverLogo { get; set; }
        [JsonProperty("pres_block_background_color")]
        public string PresBlockBackgroundColor { get; set; }
        [JsonProperty("pres_block_text_color")]  
        public string PresBlockTextColor { get; set; }
    }
}