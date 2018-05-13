using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownhillAnimationOff : MonoBehaviour {

	private Animator animator;
	private float playerSpeed;


	public void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Player"))
		{
			animator = other.GetComponent<Animator> ();
			animator.SetBool ("is_startdownhill", false);
			animator.SetBool ("is_ondownhill", false);
			playerSpeed = other.GetComponent<PlayerMovement> ().speed;
			other.GetComponent<PlayerMovement> ().speed = playerSpeed / 1.5f;
		}
	}
}
