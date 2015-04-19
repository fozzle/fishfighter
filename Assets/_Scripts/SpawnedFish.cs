using UnityEngine;
using System.Collections;

public class SpawnedFish : MonoBehaviour {

	private float speed;
	private float speedMin = 1f;
	private float speedRange = 1f;
	public int direction = 0;
	// Use this for initialization
	void Start () {
		//Debug.Log ("spawned!");
		speed = ((Random.value * speedRange) + speedMin) * .01f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x + (direction*speed), transform.position.y);
		if (Mathf.Abs (transform.position.x) > 10f) {
			DestroyObject(gameObject);
		}
	}

	public void setDirection(int newDirection){
		transform.localScale = new Vector2(newDirection * transform.localScale.x, transform.localScale.y);
		direction = newDirection;
		//Debug.Log(newDirection);
	}
}
