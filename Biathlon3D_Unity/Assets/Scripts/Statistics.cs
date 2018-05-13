using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour {
	enum Mark {start, mid, finish};
	public int lap;
	public float[] bestTime = { 0, 0, 0 };
	//public float[] lastLap = { 0, 0, 0 };
	public float lastLap = 0;

	void Start () {
		lap = 0;
		
	}
		



}
