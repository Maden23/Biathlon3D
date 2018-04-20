using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour 
{
	public GameObject player;
	private Vector3 playerPos;

	void Start () 
	{
		playerPos = player.transform.position;
	}
	
	void FixedUpdate () 
	{
		
	}
}
