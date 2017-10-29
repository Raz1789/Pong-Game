using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager1P : MonoBehaviour {

	private bool firstTime = true;
	private static int windowWidth = Screen.width;
	private static int windowHeight = windowWidth * 4 / 3;
	public static float scaleFactorX = windowWidth / 640;
	public static float scaleFactorY = windowHeight / 480;
	public static bool running = true;
	private float timeCounter;

	public Text restartText;

	// Use this for initialization
	void Start () {
		CounterScript.setStartCounter ();
	}
	
	// Update is called once per frame
	void Update () {

		timeCounter += Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.Q)) {
			Application.Quit ();
		}

		if (Input.GetKeyDown (KeyCode.M)) {
			SceneManager.LoadScene (0);
		}

		if (!CounterScript.isRunning() && firstTime) {
			firstTime = false;
		}

		if (timeCounter > 0.5f) {
			if (!running)
				restartText.enabled = !restartText.enabled;
			timeCounter = 0f;
		}

		if (running)
			restartText.enabled = false;

	}
}
