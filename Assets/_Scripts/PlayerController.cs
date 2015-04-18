using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool jump = false;
	private Rigidbody2D rigidBody;
	public float maxSpeed;
	public float moveForce;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		// cache horizontal
		float h = Input.GetAxis("Horizontal");

		if (h * rigidBody.velocity.x < maxSpeed) {
			rigidBody.AddForce(Vector2.right * h * moveForce);
		}

		if (Mathf.Abs(rigidBody.velocity.x) > maxSpeed) {
			rigidBody.velocity = new Vector2(Mathf.Sign(rigidBody.velocity.x) * maxSpeed, rigidBody.velocity.y);
		}

		if (jump) {
			rigidBody.AddForce(Vector2.up * 3);

			jump = false;
		}
	}
}
