using UnityEngine;
using System.Collections;

public class View : MonoBehaviour
{
	private Transform YTransform;
	public float speed;

	void Start ()
	{
	
	}

	void Update () 
	{
		transform.position += (Vector3.up * speed) * Time.deltaTime;

		speed = ((Time.deltaTime * 0.02f) + speed);
	}
}
