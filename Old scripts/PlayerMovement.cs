using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour 
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
		direction.x = Input.GetAxis ("Horizontal");
		direction.z = Input.GetAxis ("Vertical");

		if (direction != Vector3.zero) 
		{
			transform.forward = direction;
			animator.SetBool ("is_ready", true);
			animator.SetBool ("is_moving", true);
			transform.forward = direction;
			rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
			//rb.AddForce(direction * speed * Time.deltaTime);
			//rb.AddTorque(Vector3.up * direction.x * speed* Time.deltaTime);
		} 
		else 
		{
			animator.SetBool ("is_ready", false);
			animator.SetBool ("is_moving", false);
		}
	}
}
