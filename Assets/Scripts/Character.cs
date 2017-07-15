using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	int value;
	int time;

//	private UnityEngine.UI.Text Score = GameObject.FindGameObjectWithTag ("ScoreText").GetComponent < UnityEngine.UI.Text> ();

	private UnityEngine.UI.Text Score;

	// Use this for initialization
	public void Start () {
		value = 0;
		time = 0;
		Score = GameObject.Find("Score").GetComponent<Text>();

		if (this.tag.Equals("addScore")) {
			value = 15;
		}
		if (this.tag.Equals("substScore")) {
			value = -17;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateScore(){
		Global.score = Global.score + this.value;
		Score.text = "Score: " + Global.score.ToString();
	}

	public void UpdateTime(){
		Global.time = Global.time + this.time;
	}
}
