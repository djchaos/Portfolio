using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DebugHelper : MonoBehaviour
{
    public Text PlayerPos;
    //public Text PlayerSpeed;
    GameObject Player;

    public bool show;

    void Start ()
    {
        Player = GameObject.Find("Player");
    }
	
	void Update ()
    {
        if (show)
        {
            getPlayerPos();
        }
        else
        {
            PlayerPos.text = null;
        }
    }

    void getPlayerPos()
    {
        PlayerPos.text = "Pos:" +Player.transform.position.ToString();
    }

    public void ShowOrNot()
    {
        show = !show;
    }
}
