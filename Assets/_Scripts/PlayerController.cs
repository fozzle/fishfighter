using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	private bool jump = false;
	private bool jumpAvailable = false;
	private Rigidbody2D rigidBody;
	public float maxSpeed;
	public float moveForce;
	public float jumpForce;

	// Grounded doo doo
	private bool grounded = false;
	public Transform groundCheckLeft;
	public Transform groundCheckRight;
	public float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	public GameController gameController;

	public GameObject hookPrefab;
	private Hook hook;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		Vector3 hookPosition = new Vector3 (0, -2f, 0f);
		GameObject hookGameObject = (GameObject) Instantiate(hookPrefab, hookPosition, transform.rotation);
		hook = hookGameObject.GetComponent (typeof(Hook)) as Hook ;
	}
	
	// Update is called once per frame
	void Update () {
		// Check if on the ground
		grounded = Physics2D.Linecast(transform.position, groundCheckLeft.position, whatIsGround) || Physics2D.Linecast(transform.position, groundCheckRight.position, whatIsGround);
		if (Input.GetAxis ("Jump") <= 0) {
			jumpAvailable = true;
		}
		if (grounded && Input.GetAxis ("Jump") > 0 && !jump && jumpAvailable) {
			jump = true;
		}
	}


	void FixedUpdate () {

		// cache horizontal
		float h = Input.GetAxis("HorizontalPlayer")+Input.GetAxis("HorizontalKeys");
		//Debug.Log (h);
		if (rigidBody.position.y < -5.0) {
			rigidBody.position = new Vector3(0,1,0);
			rigidBody.velocity = Vector3.zero;
			gameController.modifyScore(1);
		}

		// jumps yo
		if (jump) {
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
			rigidBody.AddForce(Vector2.up * jumpForce);
			jump = false;
			jumpAvailable = false;
		}

		if (h * rigidBody.velocity.x < maxSpeed) {
			rigidBody.AddForce(Vector2.right * h * moveForce);
		}

		if (Mathf.Abs(rigidBody.velocity.x) > maxSpeed) {
			rigidBody.velocity = new Vector2(Mathf.Sign(rigidBody.velocity.x) * maxSpeed, rigidBody.velocity.y);
		}
	}
}
