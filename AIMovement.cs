using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {

	public float pongY;
	private float delay = 0.3f;
	private float ySpeed = 0.5f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		pongY = PongMovement.pongPosition.y;

		pongY = Mathf.SmoothDamp (transform.position.y, pongY, ref ySpeed, delay);

		if (pongY + 40 > 220)
			pongY = 220 - 40;
		if (pongY - 40 < -220)
			pongY = -220 + 40;

		transform.position = new Vector3(transform.position.x, pongY, transform.position.z);
		
	}
}
