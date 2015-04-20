using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	private bool jump = false;
	private bool jumpAvailable = false;
	private Rigidbody2D rigidBody;
	private Animator anim;
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
	private GameObject hook;

	public GameObject ghostHand;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
		//spawnHook ();

		ghostHand = transform.Find ("ghostHand").gameObject;
		ghostHand.GetComponent<Hand>().player = gameObject;
		ghostHand.GetComponent<Hand>().generateNewFish ();

		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		// Check if on the ground
		grounded = Physics2D.Linecast(transform.position, groundCheckLeft.position, whatIsGround) || Physics2D.Linecast(transform.position, groundCheckRight.position, whatIsGround);
		//Debug.Log (grounded);
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

		anim.SetFloat("Speed", Mathf.Abs(h));

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

	public bool	onHooked(GameObject fish){
		bool hooked = ghostHand.GetComponent<Hand>().attachFish (fish);
		if (hooked) {
			Destroy (hook);
		}
		return hooked;
	}
	
	public bool onDisarmed(){
		spawnHook ();
		return true;
	}
	
	public void spawnHook(){

		Vector3 hookPosition = new Vector3 (0, -2f, 0f);
		hook = (GameObject)Instantiate (hookPrefab, hookPosition, transform.rotation);
		hook.GetComponent<Hook>().player = gameObject;
		hook.transform.parent = gameObject.transform;
		hook.transform.localPosition = new Vector3 (0, -4, 0);
		hook.GetComponent<SpriteRenderer> ().color = gameObject.transform.Find ("Body").gameObject.GetComponent<SpriteRenderer> ().color;
	}
}
