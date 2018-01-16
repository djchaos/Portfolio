using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private float score = 0;
	public Text Score;

	// Update is called once per frame
	void Update () 
	{
		score += Time.deltaTime;
		Score.text = "Current score = " + score.ToString ("f0"); 
	}
}
