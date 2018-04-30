using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour 
{
	public GameObject target;
	private Vector3 offset;

	void Start () 
	{
		offset = target.transform.position - transform.position;
	}
	
	void LateUpdate () 
	{
		float targetAngle = target.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler (0, targetAngle, 0);
		transform.position = target.transform.position + rotation * offset;
		transform.LookAt (target.transform);
	}
}
