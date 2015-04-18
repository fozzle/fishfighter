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
		Vector3 inputDirection = new Vector3(Input.GetAxis ("HorizontalArm"), Input.GetAxis ("VerticalArm"), 0);

		transform.RotateAround(new Vector3(parentTransform.position.x, parentTransform.position.y, 0), inputDirection, rotationSpeed * Time.deltaTime);
	}
}
