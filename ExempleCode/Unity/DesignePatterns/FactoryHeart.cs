using UnityEngine;
using System.Collections;

public class FactoryHeart : MonoBehaviour
{

    public GameObject heartObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject CreateHeart(bool isInactive)
    {
        GameObject so = (GameObject)Instantiate(heartObject, new Vector3(0, 0, 0), Quaternion.identity);

        if(isInactive)
        {
            so.SetActive(false);
        }

        return so;
    }
 }
