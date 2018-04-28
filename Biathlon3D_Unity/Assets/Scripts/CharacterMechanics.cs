using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMechanics : MonoBehaviour 
{
	public float speed = 8;

	private CharacterController controller;
	private Animator animator;

	private Vector3 direction = Vector3.zero;
	private float gravityForce;

	private void Start()
	{
		animator = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();

	}

	private void FixedUpdate()
	{
		MoveCharacter ();
		//UseGravity ();
	}

	private void MoveCharacter ()
	{
		direction.x = Input.GetAxis ("Horizontal") * speed;
		direction.z = Input.GetAxis ("Vertical") * speed;
		direction.y = gravityForce * speed;
		if (direction.x != 0) 
		{
			transform.Rotate(0f, direction.x * 2 / speed, 0f);
		}
		if (direction.x != 0 || direction.z != 0) 
		{
			animator.SetBool ("is_ready", true);
			animator.SetBool ("is_moving", true);
			direction = transform.TransformDirection (direction);
			controller.Move (direction * Time.deltaTime); 
		} 
		else 
		{
			animator.SetBool ("is_ready", false);
			animator.SetBool ("is_moving", false);
		}
	}

	private void UseGravity ()
	{
		if (!controller.isGrounded) {
			gravityForce -= 20f * Time.deltaTime;
		} 
		else 
		{
			gravityForce = -1f;
		}
	}

}