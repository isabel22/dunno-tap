using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Global : MonoBehaviour {

	public static int score;
	public static int time;
	public static int goal;
	public static bool boxTaken;

	public static int boxNumber;
	public static GameObject boxup;

	private UnityEngine.UI.Text timeLabel;


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
		//Each level will start with the following time.
		//TODO: make it start with 10 seconds and substract it second per second.
		time = 0;
		arrayofboxes = GameObject.FindGameObjectsWithTag("box");
		v0 = Vector3.zero;
		imageVisible = new Vector3(4.5f,4.5f,4.5f);
		timeLabel = GameObject.Find("Time").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!boxTaken && time > 0) {
			StartCoroutine (takeRandomBox ());
		}
		time = (int)Time.time;
		timeLabel.text = "Time: " + time.ToString ();
	}

	IEnumerator takeRandomBox()
	{
		boxTaken = true;
		boxNumber = (int)Random.Range (0.0f, 9.0f);
		boxup = arrayofboxes[boxNumber];
		string boxupName = boxup.gameObject.name;
		float counter = 0f;
		Vector3 visiblePosition = new Vector3 (0.0f, 0.0f, -0.5f);

		//0
		addPointSelected = GameObject.Find ("goldie" + boxupName);
		//1
		substPointSelected = GameObject.Find ("hammer" + boxupName);

		int iconVisible = (int)Random.Range (0.4f, 1.4f);

		while (counter < 13.5f) {
			boxup.gameObject.transform.transform.Rotate (Vector3.up * counter);
			yield return  new WaitForSeconds (0.00000005f);
			counter = counter + 0.5f;
		}

		if (iconVisible == 0) {
			addPointSelected.transform.localScale = imageVisible;
			addPointSelected.transform.localPosition = visiblePosition;
			substPointSelected.gameObject.GetComponent<Button> ().interactable = false;
		} else {
			substPointSelected.transform.localScale = imageVisible;
			substPointSelected.transform.localPosition = visiblePosition;
			addPointSelected.gameObject.GetComponent<Button> ().interactable = false;
		}

		yield return  new WaitForSeconds (0.5f);

		if (iconVisible == 0) {
			addPointSelected.transform.localPosition = v0;
			addPointSelected.transform.localScale = v0;
		} else {
			substPointSelected.transform.localPosition = v0;
			substPointSelected.transform.localScale = v0;
		}

		counter = 0;
		while (counter < 13.5f) {
			boxup.gameObject.transform.transform.Rotate (Vector3.down * counter);
			yield return  new WaitForSeconds (0.00000005f);
			counter = counter + 0.5f;
		}
		addPointSelected.gameObject.GetComponent<Button> ().interactable = true;
		substPointSelected.gameObject.GetComponent<Button> ().interactable = true;
		boxTaken = false;
	}
}
