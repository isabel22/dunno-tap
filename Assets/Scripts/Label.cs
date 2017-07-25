using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Label : MonoBehaviour {

	private Vector3 maxScale = new Vector3(2.4f, 2.4f, 2.4f);
	private Vector3 basicScale = new Vector3(1.4f, 1.4f, 1.4f);

	// Use this for initialization
	void Start () {
		GameObject.Find(this.name).GetComponent<Text>();
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
}
