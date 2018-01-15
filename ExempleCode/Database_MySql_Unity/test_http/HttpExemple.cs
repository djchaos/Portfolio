using System.Collections;
using System.Collections.Generic;
using UnityEngine;


sealed class test {
    private string t;
}

public class HttpExemple : MonoBehaviour {
    private HttpHandler connexion;

    void Start () {
        connexion = HttpHandler.Instance;
        WWWForm form = new WWWForm();
        //form.AddField("username",)
        connexion.HttpRequest(this, form, "http://localhost/api/leaderboard.php", MyDebug);

    }

    void MyDebug(object result) {

        //string obj = JsonUtility.FromJson<string>((string)result); 
        //string json = JsonUtility.ToJson(obj);
        Debug.Log(result);
    }
}
