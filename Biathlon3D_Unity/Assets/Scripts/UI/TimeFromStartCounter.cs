using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeFromStartCounter : MonoBehaviour {
	private Text timerLabel;
	void Start () {
		timerLabel = GetComponent<Text> ();
		timerLabel.text = "0:00.00";                                                                                       
	}

	void Update () {
		float time = Time.timeSinceLevelLoad;
		timerLabel.text = string.Format ("{0}:{1:00}.{2:00}", (int)(time / 60), (int)time % 60, (time - (int)time) * 100);
	}
}
