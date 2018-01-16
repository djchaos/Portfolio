using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour
{

    float speed = 1.2f;

    // Use this for initialization
    void OnEnable ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
