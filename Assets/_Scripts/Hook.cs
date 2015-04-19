using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {

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
		
		SpawnedFish fish = other.gameObject.GetComponent<SpawnedFish> ();
		gameObject.GetComponent<Collider2D> ().enabled = false; 
		fish.onHooked ();

	}
	
}
