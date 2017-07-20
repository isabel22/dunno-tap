using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour {

	private static int initialTime = 10;
	public static int score;
	private static int time = initialTime;
	private static int goal = 40;
	private static int level = 1;
	private static bool boxTaken = false;

	private static int boxNumber = 0;
	private static GameObject boxup;

	private UnityEngine.UI.Text timeLabel;
	private UnityEngine.UI.Text goalLabel;
	private UnityEngine.UI.Text levelLabel;
	private UnityEngine.UI.Text scoreLabel;
	private UnityEngine.UI.Text gameOver;
	private UnityEngine.UI.Button restart;

	private static GameObject[] arrayofboxes;
	private static Vector3 v0 = Vector3.zero;
	private static Vector3 imageVisible = new Vector3(4.5f,4.5f,4.5f);
	GameObject addPointSelected;
	GameObject substPointSelected;

	// Use this for initialization
	void Start () {

		timeLabel = GameObject.Find("Time").GetComponent<Text>();
		goalLabel = GameObject.Find("Goal").GetComponent<Text>();
		levelLabel = GameObject.Find("Level").GetComponent<Text>();
		gameOver = GameObject.Find("GameOver").GetComponent<Text>();
		restart = GameObject.Find ("Restart").GetComponent<Button> ();
		scoreLabel = GameObject.Find("Score").GetComponent<Text>();

		levelLabel.text = "Level: " + level;
		goalLabel.text = "Goal: " + goal;
		gameOver.transform.localScale = Vector3.zero;
		restart.transform.localScale = Vector3.zero;
		arrayofboxes = GameObject.FindGameObjectsWithTag("box");
	}
	
	// Update is called once per frame
	void Update () {
		if (!boxTaken && time > 0) {
			StartCoroutine (takeRandomBox ());
		}

		if (time > 0) {
			//TODO: time needs to be changed for levels 2...N
			time = initialTime - (int)Time.timeSinceLevelLoad;
			timeLabel.text = "Time: " + time.ToString ();
		} 

		//Check if we can level up or game over
		if (score >= goal && time == 0) {
			changeLevel ();
		}

		if (time == 0 && score < goal) {
			//GameOver
			gameOver.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
			restart.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
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

	public void restartScene(){
		goal = 40;
		level = 1;
		score = 0;
		Scene scene = SceneManager.GetActiveScene(); 
		SceneManager.LoadScene(scene.name);
		//SceneManager.SetActiveScene (scene);

		gameOver.transform.localScale = v0;
		restart.transform.localScale = v0;

		scoreLabel.text = "Score: " + score;
	}

	void changeLevel() {
		//Reset time
		Scene scene = SceneManager.GetActiveScene(); 
		SceneManager.LoadScene(scene.name);
		time = initialTime;
//		Debug.Log (score + "Level: " +level);
		//SceneManager.SetActiveScene (scene);

		//Calculate next goal;
		goal = (int) (goal + goal*0.5);
		goalLabel.text = "Goal: " + goal;

		//uplevel
		level++;
		levelLabel.text = "Level: " + level;

		//score continues adding up...
		scoreLabel.text = "Score: " + score.ToString();
//		Debug.Log (score + "Level: " +level + " Label" + scoreLabel.text);

		//TODO: difficulty upgrade with less time between box changes and the time visible for the image.
	}

	protected void Awake(){
		time = initialTime;
		boxTaken = false;
		boxNumber = 0;
	}
}
