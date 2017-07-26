using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Label : MonoBehaviour {

	private Vector3 maxScale = new Vector3(2.0f, 2.0f, 2.0f);
	private Vector3 basicScale = new Vector3(1.4f, 1.4f, 1.4f);
	private static UnityEngine.UI.Text label;
	private string lastValue;

	// Use this for initialization
	void Start () {
		lastValue = "Time: 0";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void VariableChangeHandler()
	{
		//make it bigger
		StartCoroutine (enlargeChange ());
	}
		
	IEnumerator enlargeChange() {
		transform.localScale = maxScale;
		yield return  new WaitForSeconds (0.5f);
		transform.localScale = basicScale;
	}

	public void ChangeColor() {
		label = GameObject.Find("Time").GetComponent<Text>();
		if (label.text != lastValue && this.name == "Time") {
			StartCoroutine (changeWithColor ());
			lastValue = label.text;
		}
	}

	IEnumerator changeWithColor() {
		label.color = UnityEngine.Color.red;
		transform.localScale = maxScale;
		yield return  new WaitForSeconds (0.75f);
		transform.localScale = basicScale;
		label.color = UnityEngine.Color.white;
	}

	public void changeLevel()
	{
		//make it bigger
		StartCoroutine (enlargeLevelChange ());
	}

	IEnumerator enlargeLevelChange() {
		label = GameObject.Find("Level").GetComponent<Text>();
		label.color = UnityEngine.Color.magenta;
		transform.localScale = maxScale;
		yield return  new WaitForSeconds (2.0f);
		transform.localScale = basicScale;
		label.color = UnityEngine.Color.white;
	}
}
