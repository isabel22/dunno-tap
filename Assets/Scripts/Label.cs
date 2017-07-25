using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Label : MonoBehaviour {

	private Vector3 maxScale = new Vector3(2.4f, 2.4f, 2.4f);
	private Vector3 basicScale = new Vector3(1.4f, 1.4f, 1.4f);
	private static UnityEngine.UI.Text label;
	private string lastValue;

	// Use this for initialization
	void Start () {
		label = GameObject.Find("Time").GetComponent<Text>();
		lastValue = label.text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void VariableChangeHandler(string newVal)
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
		Debug.Log ("last: " + lastValue);
		Debug.Log ("labeltext: " + label.text);
		if (label.text != lastValue && this.name == "Time") {
			StartCoroutine (changeWithColor ());
			lastValue = label.text;
		}
	}

	IEnumerator changeWithColor() {
		if (this.name == "Time") {
			label.color = UnityEngine.Color.red;
			transform.localScale = maxScale;
			yield return  new WaitForSeconds (1f);
			transform.localScale = basicScale;
			label.color = UnityEngine.Color.white;
		}
	}
}
