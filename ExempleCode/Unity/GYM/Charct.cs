using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charct : MonoBehaviour {

    private int forceTest = 5;
    private float speed = 0.5f;
    private bool jump = false;
    private Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void FixedUpdate()
    {
    }

    void Move()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);

        transform.Translate(movement * speed);

    }

    void Jump()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && jump == true)
        {
            jump = false;
            playerRigidbody.AddForce(0, forceTest, 0, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            jump = true;
        }
    }

}
