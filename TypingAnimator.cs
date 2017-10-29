using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingAnimator : MonoBehaviour {

	private Text displayText;
	private string orgDisplayText;
	private float timeCounter;
	private bool running;
	private int displayTextIndex;
	public AudioSource audType;
	public AudioSource audEnter;

	// Awake this instance.
	void Awake () {
		displayText = GetComponent<Text> ();
		orgDisplayText = displayText.text;	
		running = true;
		displayTextIndex = 0;
		timeCounter = 0;
		GameOptionsAnimation.timeCounter = GameOptionsAnimation.DEFAULT_TIME;
	}

	// Start this instance.
	void Start () {
		displayText.text = "";
		GameOptionsAnimation.timeCounter = GameOptionsAnimation.DEFAULT_TIME;
	}
	
	// Update is called once per frame
	void Update () {
		if (running) {
			timeCounter += Time.deltaTime;
			if (timeCounter > 0.3) {
				if (orgDisplayText [displayTextIndex] != '\n') {
					if (audType != null)
						audType.Play ();
				} else if (audEnter != null){
					audEnter.Play();
				}
					
				displayText.text += orgDisplayText[displayTextIndex];
				if (displayTextIndex < orgDisplayText.Length-1)
					displayTextIndex++;
				else
					running = false;
				timeCounter = 0;
			}
			if (Input.GetKeyDown (KeyCode.Escape)) {
				displayText.text = orgDisplayText;
				running = false;
				GameOptionsAnimation.timeCounter = 0;
			}
				
		}
	}
}
