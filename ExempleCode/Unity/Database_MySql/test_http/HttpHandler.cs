using System.Collections;
using UnityEngine;
using System;

public class HttpHandler {
    private static HttpHandler instance;

    private HttpHandler() { }

    public static HttpHandler Instance {
        get {
            if( instance == null) {
                instance = new HttpHandler();
            }
            return instance;
        }
    }

    public float timeout = 2;

    public void HttpRequest(MonoBehaviour owner, WWWForm form, string url, Action<object> callback) {
        //form.AddField("key", "value");
        owner.StartCoroutine(Communicate(owner, form, url, callback));
        
    }

    private IEnumerator www(string url, WWWForm form) {
        WWW www = new WWW(url, form);
        float timeStamp = Time.time;
        string result = null;

        while (!www.isDone) {
            if (timeStamp + timeout <= Time.time) {
                result = "Fatal error: HttpRequest timeout";
                break;
            }
        }

        yield return null ?? www.text;
    }


    public IEnumerator Communicate(MonoBehaviour owner, WWWForm form, string url, Action<object> callback) {
        Corout connexion = new Corout(owner, www(url, form));
        yield return null;

        callback(connexion.result);
    }

}
