using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	public int value;

	// Use this for initialization
	public void Start () {
		this.GetComponent<Button> ().interactable = false;
		this.resetValue ();
	}

	public void UpdateScore(){
		Global.score = Global.score + this.value;
		this.resetValue ();
	}

	public void updateValue(int newValue) {
		this.value = newValue;
	}

	public void resetValue() {
		this.value = 0;
	}
}
