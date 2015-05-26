using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Services.Web
{
    public class BannerObject : MonoBehaviour
    {
        public string ImageURL;
        public string RedirectTo;

        public void Click()
        {
            if(RedirectTo.Trim() != null && RedirectTo.Trim() != String.Empty)
                Application.OpenURL(RedirectTo);
            
            //TODO: GA hook here
            //
        }
    }
}
