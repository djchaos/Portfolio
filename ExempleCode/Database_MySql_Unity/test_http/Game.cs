using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {

    private HttpHandler connexion;
    public Text text;
    int point = 0;

    private void Update(){
        text.text = "Score:" + point;
    }

    public void MakePoint() {
        point++;
    }

    public void SubmitScore() {

        connexion = HttpHandler.Instance;
        WWWForm form = new WWWForm();
        form.AddField("score", point);
        form.AddField("token", EventManager.token.Trim());
        connexion.HttpRequest(this, form, "http://localhost/api/score_update.php", Debugge );
    }

    void Debugge(object result){

        Debug.Log(result);

    }

    public void Back(){

        SceneManager.LoadScene("Menu");
    }
    
}
