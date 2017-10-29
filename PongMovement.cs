using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongMovement : MonoBehaviour {
	[SerializeField]
	private float pongAngle = 0f;

	private float pongSpeed = 2f;
	private const float MAXSPEED = 10f;
	private const float MINSPEED = 2f;
	[SerializeField]
	private int xDir = 1;
	[SerializeField]
	private int yDir = 1;
	public static Vector2 pongPosition;

	// Use this for initialization
	void Start () {
		pongAngle = Random.Range (0, 359);
		pongSpeed = Random.Range (2f, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (!CounterScript.isRunning () && GameManager1P.running) {
			if (transform.position.y + 16 > 225)
				yDir *= -1;
			if (transform.position.y - 16 < -225)
				yDir *= -1;
//			if (transform.position.x + 16 > 325)
//				xDir *= -1;
//			if (transform.position.x - 16 < -325)
//				xDir *= -1;

			transform.Translate (xDir * pongSpeed * Mathf.Cos (Mathf.Deg2Rad * pongAngle), yDir * pongSpeed * Mathf.Sin (Mathf.Deg2Rad * pongAngle), 0f, Space.Self);
		}

		if (!GameManager1P.running && Input.GetKeyDown(KeyCode.Space)) {
			pongAngle = Random.Range (0, 359);
			pongSpeed = Random.Range (2f, 3f);
			transform.position = new Vector2 (0f, 0f);
			CounterScript.setStartCounter ();
			GameManager1P.running = true;
		}

		pongSpeed -= Time.deltaTime / 10f;
		pongSpeed = Mathf.Max (MINSPEED, pongSpeed);

		pongPosition = transform.position;

	}
	void OnCollisionEnter2D (Collision2D other) {
		
		if (other.collider.tag == "1P") {
			xDir = -1;
			pongAngle = yDir * (other.collider.transform.position.y - transform.position.y) * 2 + 180;
			pongSpeed = Mathf.Abs((transform.position.y - other.collider.transform.position.y) / 40 * 10f);
		}

		if (other.collider.tag == "2P") {
			xDir = 1;
			pongAngle = yDir * (other.collider.transform.position.y - transform.position.y) * 2 + 180;
			pongSpeed = Mathf.Abs((transform.position.y - other.collider.transform.position.y) / 40 * 10f);
		}
	}
}
