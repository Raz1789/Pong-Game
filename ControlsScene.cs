﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)||Input.GetKeyDown (KeyCode.M)) {
			SceneManager.LoadScene (0);
		}else if (Input.GetKeyDown (KeyCode.Q)) {
			Application.Quit ();
		}
			
	}
}
