using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrefabBeta : MonoBehaviour
{
	private List<Transform> randomList =  new List<Transform>();
	// Use this for initialization
	void Start () 
	{
		foreach (Transform t in transform)
			randomList.Add (t);
		
		int ammPlatform = Random.Range(1,5);
		int[] platformIndex = new int[ammPlatform];
		for (int i = 0; i < ammPlatform; i++) 
		{
			platformIndex[i] = Random.Range(0,randomList.Count);
		}
		
		foreach (int j in platformIndex)
			randomList [j].gameObject.SetActive (true);
	}
}
