using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace WebRequestUtils.Samples
{
    public class Sample : MonoBehaviour
    {
        private const string Host = "https://jsonplaceholder.typicode.com";
        
        private IEnumerator Start()
        {
            var getRequest = JsonRequest.Get($"{Host}/todos/1");
            yield return SendWithLog(getRequest);

            var postRequest = JsonRequest.Post($"{Host}/todos", Vector2.zero);
            yield return SendWithLog(postRequest);
            
            var putRequest = JsonRequest.Put($"{Host}/todos/1", Vector2.zero);
            yield return SendWithLog(putRequest);
            
            var deleteRequest = JsonRequest.Delete($"{Host}/todos/1");
            yield return SendWithLog(deleteRequest);
        }

        private static IEnumerator SendWithLog(UnityWebRequest req)
        {
            yield return req.SendWebRequest();
            if (!req.IsSuccess())
            {
                Debug.LogError(req.error);
                yield break;
            }

            if (req.downloadHandler != null)
            {
                Debug.Log(req.downloadHandler.text);
            }
            else
            {
                Debug.Log("Done.");
            }
        }
    }
}