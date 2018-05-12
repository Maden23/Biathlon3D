using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCounter : MonoBehaviour {
	private Text BulletLabel;
	public GameObject player;
	void Start () {
		BulletLabel= GetComponent<Text> ();
		BulletLabel.text = "5";                                                                                       
	}

	void Update () {
		int number = player.GetComponent<ShootingControls> ().bulletsnum;
		BulletLabel.text = string.Format ("{0}", (int)(number));
	}
}
