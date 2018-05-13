using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownhillAnimationOn : MonoBehaviour {

	private Animator animator;
	private float playerSpeed;


	public void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Player"))
		{
			animator = other.GetComponent<Animator> ();
			animator.SetBool ("is_startdownhill", true);
			animator.SetBool ("is_ondownhill", true);
			playerSpeed = other.GetComponent<PlayerMovement> ().speed;
			other.GetComponent<PlayerMovement> ().speed = 1.5f * playerSpeed;
		}
	}
}
