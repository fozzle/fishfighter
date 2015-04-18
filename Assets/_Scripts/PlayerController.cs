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
	public float groundRadius = 0.1f;
	public LayerMask whatIsGround;


	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// Check if on the ground
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, whatIsGround);
		if (grounded && Input.GetAxis ("Jump") > 0 && !jump) {
			jump = true;
		}
	}

	void FixedUpdate () {

		// cache horizontal
		float h = Input.GetAxis("HorizontalPlayer");
		if (rigidBody.position.y < -4.0) {
			rigidBody.position = new Vector3(0,1,0);
			rigidBody.velocity = Vector3.zero;

		}

		
		// Maybe uh, change this you dummy
		if (jump) {
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
			print(rigidBody.velocity);
			rigidBody.AddForce(Vector2.up * jumpForce);
			jump = false;
		}

		if (h * rigidBody.velocity.x < maxSpeed) {
			rigidBody.AddForce(Vector2.right * h * moveForce);
		}

		if (Mathf.Abs(rigidBody.velocity.x) > maxSpeed) {
			rigidBody.velocity = new Vector2(Mathf.Sign(rigidBody.velocity.x) * maxSpeed, rigidBody.velocity.y);
		}
	}
}
