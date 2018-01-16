using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;



public class SingletonHeart : MonoBehaviour
{
    List<GameObject> listHeart = new List<GameObject>();
    FactoryHeart factoryHeart;


    public string _value = "Access to Singleton value Example 4";

    private static SingletonHeart _instance;

    public static SingletonHeart getInstance()
    {
        if (_instance == null)
        {
            _instance = GameObject.FindObjectOfType<SingletonHeart>();
        }
        /*
		if(_instance == null)
		{
			Debug.LogError("An instance of Singleton is needed in the scene, but there's none.");
		}
        */

        if (_instance == null)
        {
            GameObject go = new GameObject("SingletonHeart");
            _instance = go.AddComponent<SingletonHeart>();
        }


        return _instance;
    }


    private void Awake ()
    {
        factoryHeart = Camera.main.GetComponent<FactoryHeart>();
    }

    public void CreateHeart(bool isInactive)
    {
        listHeart.Add(factoryHeart.CreateHeart(isInactive));
    }

    public void TcheckPoolH()
    {
        for( int i = 0; i < listHeart.Count; i++)
        {
            if(!listHeart[i].activeInHierarchy)
            {
                listHeart[i].SetActive(true);
                return;
            }
        }

        CreateHeart(false);
    }
}

