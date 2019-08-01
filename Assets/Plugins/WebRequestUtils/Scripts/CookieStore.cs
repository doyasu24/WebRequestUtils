using System.Collections.Generic;
using UnityEngine.Networking;

namespace WebRequestUtils
{
    public class CookieStore
    {
        private readonly Dictionary<string, string> _cookieDic = new Dictionary<string, string>();

        public IReadOnlyDictionary<string, string> Dic => _cookieDic;

        public CookieStore()
        {
        }

        public CookieStore(IEnumerable<KeyValuePair<string, string>> keyValues)
        {
            foreach (var kv in keyValues)
            {
                _cookieDic[kv.Key] = kv.Value;
            }
        }

        public void SetUpCookie(UnityWebRequest req)
        {
            req.SetCookies(_cookieDic);
        }

        public void Reserve(UnityWebRequest req)
        {
            if (!req.IsSuccess())
            {
                return;
            }

            foreach (var kv in SetCookieParser.Parse(req))
            {
                _cookieDic[kv.Key] = kv.Value;
            }
        }
    }
}