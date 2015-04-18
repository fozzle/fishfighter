using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool jump = false;
	private Rigidbody2D rigidBody;
	public float maxSpeed;
	public float moveForce;
	public float jumpForce;

	// Grounded doo doo
	private bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;


	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// Maybe uh, change this you dummy
		if (grounded && Input.GetKeyDown(KeyCode.UpArrow)) {
			Debug.Log ("Jump!");
			rigidBody.AddForce(Vector2.up * jumpForce);
		}
	}

	void FixedUpdate () {
		// Check if on the ground
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		Debug.Log (grounded);
		// cache horizontal
		float h = Input.GetAxis("Horizontal");

		if (h * rigidBody.velocity.x < maxSpeed) {
			rigidBody.AddForce(Vector2.right * h * moveForce);
		}

		if (Mathf.Abs(rigidBody.velocity.x) > maxSpeed) {
			rigidBody.velocity = new Vector2(Mathf.Sign(rigidBody.velocity.x) * maxSpeed, rigidBody.velocity.y);
		}
	}
}
