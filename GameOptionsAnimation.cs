using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOptionsAnimation : MonoBehaviour {

	public const float DEFAULT_TIME = -6.3f;
	private Text gameOption;
	private string[] indGameOptions;
	public static float timeCounter = DEFAULT_TIME;
	private int gameOptionsIndex;
	private bool blink;
	private bool running;


	void Awake() {
		gameOptionsIndex = 0;
		blink = false;
		running = false;
		gameOption = GetComponent<Text> ();
		indGameOptions = gameOption.text.Split(new char[] {'\n'});

	}

	// Use this for initialization
	void Start () {
		gameOption.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		timeCounter += Time.deltaTime;

		if (timeCounter > -0.01)
			running = true;

		if (running) {

			//USER INPUTS
			if (Input.GetKeyDown (KeyCode.W)) {
				gameOptionsIndex--;
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				gameOptionsIndex++;
			}

			//CLAMPPING GAME OPTIONS
			if (gameOptionsIndex < 0)
				gameOptionsIndex = indGameOptions.Length-1;
			if (gameOptionsIndex >= indGameOptions.Length)
				gameOptionsIndex = 0;


			//GAME OPTION BLINKING
			if (timeCounter > 0.5) {
				gameOption.text = "";
				for (int i = 0; i < indGameOptions.Length; i++) {
					if (gameOptionsIndex == i && blink)
						gameOption.text += "\n";
					else
						gameOption.text += indGameOptions [i] + "\n";
				}

				blink = !blink;
				timeCounter = 0f;
			}

			//SCENE MANAGER
			if(Input.GetKeyDown(KeyCode.Space)){
				SceneManager.LoadScene (gameOptionsIndex+1);
			}
				

		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			Application.Quit ();
		}

	}
}
