using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	public int value;
	public int time;

//	private UnityEngine.UI.Text Score = GameObject.FindGameObjectWithTag ("ScoreText").GetComponent < UnityEngine.UI.Text> ();

	private UnityEngine.UI.Text Score;

	// Use this for initialization
	public void Start () {
		value = 0;
		time = 0;
		//Score = GameObject.FindWithTag("ScoreText").GetComponent<UnityEngine.UI.Text>();
		Score = GameObject.Find("Score").GetComponent<Text>();
		Debug.Log (Score.text);
		Debug.Log (this.name);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateScore(){
		Global.score = Global.score + this.value;
		Score.text = "Score: " + Global.score.ToString();
		Debug.Log (Global.score);
		Debug.Log (value);
		Debug.Log (Score.text);
		Debug.Log (this.name);
	}

	public void UpdateTime(){
		Global.time = Global.time + this.time;
	}
}
