using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMechanics : MonoBehaviour 
{
	public float speedMove;

	private float gravityForce;
	private Vector3 moveVector;
	private CharacterController ch_controller;
	private Animator ch_animator;

	private void Start()
	{
		ch_animator = GetComponent<Animator>();
		ch_controller = GetComponent<CharacterController>();

	}

	private void Update()
	{
		CharacterMove ();
	}

	private void CharacterMove()
	{
		moveVector = Vector3.zero;
		moveVector.x = Input.GetAxis ("Horizontal") * speedMove;
		moveVector.z = Input.GetAxis ("Vertical") * speedMove;

		ch_controller.Move (moveVector * Time.deltaTime); 
		moveVector.y = gravity
	}

	private void GamingGravity()
	{
		if (!ch_controller.isGrounded)
			gravityForce -= 20f * Time.deltaTime;
		else
			gravityForce -= 1f;
	}