using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour 
{
	public List<GameObject> prefabList = new List<GameObject>();
	private List<GameObject> activePrefab = new List<GameObject> ();
	private float spawnY = 0;
	private Transform cameraTransform;

	public GameObject beginPrefab;

	private void Start () 
	{
		cameraTransform = Camera.main.transform;
		SpawnPrefab (beginPrefab);
		SpawnPrefab (GetRandomPrefab());
		SpawnPrefab (GetRandomPrefab());
	}

	private void Update () 
	{
		if (cameraTransform.position.y > (spawnY - 5)) 
		{
			SpawnPrefab(GetRandomPrefab());
			Destroy(activePrefab[0]);
			activePrefab.RemoveAt(0);
		}
	}
	
	private void SpawnPrefab(GameObject prefab)
	{
		activePrefab.Add(Instantiate(prefab,new Vector3(0,spawnY,0),Quaternion.identity) as GameObject);
		spawnY += 5;
	}

	private GameObject GetRandomPrefab()
	{
		return prefabList[Random.Range(0,prefabList.Count)];
	}
}
