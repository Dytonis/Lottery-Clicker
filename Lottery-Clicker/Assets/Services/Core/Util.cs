using UnityEngine;
using System.Collections;
using System;

namespace Assets.Services.Core
{
    /// <summary>
    /// Static class for extensions
    /// </summary>
    public static class Util
    {
        public static IEnumerator InvokeMethod(Action method, float interval, int? invokeCount = null)
        {
            if (invokeCount != null)
            {
                for (int i = 0; i < invokeCount; i++)
                {
                    method();

                    yield return new WaitForSeconds(interval);
                }
            }
            else
            {
                while(true)
                {
                    yield return new WaitForSeconds(interval);
                    method();                  
                }
            }
        }
    }
}
