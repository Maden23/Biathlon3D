using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnShooting : MonoBehaviour {

	public GameObject player;
	public GameObject MainCam;
	public GameObject ShCam;
	public GameObject BulletPanel;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		FinishShooting ();
	}

	public void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			player.GetComponent<PlayerMovement2> ().enabled = false;
			player.GetComponent<Animator> ().SetBool ("is_readyToShoot", true);
			Invoke ("ChangeCamera", 3);
			player.transform.SetPositionAndRotation (transform.position, transform.rotation);
			player.GetComponent<ShootingControls> ().enabled = true;
			BulletPanel.SetActive (true);
			player.GetComponent<Rigidbody> ().useGravity = false;

		}
			
	}

	private void ChangeCamera()
	{
		MainCam.SetActive (false);
		ShCam.SetActive (true);
	}

	private void ChangeCameraOpposite()
	{
		MainCam.SetActive (true);
		ShCam.SetActive (false);
	}

	private void ReadyRun(){
		player.GetComponent<PlayerMovement2> ().enabled = true;
	}
		
	public void FinishShooting(){
		if (player.GetComponent<ShootingControls> ().bulletsnum == 0){ 
			BulletPanel.SetActive (false);
			player.GetComponent<ShootingControls> ().enabled = false;
			player.GetComponent<Rigidbody> ().useGravity = true;
			ChangeCameraOpposite ();
			player.GetComponent<Animator> ().SetBool ("is_readyToShoot", false);
			Invoke ("ReadyRun", 4);
		}
	}
}
