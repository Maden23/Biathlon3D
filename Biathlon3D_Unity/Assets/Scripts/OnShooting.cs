using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnShooting : MonoBehaviour {

	public GameObject player;
	public GameObject MainCam;
	public GameObject ShCam;
	public GameObject BulletPanel;

	void Update () {
		FinishShooting ();
	}

	public void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			player.GetComponent<PlayerMovement2> ().enabled = false;
			player.GetComponent<Animator> ().SetBool ("is_readyToShoot", true);
			Invoke ("ChangeCameraToShooting", 3);
			player.transform.SetPositionAndRotation (transform.position, transform.rotation);
			player.GetComponent<ShootingControls> ().enabled = true;
			BulletPanel.SetActive (true);
			player.GetComponent<Rigidbody> ().useGravity = false;
		}
	}

	private void ChangeCameraToShooting()
	{
		MainCam.SetActive (false);
		ShCam.SetActive (true);
	}

	private void ChangeCameraToMain()
	{
		MainCam.SetActive (true);
		ShCam.SetActive (false);
	}

	private void ReadyRun(){
		player.GetComponent<Animator> ().SetBool ("is_ready", true);
		player.GetComponent<PlayerMovement2> ().enabled = true;
		player.GetComponent<Animator> ().SetBool ("is_shootingdown", false);
	}
		
	public void FinishShooting(){
		if (player.GetComponent<ShootingControls> ().enabled && player.GetComponent<ShootingControls> ().bulletsnum == 0){ 
			BulletPanel.SetActive (false);
			player.GetComponent<ShootingControls> ().enabled = false;
			Invoke ("ChangeCameraToMain", 0.5f);
			//Invoke ("ChangeCameraToMain", 1);
			player.GetComponent<Animator> ().SetBool ("is_readyToShoot", false);
			//player.GetComponent<Animator> ().SetBool ("is_shootingdown", false);

			player.GetComponent<Rigidbody> ().useGravity = true;
			Invoke ("ReadyRun", 1);
			GetComponent<BoxCollider> ().gameObject.SetActive (false);
		}
	}

}
