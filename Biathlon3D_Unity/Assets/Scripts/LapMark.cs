using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapMark : MonoBehaviour {
	public float bestTime;
	public GameObject UIShowPanel;
	private float lastLap;
	private Text lapTimeField;
	private Text diffTimeField;

	void Start(){
		lastLap = 0;
		bestTime = 95;

	}

	public void OnTriggerExit (Collider other)	{
		if (other.CompareTag ("Player")) {
			UIShowPanel.SetActive (true);
			lapTimeField = GameObject.Find ("/Canvas/Lap time panel/Lap time").GetComponent<Text> ();
			diffTimeField = GameObject.Find ("/Canvas/Lap time panel/Diff time").GetComponent<Text> ();
			if (lapTimeField)
				Debug.Log ("Text found");
			
			float raceTime = Time.timeSinceLevelLoad;
			float time = raceTime - lastLap;
			lastLap = raceTime;

			Debug.Log (time);

			lapTimeField.text = string.Format("{0}:{1:00}.{2:00}", (int)(time / 60), (int)time % 60, (time - (int)time) * 100);
			float diff = time - bestTime;
			diffTimeField.text = diffTimeFormat (diff);
			if (time < bestTime)
				bestTime = time;
			Invoke ("HidePanel", 5);
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

	private void HidePanel()
	{
		UIShowPanel.SetActive (false);
	}
}
