using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Services.Web
{
    public class WebService
    {
        public WebBanner NewBanner(GameObject bannerObj = null)
        {
            Debug.Log("NewBanner");

            WebBanner banner = new WebBanner();

            if (bannerObj != null)
                banner.BannerObj = bannerObj;

            Debug.Log("Calling API...");

            string ApiJson = new WebClient().DownloadString(Core.Config.BannerDomain);

            Debug.Log("Recieved API: " + ApiJson);

            banner.Model = JsonConvert.DeserializeObject<Models.WebBannerModel>(ApiJson);

            Debug.Log("Deserialize");

            return banner;
        }

        public IEnumerator ParseURLToImage(string URL, WebBanner banner)
        {
            WWW w = new WWW(URL);
            yield return w;
            banner.BannerObj.GetComponent<RawImage>().texture = w.texture;
        }
    }

    public class WebBanner
    {
        public Models.WebBannerModel Model;
        public GameObject BannerObj;

        public GameObject Init()
        {
            BannerObj = GameObject.Instantiate(Core.Config.BannerPrefab) as GameObject;
            Debug.Log("BannerObj: " + BannerObj);
            Debug.Log("Tex:" + BannerObj.GetComponent<RawImage>().texture);
            Debug.Log(Model.ads[0].height);
            BannerObj.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            BannerObj.transform.localScale = new Vector3(1f, 1f, 1f);
            float frameHeight = GameObject.FindGameObjectWithTag("Canvas").transform.GetComponent<RectTransform>().rect.height;
            float frameWidth = GameObject.FindGameObjectWithTag("Canvas").transform.GetComponent<RectTransform>().rect.width;
            float yPos = ((frameWidth / 6.4f) - ((frameWidth / 6.4f) * .5f)) - (frameHeight / 2);
            BannerObj.transform.localPosition = new Vector3(0f, yPos, 0f);
            BannerObj.GetComponent<BannerObject>().RedirectTo = Model.ads[0].clickThroughUrl;
            BannerObj.GetComponent<BannerObject>().ImageURL = Model.ads[0].assetUrl;
            BannerObj.GetComponent<RectTransform>().sizeDelta = new Vector2(frameWidth, frameWidth / 6.4f);

            return BannerObj; //reference pass
        }

        public void Reasign()
        {
            BannerObj.GetComponent<BannerObject>().ImageURL = Model.ads[0].assetUrl;
            BannerObj.GetComponent<BannerObject>().RedirectTo = Model.ads[0].clickThroughUrl;
        }
    }
}
