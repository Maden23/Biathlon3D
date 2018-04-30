using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour 
{
	public float speed = 8;
	public float angularSpeed = 100;

	float horizontal;
	float vertical;
	private Animator animator;
	private Rigidbody rb;

	void Start () 
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody> ();
	}

	private void Update()
	{
		//Use when moving by Translate
		MoveCharacter ();
		GetUpIfFell ();
	}

	/*private void FixedUpdate()
	{
		// Use when moving by AddForce
		MoveCharacter ();
	}*/

	private void MoveCharacter ()
	{
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");

		if (horizontal != 0 || vertical > 0) 
		{
			animator.SetBool ("is_ready", true);
			animator.SetBool ("is_moving", true);
			//rb.AddForce((/*transform.right*horizontal +*/transform.forward*vertical) * speed * Time.deltaTime, ForceMode.Impulse);
			//rb.AddTorque(Vector3.up * horizontal * angularSpeed * Time.deltaTime, ForceMode.Impulse);
			transform.Translate(0, 0, vertical * speed * Time.deltaTime);
			transform.Rotate (0, horizontal * angularSpeed * Time.deltaTime, 0);
		} 
		else 
		{
			animator.SetBool ("is_ready", false);
			animator.SetBool ("is_moving", false);
		}
	}

	private void GetUpIfFell()
	{
		if (Mathf.Abs (transform.eulerAngles.x) > 45) 
		{
			transform.Rotate (-transform.eulerAngles.x, 0, 0);
		}
		if (Mathf.Abs (transform.eulerAngles.z) > 30) 
		{
			transform.Rotate (0, 0, -transform.eulerAngles.z);
		}
	}
}

