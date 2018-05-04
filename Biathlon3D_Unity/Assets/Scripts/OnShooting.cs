﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnShooting : MonoBehaviour {

	public GameObject player;
	public GameObject MainCam;
	public GameObject ShCam;

	public void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			player.GetComponent<PlayerMovement2> ().enabled = false;
			player.GetComponent<Animator> ().SetBool ("is_readyToShoot", true);
			MainCam.SetActive (false);
			ShCam.SetActive (true);
		}
			
	}
}