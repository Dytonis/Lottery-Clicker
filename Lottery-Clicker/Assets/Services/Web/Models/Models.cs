using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Assets.Services.Web.Models
{
    public class WebBannerModel
    {
        public WebBannerMetaModel meta { get; set; }
        public List<WebBannerAdsModel> ads { get; set; }
        public WebBannerStatusModel status { get; set; }
    }

    public sealed class WebBannerMetaModel
    {
        public int totalResults { get; set; }
    }

    public sealed class WebBannerAdsModel
    {
        public string id { get; set; }
        public string type { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int length { get; set; }
        public string endDate { get; set; }
        public string assetType { get; set; }
        public string assetUrl { get; set; }
        public string mimeType { get; set; }
        public string clickThroughUrl { get; set; }
        public string callBackUrl { get; set; }
        public string completeClickThroughUrl { get; set; }
        public string completeCallBackUrl { get; set; }
        public string viewtag { get; set; }
        public string yaptag { get; set; }
        public string platform { get; set; }
    }

    public sealed class WebBannerStatusModel
    {
        public int code { get; set; }
        public string description { get; set; }
        public string userMessage { get; set; }
        public string logMessage { get; set; }
    }
}
