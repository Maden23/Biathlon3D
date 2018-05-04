﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingControls : MonoBehaviour {

	float horizontal;
	float vertical;
	private Animator animator;
	public int speed;
	public GameObject bullet;
	public int shotspeed = 1000;
	public Transform StartPoint;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
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
	}

	void Shot () {
		if (Input.GetMouseButtonDown(0)) {
			GameObject obj = Instantiate(this.bullet, this.StartPoint.position, Quaternion.identity) as GameObject;
			obj.transform.forward = this.StartPoint.forward;
			obj.GetComponent<Rigidbody>().AddForce(Vector3.forward * shotspeed * Time.deltaTime);
			Destroy (obj, 2);
		}

	}
}
