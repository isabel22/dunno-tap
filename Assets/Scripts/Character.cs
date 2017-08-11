using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	public int value;
	private static UnityEngine.UI.Text scoreLabel;

	// Use this for initialization
	public void Start () {
		scoreLabel = GameObject.Find("Score").GetComponent<Text>();
		if (this.GetType ().Equals( "Button")) {
			this.GetComponent<Button> ().interactable = false;
		}
		this.resetValue ();
	}

	public void UpdateScore(){
		Global.score = Global.score + this.value;
		this.resetValue ();
		scoreLabel.SendMessage ("VariableChangeHandler");
	}

	public void updateValue(int newValue) {
		this.value = newValue;
	}

	public void resetValue() {
		this.value = 0;
	}
}
