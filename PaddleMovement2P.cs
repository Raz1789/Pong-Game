using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement2P : MonoBehaviour {

	[SerializeField]
	private float paddleSpeed = 4f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!CounterScript.isRunning () && GameManager1P.running) {
			//Up motion
			if (Input.GetKey (KeyCode.I)) {
				float tempY = transform.position.y;
				tempY += paddleSpeed;

				if (tempY + 40f > 220f) {
					tempY = 220 - 40;

				}

				transform.position = new Vector2 (transform.position.x, tempY);

			}

			//Down Motion
			if (Input.GetKey (KeyCode.J)) {
				float tempY = transform.position.y;
				tempY -= paddleSpeed;

				if (tempY - 40f < -220f) {
					tempY = -220 + 40;
				}

				transform.position = new Vector2 (transform.position.x, tempY);
			}
		}

		if (!GameManager1P.running) {
			transform.position = new Vector2 (transform.position.x, 0f);
		}
	}
}
