using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour 
{
	public float speed = 8;
	public float angularSpeed = 100;

	float horizontal;
	float vertical;
	private Animator animator;
	private Rigidbody rb;
	public GameObject ShCam;
	public Transform StartPoint;

	private bool flatTerrain;

	void Start () 
	{
		flatTerrain = true;
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody> ();
		ShCam.SetActive (false);
		GetComponent<ShootingControls> ().enabled =false;
	}

	private void Update()
	{
		//Use when moving by Translate
		Debug.DrawRay (StartPoint.position, StartPoint.forward*100000, Color.green);
		GetUpIfFell ();
		
		MoveCharacter ();
	}

	/*private void FixedUpdate()
	{
		// Use when moving by AddForce
		MoveCharacter ();
	}*/

	private void MoveCharacter ()
	{
		horizontal = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");

		/*if ((transform.eulerAngles.x > 15) &&  (transform.eulerAngles.x < 45)) {
			animator.SetBool ("is_startdownhill", true);
			animator.SetBool ("is_ondownhill", true);
			flatTerrain = false;
			Debug.Log (transform.eulerAngles.x);
		} else {
			animator.SetBool ("is_startdownhill", false);
			animator.SetBool ("is_ondownhill", false);
			flatTerrain = true;
		}*/
	


		if (horizontal != 0 || vertical > 0) 
		{
			animator.SetBool ("is_moving", true);
			animator.SetBool ("is_ready", true);
			//rb.AddForce((/*transform.right*horizontal +*/transform.forward*vertical) * speed * Time.deltaTime, ForceMode.Impulse);
			//rb.AddTorque(Vector3.up * horizontal * angularSpeed * Time.deltaTime, ForceMode.Impulse);
			transform.Translate(0, 0, vertical * speed * Time.deltaTime);
			transform.Rotate (0, horizontal * angularSpeed * Time.deltaTime, 0);
		} 	
		else if (flatTerrain)
		{
			animator.SetBool ("is_moving", false);
			animator.SetBool ("is_ready", false);
		}
			
	}

	private void GetUpIfFell()
	{
		if (Mathf.Abs (transform.eulerAngles.x) > 45) 
		{
			transform.Rotate (-transform.eulerAngles.x, 0, 0);
		}
		if (Mathf.Abs (transform.eulerAngles.z) > 30) 
		{
			transform.Rotate (0, 0, -transform.eulerAngles.z);
		}
	}
}

