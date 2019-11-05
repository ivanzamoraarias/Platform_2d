using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static int score;
	Text text;

	void Start(){

		text = GetComponent<Text> ();
		score = 0;
	}

	void Update()
	{
		if (score < 0)
			score = 0;

		text.text = score.ToString ();
		//text.text = ""+score;
	}

	public static void AddPoints(int p)
	{
		score += p;
	}

	public static void Reset()
	{
		score = 0;
	}
}
