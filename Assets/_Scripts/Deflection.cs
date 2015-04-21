using UnityEngine;
using System.Collections;

public class Deflection : MonoBehaviour {

	public float deflectionChance;
	public float deflectionForceMultiplier;
	public float deflectionTorque;
	public GameObject player;
	private AudioSource audioSource;
	private bool isInitialHit;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		isInitialHit = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Rigidbody2D>().position.y < -5.0) {
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if ((collision.gameObject.tag.Equals("Player1FishWeapon") || 
		    collision.gameObject.tag.Equals ("Player2FishWeapon")) &&
		    isInitialHit) {

			isInitialHit = false;
			// Deflection
			float randVal = Random.value;
			Debug.Log(randVal);
			if (randVal < deflectionChance) {
				Debug.Log("DEFLECT");
				this.gameObject.transform.parent.gameObject.GetComponent<SliderJoint2D>().connectedBody = null;
				player.GetComponent<PlayerController>().ghostHand.GetComponent<Hand>().fish = null;
				this.gameObject.transform.parent = null;
				this.gameObject.layer = LayerMask.NameToLayer("DisarmedFish");
				this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
				this.gameObject.GetComponent<Rigidbody2D>().AddForce(-deflectionForceMultiplier * collision.relativeVelocity);
				this.gameObject.GetComponent<Rigidbody2D>().AddTorque(deflectionTorque);
				player.GetComponent<PlayerController>().onDisarmed();

				// play disarm sound
				audioSource.Play();
			}
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		if (collision.gameObject.tag.Equals("Player1FishWeapon") || 
		     collision.gameObject.tag.Equals ("Player2FishWeapon")) {
			isInitialHit = true;
		}
	}
}
