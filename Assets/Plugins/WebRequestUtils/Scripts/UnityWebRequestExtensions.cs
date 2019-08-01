using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Networking;

namespace WebRequestUtils
{
    public static class UnityWebRequestExtensions
    {
        private const string CookieHeaderName = "Cookie";

        #region method chain

        public static UnityWebRequest SetUrl(this UnityWebRequest req, string url)
        {
            req.url = url;
            return req;
        }

        public static UnityWebRequest SetUri(this UnityWebRequest req, Uri uri)
        {
            req.uri = uri;
            return req;
        }

        public static UnityWebRequest SetHeader(this UnityWebRequest req, string name, string value)
        {
            req.SetRequestHeader(name, value);
            return req;
        }

        #endregion

        public static UnityWebRequest SetContentTypeJsonHeader(this UnityWebRequest req)
        {
            const string name = "Content-Type";
            const string value = "application/json";
            return req.SetHeader(name, value);
        }

        private static UnityWebRequest SetCookie(this UnityWebRequest req, string header)
        {
            return req.SetHeader(CookieHeaderName, header);
        }

        public static UnityWebRequest SetCookie(this UnityWebRequest req, string cookieName, string cookieValue)
        {
            var cookie = $"{cookieName}={cookieValue};";
            var previousCookie = req.GetRequestHeader(CookieHeaderName);
            cookie = string.IsNullOrEmpty(previousCookie) ? cookie : previousCookie + cookie;
            return req.SetCookie(cookie);
        }

        public static UnityWebRequest SetCookies(this UnityWebRequest req,
            IEnumerable<KeyValuePair<string, string>> cookies)
        {
            var sb = new StringBuilder();
            foreach (var kv in cookies)
            {
                var c = $"{kv.Key}={kv.Value};";
                sb.Append(c);
            }

            return req.SetCookie(sb.ToString());
        }

        public static bool IsSuccess(this UnityWebRequest req)
        {
            return req.isDone && !req.isHttpError && !req.isNetworkError;
        }
    }
}