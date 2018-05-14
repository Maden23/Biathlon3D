using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public struct HighScore {
	public System.DateTime dateTime;
	public float result;
	public HighScore (System.DateTime newDateTime, float newResult)
	{
		dateTime = newDateTime;
		result = newResult;
	}
}

//https://answers.unity.com/questions/1179242/highscore-with-dreamlo.html#comment-1179575
public class Statistics : MonoBehaviour {
	enum Mark {start, mid, finish};
	public int lap;
	public float[] bestTime = { 0, 0, 0 };
	public float lastLap = 0;

	public GameObject StatsPanel;
	public Text StatsText;
	public string scoresFile;
	private HighScore[] highScoresList;




	void Start () {
		lap = 0;
		ReadRecordsTable ();
		
	}

	public void ShowStats()
	{
		StatsPanel.SetActive (true);	
		for (int i = 0; i < highScoresList.Length; i++) {
			float time = highScoresList [i].result;
			StatsText.text += highScoresList [i].dateTime.ToString () + " Time: "
			+ string.Format ("{0}:{1:00}.{2:00}", (int)(time / 60), (int)time % 60, (time - (int)time) * 100) + "\n";
		}
	}

	public void UpdateRecordsTable (float newResult)
	{
		HighScore[] newList = new HighScore[highScoresList.Length + 1];
		for (int i = 0; i < highScoresList.Length; i++)
			newList [i] = highScoresList [i];
		newList [highScoresList.Length] = new HighScore (System.DateTime.Now, newResult);
		highScoresList = newList;
		SortHighscores ();
		File.Delete (scoresFile);
		FileStream file = File.Create (scoresFile);
		StreamWriter writer = new StreamWriter (file);
		for(int i = 0; i<highScoresList.Length; i++)
			writer.WriteLine (highScoresList[i].dateTime.ToString() + "|" + highScoresList[i].result.ToString());
		writer.Close ();
	}

	void SortHighscores()
	{
		bool swapped;
		do {
			swapped = false;
			for (int i = 1; i < highScoresList.Length; i++) {
				if (highScoresList [i-1].result > highScoresList [i].result) {
					swapped = true;
					HighScore tmp;
					tmp = highScoresList [i-1];
					highScoresList [i-1] = highScoresList [i];
					highScoresList [i] = tmp;
				}
			}
		} while (swapped != false);
	}

	void ReadRecordsTable ()
	{
		StreamReader reader = new StreamReader (scoresFile);
		string[] highScoreStream = reader.ReadToEnd ().Split(new char[] {'\n'}, 
				System.StringSplitOptions.RemoveEmptyEntries);
		highScoresList = new HighScore[highScoreStream.Length];
		for (int i = 0; i < highScoresList.Length; i++){
			string[] highScoreInfo = highScoreStream[i].Split(new char[] {'|'},
				System.StringSplitOptions.RemoveEmptyEntries);
			System.DateTime dateTime = System.DateTime.Parse (highScoreInfo[0]);
			float result = float.Parse (highScoreInfo [1]);
			highScoresList [i] = new HighScore (dateTime, result);
			reader.Close(); 	
		}

	}
}
