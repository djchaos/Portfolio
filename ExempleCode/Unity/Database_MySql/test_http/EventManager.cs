using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour {
    private HttpHandler connexion;

    public InputField username;
    public InputField password;
    public Text text;
    public bool connected = false;

    public static string token;

    public void Submit(){
        Debug.Log(username.text);
        Debug.Log(password.text);


        connexion = HttpHandler.Instance;
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", password.text);
        connexion.HttpRequest(this, form, "http://localhost/api/login.php", Show);
    }

    public void Show(object result){
        Debug.Log(result);
        if (result.ToString() == " Password or username not valid.")
        {
            text.text = (string)result;
        }
        else
        {
            token = (string)result;
            text.text = "you are connected";
            connected = true;
        }
        
    }

    public void Leaderboard(){
        if (connected == true)
        {
            SceneManager.LoadScene("LeaderBoard");
        }
        else
        {
            text.text = "you need to be connected";
        }
    }

    public void Exit(){
        Application.Quit();
    }

    public void Play(){
        if (connected == true)
        {
            SceneManager.LoadScene("Game");
        }
        else
        {
            text.text = "you need to be connected";
        }
    }
}
