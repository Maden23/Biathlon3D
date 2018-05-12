using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingControls : MonoBehaviour {

	float horizontal;
	float vertical;
	public int speed;
	public GameObject bullet;
	public int shotspeed;
	public Transform StartPoint;
	public int bulletsnum;

	// Use this for initialization
	void Start () {
		bulletsnum = 5;
	}

	// Update is called once per frame
	void Update () {
		Debug.DrawRay (StartPoint.position, StartPoint.forward*100000, Color.green);
		Controls ();
		Shot ();
	}

	private void Controls(){
		horizontal = Input.GetAxis ("Mouse Y");
		vertical = Input.GetAxis ("Mouse X");
		if ((horizontal != 0 || vertical != 0) && ((Mathf.Abs (transform.eulerAngles.y) > 15)  || (Mathf.Abs (transform.eulerAngles.z) > 15)) ) {
			transform.Rotate (0, vertical *speed* Time.deltaTime, 0);
			transform.Rotate (0, 0, -1*horizontal * speed * Time.deltaTime);
		}
		if (Mathf.Abs (transform.eulerAngles.x) > 1) 
		{
			transform.Rotate (-transform.eulerAngles.x, 0, 0);
		}
	}
	
	void Shot () {
			//Invoke ("setIsReadyToShoot", 1);
		if (Input.GetMouseButtonDown (0)) {
			if (bulletsnum!=0) {
				RaycastHit hit;
				if ((Physics.Raycast (StartPoint.transform.position, StartPoint.transform.forward * 100000, out hit))) {
					if (hit.transform.CompareTag ("Target")) {
						Debug.Log ("Got");
						hit.transform.gameObject.GetComponentInChildren<Animator> ().SetBool ("is_got", true);
					} else {
						Debug.Log ("Missed");
					}
					bulletsnum -= 1;
					GetComponent<Animator> ().SetBool ("is_shootingdown", true);
				} else {
					GetComponent<Animator> ().SetBool ("is_shootingdown", false);
				}
			}
		}
	}



	/*private void setIsReadyToShoot(){
		if (Input.GetMouseButtonDown (0)) {
			if (bulletsnum!=0) {
				RaycastHit hit;
				if ((Physics.Raycast (StartPoint.transform.position, StartPoint.transform.forward * 100000, out hit))) {
					if (hit.transform.CompareTag ("Target")) {
						Debug.Log ("Got");
						hit.transform.gameObject.GetComponentInChildren<Animator> ().SetBool ("is_got", true);
					} else {
						Debug.Log ("Missed");
					}
					bulletsnum -= 1;
					GetComponent<Animator> ().SetBool ("is_shootingdown", true);
				} else {
					GetComponent<Animator> ().SetBool ("is_shootingdown", false);
				}
			}
		}
	}*/

}
