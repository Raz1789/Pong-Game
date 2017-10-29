using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour {

	private static bool startCounter = false;
	private static bool counterRunning = false;

	public AudioSource audCounter;
	public AudioSource audBuzzer;

	private float timeCounter = 0f;
	private Text countText;
	private int maxCount;
	private int counter;
	private bool previousStartState = false;

	// Use this for initialization
	void Awake () {
		countText = GetComponent<Text> ();
		countText.enabled = false;
		maxCount = int.Parse(countText.text);
		countText.text = "";
	}

	// Update is called once per frame
	void Update () {
		//Setting the counter to start position
		if(!previousStartState && startCounter)
			counter = maxCount;

		//Setting visibility of Counter
		countText.enabled = startCounter;

		//Main counter functionality
		if (startCounter || counterRunning) {
			//timerCounter
			timeCounter += Time.deltaTime;
			counterRunning = true;

			//One Second counter
			if (timeCounter > 1) {
				if (audCounter != null && counter <=3 && counter > 0)
					audCounter.Play ();
				if (audBuzzer != null && counter == 0)
					audBuzzer.Play ();
				countText.text = counter.ToString();
				if (counter == -1) {
					counterRunning = false;
					startCounter = false;
					counter = 3;
				}
				counter--;
				timeCounter = 0f;
			}

		}

		//Storing previous state
		previousStartState = startCounter;
	}

	public static void setStartCounter(){
		startCounter = true;
	}

	public static bool isRunning() {
		return counterRunning;
	}
}
