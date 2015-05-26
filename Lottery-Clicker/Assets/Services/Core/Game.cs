using UnityEngine;
using System.Collections;
using System.Threading;

namespace Assets.Services.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        public GameObject BannerPrefab;
        public GameObject BannerReal;

        private Assets.Services.Web.WebService wservice;
        private Assets.Services.Web.WebBanner wbanner;

        void Start()
        {
            Config.BannerPrefab = BannerPrefab;
            StartCoroutine(Init());
        }

        public IEnumerator Init()
        {
            Debug.Log("Thread Fire");
            wservice = new Web.WebService();
            wbanner = wservice.NewBanner(BannerReal);
            StartCoroutine(wservice.ParseURLToImage(wbanner.Model.ads[0].assetUrl, wbanner));

            BannerReal = wbanner.Init();

            StartCoroutine(Util.InvokeMethod(ResetBanner, 10f));

            yield return wservice;
        }

        public void ResetBanner()
        {
            wbanner = wservice.NewBanner(BannerReal);
            StartCoroutine(wservice.ParseURLToImage(wbanner.Model.ads[0].assetUrl, wbanner));
            wbanner.Reasign();
        }
    }
}
