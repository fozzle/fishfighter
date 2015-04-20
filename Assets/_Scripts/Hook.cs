using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {

	public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
//	void OnTriggerEnter2D(Collider2D other)
//	{
//		SpawnedFish fish = other.gameObject.GetComponent<SpawnedFish> ();
//		fish.onHooked ();
//	}

	void OnCollisionEnter2D(Collision2D other)
	{
		
		GameObject fish = other.gameObject;
		bool hooked = player.GetComponent<PlayerController> ().onHooked (fish);
		if (hooked) {
			fish.GetComponent<SpawnedFish> ().onHooked ();
			Destroy(fish);
			//gameObject.GetComponent<Collider2D> ().enabled = false;
		}

	}
	
}
