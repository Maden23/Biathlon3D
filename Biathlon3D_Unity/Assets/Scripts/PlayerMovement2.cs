using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour 
{
	public float speed = 8;

	float horizontal;
	float vertical;
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
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");

		if (horizontal!= 0 || vertical != 0) 
		{
			animator.SetBool ("is_ready", true);
			animator.SetBool ("is_moving", true);
			rb.AddForce((/*(transform.right*horizontal)+*/(transform.forward*vertical))* speed * Time.deltaTime);
			rb.AddTorque(Vector3.up * horizontal * speed * Time.deltaTime);
		} 
		else 
		{
			animator.SetBool ("is_ready", false);
			animator.SetBool ("is_moving", false);
		}
	}
}

