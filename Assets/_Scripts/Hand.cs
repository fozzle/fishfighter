using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

	private Transform transform;
	public float stabForceMagnitude;
	public GameObject fish;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		bool stabby = Input.GetButtonDown("Stab");
		if (stabby) {
			Vector2 stabForce = new Vector2(transform.up.x, transform.up.y);
			stabForce = stabForce * stabForceMagnitude;
			Debug.Log("stabbyscale" + stabForce + " " + stabForceMagnitude);
			Vector2.ClampMagnitude(stabForce, stabForceMagnitude);
			fish.GetComponent<Rigidbody2D>().AddForce(stabForce);
			Debug.Log ("stabby " + stabForce + " " + transform.up);
		}
	}

	void FixedUpdate() {
		float hInput = Input.GetAxis("HorizontalArm") + Input.GetAxis ("HorizontalArmKeys");
		float vInput = Input.GetAxis ("VerticalArm") + Input.GetAxis ("VerticalArmKeys");
		if (hInput == 0 && vInput == 0) {
			return;
		}

		float angle = -Mathf.Atan2(hInput, vInput);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg), rotationSpeed * Time.deltaTime);
		//fish.transform.rotation = Quaternion.RotateTowards(fish.transform.rotation, Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg - 90), rotationSpeed *.5f * Time.deltaTime);
	}
}
