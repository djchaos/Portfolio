using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // https://forum.unity.com/threads/need-help-with-grid-based-movement-in-c.276793/

    public World world;

    public float speed = 2;
    Vector3 pos;
    Vector3 oldPos;
    Transform tr;
    float offset = 1;

    string test1 = "test";
    string test2 = "test";

    void Start ()
    {
        pos = transform.position;
        tr = transform;

        // test 
        int result = string.Compare(test1, test2);
        Debug.Log(result);

    }
	
	
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            oldPos = pos;
            pos += Vector3.up / offset;
            world.TakeItme(pos);
            Move(pos);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            oldPos = pos;
            pos += Vector3.down / offset;
            world.TakeItme(pos);
            Move(pos);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            oldPos = pos;
            pos += Vector3.right / offset;
            world.TakeItme(pos);
            Move(pos);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            oldPos = pos;
            pos += Vector3.left / offset;
            world.TakeItme(pos);
            Move(pos);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            world.Interact(pos);
        }


    }

    void Move(Vector3 position)
    {

        if (!world.Hittest((int)position.x, (int)position.y))
        {
            transform.position = position; //Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
        }
        else
        {
            pos = oldPos;
        }
   
        
    }
}
