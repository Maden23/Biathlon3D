using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotOrNot : MonoBehaviour {

	public GameObject tgt;

	public void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Bullet")) {
			tgt.GetComponent<Animator> ().SetBool ("is_got", true);
		} else {
			tgt.GetComponent<Animator> ().SetBool ("is_got", false);
		}
	}
}
