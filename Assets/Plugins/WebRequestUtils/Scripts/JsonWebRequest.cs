using System;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace WebRequestUtils
{
    // using JsonUtility
    public static class JsonRequest
    {
        public static UnityWebRequest Get(string url)
        {
            return UnityWebRequest.Get(url);
        }

        public static UnityWebRequest Get(Uri uri)
        {
            return UnityWebRequest.Get(uri);
        }

        public static UnityWebRequest Delete(string url)
        {
            return UnityWebRequest.Delete(url);
        }

        public static UnityWebRequest Delete(Uri uri)
        {
            return UnityWebRequest.Delete(uri);
        }

        public static UnityWebRequest Head(string url)
        {
            return UnityWebRequest.Head(url);
        }

        public static UnityWebRequest Head(Uri uri)
        {
            return UnityWebRequest.Head(uri);
        }
        
        public static UnityWebRequest Post<T>(string url, T value)
        {
            return RequestUpload(UnityWebRequest.kHttpVerbPOST, value)
                .SetUrl(url);
        }

        public static UnityWebRequest Post<T>(Uri uri, T value)
        {
            return RequestUpload( UnityWebRequest.kHttpVerbPOST, value)
                .SetUri(uri);
        }
        
        public static UnityWebRequest Put<T>(string url, T value)
        {
            return RequestUpload(UnityWebRequest.kHttpVerbPUT, value)
                .SetUrl(url);
        }

        public static UnityWebRequest Put<T>(Uri uri, T value)
        {
            return RequestUpload(UnityWebRequest.kHttpVerbPUT, value)
                .SetUri(uri);
        }

        private static UnityWebRequest RequestUpload<T>(string method, T value)
        {
            var json = JsonUtility.ToJson(value);
            var bytes = Encoding.UTF8.GetBytes(json);
            return new UnityWebRequest
            {
                method = method,
                downloadHandler = new DownloadHandlerBuffer(), 
                uploadHandler = new UploadHandlerRaw(bytes)
            }.SetContentTypeJsonHeader();
        }
    }
}