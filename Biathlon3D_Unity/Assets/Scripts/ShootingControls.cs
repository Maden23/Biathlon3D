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

	// Use this for initialization
	void Start () {
		
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
	}

	void Shot () {
		if (Input.GetMouseButtonDown (0)) {
			GetComponent<Animator>().SetBool("is_shootingdown", true);
			GameObject obj = Instantiate (this.bullet, this.StartPoint.position, Quaternion.identity) as GameObject;
			obj.transform.forward = this.StartPoint.forward;
			//obj.transform.Translate(Vector3.back * shotspeed * Time.deltaTime);
			obj.GetComponent<Rigidbody> ().AddForce (Vector3.back * shotspeed * Time.deltaTime);
			/*RaycastHit hit;
			if (Physics.Raycast(obj.transform.position, obj.transform.forward, out hit, 2)) {
				print (hit.transform.name);
			}*/
			Destroy (obj, 2);
		} else {
			GetComponent<Animator>().SetBool ("is_shootingdown", false);
		}

	}
}
