using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour
{

    float speed = 1.2f;

    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    
}
