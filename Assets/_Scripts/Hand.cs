using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour {

	private Transform transform;
	public Transform parentTransform;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {


	}

	void FixedUpdate() {
		float hInput = Input.GetAxis("HorizontalArm");
		float vInput = Input.GetAxis ("VerticalArm");
		if (hInput == 0 && vInput == 0) {
			return;
		}

		float angle = -Mathf.Atan2(hInput, vInput);
		//Debug.Log(angle * Mathf.Rad2Deg);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg), rotationSpeed * Time.deltaTime);
	}
}
