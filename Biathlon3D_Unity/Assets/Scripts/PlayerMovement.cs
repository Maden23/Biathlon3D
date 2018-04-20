using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public float speed = 8;

	private Vector3 direction = Vector3.zero;
	private Animator animator;
	private Rigidbody rb;

	void Start () 
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody> ();
	}

	private void FixedUpdate()
	{
		MoveCharacter ();
	}
	
	private void MoveCharacter ()
	{
		direction.x = Input.GetAxis ("Horizontal") * speed;
		direction.z = Input.GetAxis ("Vertical") * speed;

		if (direction.x != 0 || direction.z != 0) 
		{
			animator.SetBool ("isMoving", true);
			rb.AddForce(direction * Time.deltaTime);
		} 
		else 
		{
			animator.SetBool ("isMoving", false);
		}
	}
}
