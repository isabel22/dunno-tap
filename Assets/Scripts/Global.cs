using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

	public static int score;
	public static int time;
	public static bool boxTaken;

	public static int boxNumber;
	public static GameObject boxup;


	int counter;
	GameObject[] arrayofboxes;
	Vector3 v0;
	Vector3 imageVisible;
	GameObject addPointSelected;
	GameObject substPointSelected;


	// Use this for initialization
	void Start () {
		score = 0;
		boxTaken = false; 
		boxNumber = 0;
		arrayofboxes = GameObject.FindGameObjectsWithTag("box");
		v0 = Vector3.zero;
		imageVisible = new Vector3(4.5f,4.5f,4.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!boxTaken) {
			StartCoroutine (takeRandomBox ());
		}
	}

	IEnumerator takeRandomBox()
	{
		boxTaken = true;
		boxNumber = (int)Random.Range (0.0f, 9.0f);
		boxup = arrayofboxes[boxNumber];
		string boxupName = boxup.gameObject.name;
		counter = 0;

		//0
		addPointSelected = GameObject.Find ("goldie" + boxupName);

		//1
		substPointSelected = GameObject.Find ("hammer" + boxupName);

		while (counter < 45) {
			boxup.gameObject.transform.transform.Rotate (Vector3.up * counter);
			yield return  new WaitForSeconds (0.00000005f);
			counter++;
		}
		yield return  new WaitForSeconds (0.5f);
		counter = 0;
		while (counter < 45) {
			boxup.gameObject.transform.transform.Rotate (Vector3.down * counter);
			yield return  new WaitForSeconds (0.00000005f);
			counter++;
		}
		Debug.Log ("Name: " + boxup.gameObject.name);
		boxTaken = false;
	}
}
