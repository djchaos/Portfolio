using UnityEngine;
using System.Collections;


public class StarManager : MonoBehaviour
{
	private SingletonStar  _singleton;

	void Awake()
	{
		_singleton = SingletonStar.getInstance();
	}

	void Start()
	{
		Debug.Log(_singleton._value);
	}

}
