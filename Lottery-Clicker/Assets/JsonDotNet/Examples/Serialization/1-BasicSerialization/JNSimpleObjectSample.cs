//### Sample objects are in the 999-ExampleModels/JNExampleModels.cs
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using DustinHorne.Json.Examples;

namespace Assets
{
    /// <summary>
    /// Example of serializing and deserializing a simple object
    /// </summary>
    public class JNSimpleObjectSample
    {
        public void Sample()
        {
            //Create an object to serialize
            var original = new JNSimpleObjectModel
                {
                    IntValue = 5,
                    FloatValue = 4.98f,
                    StringValue = "Simple Object",
                    ObjList = new List<object> { 4, 7, 25, 34, "asdf" },
                    ObjectType = JNObjectType.BaseClass,
                    WebModel = new Services.Web.Models.WebBannerModel
                    {
                        ads = new List<Services.Web.Models.WebBannerAdsModel>()
                        {
                            new Services.Web.Models.WebBannerAdsModel()
                            {
                                width = 100
                            }
                        }
                    }
                };

            //This string is the JSON representation of the object
            string serialized = JsonConvert.SerializeObject(original);

            //Now we can deserialize this string back into an object
            var newobject = JsonConvert.DeserializeObject<JNSimpleObjectModel>(serialized);

            Debug.Log(newobject.IntList.Count);
        }
    }
}




