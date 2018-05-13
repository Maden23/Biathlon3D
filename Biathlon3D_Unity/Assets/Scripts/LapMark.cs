using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapMark : MonoBehaviour {
	public GameObject UILapTimePanel;
	public Text lapCounter;
	public enum Mark {start, mid, finish};
	public Mark markType;
	private Text lapTimeField;
	private Text diffTimeField;
	private Statistics stats;
	private float time;
	private float totalTime;
	private bool isColliding; 


	void Update(){
		isColliding = false;
	}

	public void OnTriggerEnter (Collider other)	{
		if (other.CompareTag ("Player") && !isColliding) {
			isColliding = true;
			totalTime = Time.timeSinceLevelLoad;
			stats = other.GetComponent <Statistics> ();
			UILapTimePanel.SetActive (true);
			lapTimeField = GameObject.Find ("/Canvas/Lap time panel/Lap time").GetComponent<Text> ();
			diffTimeField = GameObject.Find ("/Canvas/Lap time panel/Diff time").GetComponent<Text> ();

			if (markType == Mark.finish) {
				time = totalTime;
				lapTimeField.text = string.Format("{0}:{1:00}.{2:00}", (int)(time / 60), (int)time % 60, (time - (int)time) * 100);
				diffTimeField.text = "--:--.--";
				return;
			}

			if (stats.lap == 0) {
				//First time through the start mark
				UILapTimePanel.SetActive(false);
				stats.lastLap = totalTime;
				stats.lap++;
				lapCounter.text = "Lap: " + stats.lap.ToString();
				return;
			}
			else if (stats.lap == 1){
				time = totalTime - stats.lastLap;
				stats.bestTime [(int)markType] = time; 
			} else {
				time = totalTime - stats.lastLap;
			}
	


			lapTimeField.text = string.Format("{0}:{1:00}.{2:00}", (int)(time / 60), (int)time % 60, (time - (int)time) * 100);
			if (stats.lap > 1) {
				float diff = time - stats.bestTime [(int)markType];
				diffTimeField.text = diffTimeFormat (diff);

				if (time < stats.bestTime [(int)markType])
					stats.bestTime [(int)markType] = time;
			}
			else {
				diffTimeField.text = "--:--.--";
			}


			if (markType == Mark.start) {
				stats.lap++;
				lapCounter.text = "Lap: " + stats.lap.ToString();
				stats.lastLap = totalTime;
			}


			Debug.Log ("Lap: " + stats.lap + ", Time: " + time + ", Best: " + stats.bestTime [(int)markType]);
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
		UILapTimePanel.SetActive (false);
	}
}
