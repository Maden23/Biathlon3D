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
			playerSpeed = other.GetComponent<PlayerMovement2> ().speed;
			other.GetComponent<PlayerMovement2> ().speed = 1.5f * playerSpeed;
		}
	}
}
