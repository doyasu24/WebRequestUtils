using System.Collections.Generic;
using UnityEngine.Networking;

namespace WebRequestUtils
{
    public static class SetCookieParser
    {
        // TODO
        // may not conform to Set-Cookie specification
        public static IEnumerable<KeyValuePair<string, string>> Parse(UnityWebRequest req)
        {
            // Case-insensitive api
            var setCookieHeaders = req.GetResponseHeader("Set-Cookie");
            if (string.IsNullOrEmpty(setCookieHeaders)) yield break;

            // UnityWebRequest concats Set-Cookie headers with comma.
            var setCookies = setCookieHeaders.Split(',');
            foreach (var setCookie in setCookies)
            {
                var c = setCookie.Split(';')[0];
                var kv = c.Split('=');
                yield return new KeyValuePair<string, string>(kv[0], kv[1]);
            }
        }
    }
}