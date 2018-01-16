using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 	
{
	private Transform cameraTransform;
	private Transform thisTransform;
	private CharacterController controller;
	private Vector3 motion;
	private float verticalVelocity;
	private bool secondJump = false;

	private float superJumpForce = 0.0f;
	private float jumpForce = 10.0f;
	private float gravity = 15.0f;
	private float speed = 9.0f;

	private void Start()
	{
		thisTransform = transform;
		controller = GetComponent<CharacterController> ();
		verticalVelocity = 0;
		cameraTransform = Camera.main.transform;
	}

	private void Update()
	{
		if (thisTransform.position.y < cameraTransform.position.y - 5.2f) 
		{
			Application.LoadLevel ("menu");
		}
		// re-init le motion a zero
		motion = Vector3.zero;

		//condition are your grounded(controller)?
		if (controller.isGrounded)
		{
			//si au sol, subir graviti/ a -1.0f
			verticalVelocity = -1.0f;

			// condition esque quon on appuie sur sapcebar 
			if (Input.GetKeyDown(KeyCode.Space))
			{
				secondJump = true;
				// modifie le float de le 
				verticalVelocity = jumpForce;
			}

			if (Input.GetKey (KeyCode.A)) 
			{
				motion.x += -speed;
			}
			
			if (Input.GetKey (KeyCode.D))
			{
				motion.x += speed;
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (secondJump)
				{
					secondJump = false;
					verticalVelocity = jumpForce;
				}
			}

			if (Input.GetKey (KeyCode.A)) 
			{
				motion.x += -speed/2;
			}
			
			if (Input.GetKey (KeyCode.D))
			{
				motion.x += speed/2;
			}

			verticalVelocity -=gravity * Time.deltaTime;
		}


			//	motion.x = (Input.GetKey (KeyCode.A)) ? -1 : (Input.GetKey (KeyCode.A)) ? 1 : 0;

		if (superJumpForce != 0)
		{

			verticalVelocity = superJumpForce;
			secondJump = true;
			superJumpForce = 0;
		}

		motion.y = verticalVelocity; 	
		controller.Move(motion * Time.deltaTime);
	}

	private void SuperJump(float force)
	{
		superJumpForce = force;
	}
}
