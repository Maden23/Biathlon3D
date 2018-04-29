using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour 
{
	public GameObject player;
	private Vector3 playerPos;
	private Quaternion playerRot;
	private Vector3 displacement;

	void Start () 
	{
		playerPos = player.transform.position;
		playerRot = player.transform.rotation;
		displacement.x = -0.5f;
		displacement.y = 6;
		displacement.z = -11;
	}
	
	void Update () 
	{
		playerPos = player.transform.position;
		transform.position = playerPos + displacement;
		transform.Rotate(0, playerRot.eulerAngles.y, playerRot.eulerAngles.z);
	}
}
