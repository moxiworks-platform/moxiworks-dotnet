using Newtonsoft.Json;
namespace MoxiWorks.Platform
{
    public class Brand 
    {
        /// <summary>
        /// Company Logo
        /// </summary>
        [JsonProperty("image_logo")]
        public string ImageLogo { get; set; }
        /// <summary>
        /// Presentation accent color
        /// </summary>
        [JsonProperty("cma_authoring_color")]
        public string CmaAuthoringColor { get; set; }
        /// <summary>
        /// Back ground color
        /// </summary>
        [JsonProperty("background_color")]  
        public string BackGroundColor { get; set; }
        /// <summary>
        /// font color intended to overlay background_color
        /// </summary>
        [JsonProperty("background_font_color_primary")]
        public string BackGroundFontColorPrimary { get; set; } 
        /// <summary>
        /// background color of buttons
        /// </summary>
        [JsonProperty("button_background_color")]  
        public string ButtonGroundFontColorPrimary { get; set; }
        /// <summary>
        /// font color intended to overlay BackGroundColor
        /// </summary>
        [JsonProperty("button_font_color")]  
        public string ButtonFontColor { get; set; }
        /// <summary>
        /// copyright notice – this may contain embedded HTML
        /// </summary>
        [JsonProperty("copyright")] 
        public string CopyRight { get; set; }
        /// <summary>
        /// name of company as displayed to consumer
        /// </summary>
        [JsonProperty("display_name")]  
        public string DisplayName { get; set; }
        /// <summary>
        /// background color of email elements outside body
        /// </summary>
        [JsonProperty("email_element_background_color")]
        public string EmailElementBackGroundColor { get; set; }
        /// <summary>
        /// font color intended to overlay EmailBackGroundColor
        /// </summary>
        [JsonProperty("email_background_font_color")]  
        public string EmailBackGroundFontColor { get; set; }
        /// <summary>
        /// company logo shown in pdf version of presentations
        /// </summary>
        [JsonProperty("image_cma_pdf_logo_header")]  
        public string ImageCmaPdfLogoHeader { get; set; }
        /// <summary>
        /// company logo as shown in email header
        /// </summary>
        [JsonProperty("image_email_logo_alt")]
        public string ImageEmailLogoAlt { get; set; }
        /// <summary>
        /// favicon of company
        /// </summary>
        [JsonProperty("image_favicon")]  
        public string ImageFavicon { get; set; }
        /// <summary>
        /// company logo shown in the online version of presentations
        /// </summary>
        [JsonProperty("image_pres_cover_logo")]
        public string ImagePresCoverLogo { get; set; }
        /// <summary>
        /// block element background color shown in online version of presentations
        /// </summary>
        [JsonProperty("pres_block_background_color")]
        public string PresBlockBackgroundColor { get; set; }
        /// <summary>
        /// font color intended to overlay PresBlockBackgroundColor
        /// </summary>
        [JsonProperty("pres_block_text_color")]  
        public string PresBlockTextColor { get; set; }
    }
}