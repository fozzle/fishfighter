using UnityEngine;
using System.Collections;

public class Deflection : MonoBehaviour {

	public float deflectionChance;
	public float deflectionForceMultiplier;
	public float deflectionTorque;
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag.Equals("Player1FishWeapon") || 
		    collision.gameObject.tag.Equals ("Player2FishWeapon")) {

			// Deflection
			float randVal = Random.value;
			Debug.Log(randVal);
			if (randVal < deflectionChance) {
				Debug.Log("DEFLECT");
				this.gameObject.transform.parent.gameObject.GetComponent<SliderJoint2D>().connectedBody = null;
				this.gameObject.transform.parent = null;
				this.gameObject.layer = LayerMask.NameToLayer("DisarmedFish");
				this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
				this.gameObject.GetComponent<Rigidbody2D>().AddForce(-deflectionForceMultiplier * collision.relativeVelocity);
				this.gameObject.GetComponent<Rigidbody2D>().AddTorque(deflectionTorque);
				player.GetComponent<PlayerController>().onDisarmed();
			}
		}
	}
}
