using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public int score;
	public Text scoreText;

	// Use this for initialization
	void Awake () {		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D () {
		score++;
		scoreText.text = "Score: " + score;
		GameManager1P.running = false;
	}

}
