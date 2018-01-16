
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingletonStar:MonoBehaviour
{
    List<GameObject> listStar = new List<GameObject>();
    FactoryStar factoryStar;

	public string _value = "Access to Singleton value Example 4";

	private static SingletonStar _instance;

	public static SingletonStar getInstance()
    {			
		if(_instance == null)
		{
			_instance = GameObject.FindObjectOfType<SingletonStar>();
		}
        /*
		if(_instance == null)
		{
			Debug.LogError("An instance of Singleton is needed in the scene, but there's none.");
		}
        */
		

		if(_instance == null)
		{
			GameObject go = new GameObject("SingletonStar");
			_instance = go.AddComponent<SingletonStar>();
		}
		

		return _instance;
	}


    private void Awake ()
    {
        factoryStar = Camera.main.GetComponent<FactoryStar>();
    }


    public void CreateStar(bool isInactive)
    {
        listStar.Add(factoryStar.CreateStar(isInactive));
    }

    public void TchekPoolS()
    {
        for( int i = 0; i < listStar.Count; i++)
        {
            if (!listStar[i].activeInHierarchy)
            {
                listStar[i].SetActive(true);
                return;
            }
        }

        CreateStar(false);
    }
}
