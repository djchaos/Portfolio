using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowLeaderBoard : MonoBehaviour {

    private HttpHandler connexion;

    public Text text;
    int count = 10;

    void Start(){
        connexion = HttpHandler.Instance;
        WWWForm form = new WWWForm();
        //form.AddField("username",)
        connexion.HttpRequest(this, form, "http://localhost/api/leaderboard.php" + "?count=" + count + "&token=" + EventManager.token.Trim() , Show);

    }

    void Show(object leaderboard){
        text.text = (string)leaderboard;
        //Debug.Log(leaderboard);
        //Debug.Log("http://localhost/api/leaderboard.php" + "?count=" + count + "&token=" + EventManager.token);
    }

    public void Back(){

        SceneManager.LoadScene("Menu");
    }

}