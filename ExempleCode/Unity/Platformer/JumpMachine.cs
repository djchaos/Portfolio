using UnityEngine;
using System.Collections;

public class JumpMachine : MonoBehaviour 
{
	private void CallSuperJump(float superJumpForce)
	{
		GameObject.FindGameObjectWithTag ("Player").SendMessage ("SuperJump", superJumpForce);
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
			CallSuperJump (15.0f);
	}
}