using UnityEngine;
using System.Collections;

public class FactoryStar : MonoBehaviour
{

    public GameObject starObject;

    public GameObject CreateStar(bool isInactive)
    {
        GameObject go = (GameObject)Instantiate(starObject, new Vector3(0, 0, 0), Quaternion.identity);

        if (isInactive)
        {
            go.SetActive(false);
        }

        return go; 
    }
}
