using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

	public string scoresFile;
	private HighScore[] highScoresList;




	void Start () {
		lap = 0;
		//UpdateRecordsTable (132.56f);
		//ReadRecordsTable ();
		
	}

	public void UpdateRecordsTable (float newResult)
	{
		StreamWriter writer = new StreamWriter (scoresFile, true);
		writer.WriteLine (System.DateTime.Now.ToString() + "|" + newResult.ToString());
		writer.Close ();
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
			//Debug.Log (highScoresList [i].dateTime);
		}

	}
}
