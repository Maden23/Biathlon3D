using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapTimer : MonoBehaviour {
	public float bestTime;
	private float lastLap;
	private Text lapTimeField;
	private Text diffTimeField;

	void Start(){
		lapTimeField = GameObject.Find ("/Canvas/Lap time panel/Lap time").GetComponent<Text> ();
		diffTimeField = GameObject.Find ("/Canvas/Lap time panel/Diff time").GetComponent<Text> ();
		lastLap = 0;
		bestTime = 95;
	}

	public void OnTriggerExit (Collider other)	{
		if (other.CompareTag ("Player")) {
			float raceTime = Time.timeSinceLevelLoad;
			float time = raceTime - lastLap;
			lastLap = raceTime;

			Debug.Log (time);

			lapTimeField.text = string.Format("{0}:{1:00}.{2:00}", (int)(time / 60), (int)time % 60, (time - (int)time) * 100);
			float diff = time - bestTime;
			diffTimeField.text = diffTimeFormat (diff);
			if (time < bestTime)
				bestTime = time;
		}
	}

	private string diffTimeFormat (float diff){
		string text;

		if (diff > 0)
			text = "+";
		else 
			text = "-";
		
		diff = Mathf.Abs (diff);

		if ((int)diff / 60 > 0)
			text += string.Format ("{0:00}:", (int)diff / 60);
		text += string.Format ("{0:00}.{1:00}", (int)diff % 60, (diff - (int)diff) * 100);
		return text;
	}
}
