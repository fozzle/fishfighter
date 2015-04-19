using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

	private Transform transform;
	private GameObject fish;
	public Transform parentTransform;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform>();
		fish = GameObject.Find ("Fish");
	}
	
	// Update is called once per frame
	void Update () {


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
