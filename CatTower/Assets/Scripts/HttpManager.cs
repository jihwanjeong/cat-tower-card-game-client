using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

namespace CatTower
{

    public class HttpManager : MonoBehaviour
    {
        // TODO: 싱글턴 코드 변경
        private HttpManager() { }
        private HttpManager instance;
        public HttpManager Instance
        {
            get
            {
                if (instance == null) instance = new HttpManager();
                return instance;
            }
        }
         public void Get<TResponse>(string url, Action<TResponse> responseHandler)
        {
            StartCoroutine(CoroutineGet<TResponse>(url, responseHandler));
        }

        public void Post<TRequest, TResponse>(string url, TRequest request, Action<TResponse> responseHandler)
        {
            StartCoroutine(CoroutinePost<TRequest, TResponse>(url, request, responseHandler));
        }

        private IEnumerator CoroutineGet<TResponse>(string url, Action<TResponse> responseHandler)
        {
            
            UnityWebRequest webRequest = new UnityWebRequest();
            webRequest.url = url;
            webRequest.method = UnityWebRequest.kHttpVerbGET;
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log("network error");
                yield break;
            }
            if (webRequest.responseCode != 200)
            {
                Debug.Log("responseCode not 200");
                yield break;
            }
            var responseBody = webRequest.downloadHandler.text;
            if (responseHandler != null) responseHandler(JsonUtility.FromJson<TResponse>(responseBody));
            yield return null;
        }
        
        private IEnumerator CoroutinePost<TRequest, TResponse>(string url, TRequest request, Action<TResponse> responseHandler)
        {
            var json = JsonUtility.ToJson(request);
            UnityWebRequest webRequest = new UnityWebRequest();
            webRequest.url = url;
            webRequest.method = UnityWebRequest.kHttpVerbPOST;
            webRequest.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));
            webRequest.uploadHandler.contentType = "application/json";
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log("network error");
                yield break;
            }
            if (webRequest.responseCode != 200)
            {
                Debug.Log("responseCode not 200");
                yield break;
            }
            var responseBody = webRequest.downloadHandler.text;
            if (responseHandler != null) responseHandler(JsonUtility.FromJson<TResponse>(responseBody));
            yield return null;
        }
    }
}