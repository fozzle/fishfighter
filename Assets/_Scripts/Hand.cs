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

	// Use this for initialization
	void Start () {
		handTransform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		bool stabby = Input.GetButtonDown(stabButton);
		if (stabby) {
			Rigidbody2D fishBody = fish.GetComponent<Rigidbody2D>();
			Vector2 stabForce = new Vector2(handTransform.up.x, handTransform.up.y);
			stabForce = stabForce * stabForceBaseMagnitude * fishBody.mass * stabForceMultiplier;
			stabForce = Vector2.ClampMagnitude(stabForce, stabForceBaseMagnitude + (fishBody.mass * stabForceMultiplier));
			fishBody.AddForce(stabForce);
			Debug.Log ("stabby " + stabForce + " " + transform.up);
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
}
