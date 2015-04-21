using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

	private Transform handTransform;
	public float stabForceBaseMagnitude;
	public GameObject fish;
	public float stabForceMultiplier;
	public float rotationSpeed;
	public string horizontalArmAxis;
	public string verticalArmAxis;
	public string horizontalArmKeys;
	public string verticalArmKeys;
	public string stabButton;

	public GameObject handSprite;
	public GameObject fishInHandPrefab;
	public GameObject player;

	// Use this for initialization
	void Start () {
		handTransform = GetComponent<Transform>();
		handSprite = transform.Find ("handSprite").gameObject;

	}

	// Update is called once per frame
	void Update () {
		bool toss = Input.GetButtonDown ("Cancel");
//		if (toss && fish) {
//			Destroy (fish);
//			player.GetComponent<PlayerController>().onDisarmed();
//		}
		bool stabby = Input.GetButtonDown(stabButton);
		if (stabby && fish) {
			Rigidbody2D fishBody = fish.GetComponent<Rigidbody2D>();
			Vector2 stabForce = new Vector2(handTransform.up.x, handTransform.up.y);
			stabForce = stabForce * stabForceBaseMagnitude * fishBody.mass * stabForceMultiplier;
			stabForce = Vector2.ClampMagnitude(stabForce, stabForceBaseMagnitude + (fishBody.mass * stabForceMultiplier));
			fishBody.velocity = stabForce + player.GetComponent<Rigidbody2D>().velocity;

		}

	}

	void FixedUpdate() {
		float hInput = Input.GetAxis(horizontalArmAxis) + Input.GetAxis(horizontalArmKeys);
		float vInput = Input.GetAxis(verticalArmAxis) + Input.GetAxis(verticalArmKeys);
		if (hInput == 0 && vInput == 0) {
			return;
		}

		float angle = -Mathf.Atan2(hInput, vInput);
		handTransform.rotation = Quaternion.RotateTowards(handTransform.rotation, Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg), rotationSpeed * Time.deltaTime);
		//fish.transform.rotation = Quaternion.RotateTowards(fish.transform.rotation, Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg - 90), rotationSpeed *.5f * Time.deltaTime);
	}

	public bool attachFish(GameObject newfish){
		if (fish) {
			return false;
		}
		generateNewFish ();
		return true;
	}

	public void generateNewFish(){
		GameObject newFishInHand = ( GameObject) Instantiate(fishInHandPrefab, Vector3.zero, transform.rotation);

		// make fish a child of handSprite
		newFishInHand.transform.parent = handSprite.transform;
		newFishInHand.transform.localPosition = new Vector3 (0, 0, 0);
		newFishInHand.transform.localRotation = Quaternion.Euler (0, 0, -90);
		newFishInHand.layer = LayerMask.NameToLayer(player.GetComponent<PlayerController>().fishLayer);
		newFishInHand.tag = player.GetComponent<PlayerController>().fishLayer;
		newFishInHand.GetComponent<Deflection>().player = player;
		newFishInHand.GetComponent<Rigidbody2D>().mass = Random.value * 4 + 2;

		// attach fish to slider joint of handSprite
		handSprite.GetComponent <SliderJoint2D> ().connectedBody = newFishInHand.GetComponent<Rigidbody2D> ();

		// attach fish to spring joint of handSprite
		handSprite.GetComponent <SpringJoint2D> ().connectedBody = newFishInHand.GetComponent<Rigidbody2D> ();
		fish = newFishInHand;
	}
}
