using UnityEngine;
using System.Collections;

public class SpawnedFish : MonoBehaviour {

	public float speed;
	private float speedMax = .4f;
	private float speedRange = .1f;
	public int direction = 0;
	

	private int fishSize;
	// Use this for initialization
	void Start () {
		setSize (1);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x + (direction*speed), transform.position.y);
		if ((direction == 1 && transform.position.x > 6) || (direction == -1 && transform.position.x < -6 )) {
			setDirection(direction * -1);
		}
		// if (Mathf.Abs (transform.position.x) > 10f) {
		// 	DestroyObject(gameObject);
		// }
	}

	public void setDirection(int newDirection){
		transform.localScale = new Vector2((float)newDirection * Mathf.Abs(transform.localScale.x), transform.localScale.y);
		direction = newDirection;
		//Debug.Log(newDirection);
	}

	public void setSize(int newSize){
		speed = (speedMax - ((float)newSize * speedRange) - (.1f * Random.value)) * 0.05f;
		//Debug.Log (speed);
		float newScale = .5f + (.3f * (float)newSize);
		transform.localScale = new Vector2( newScale * transform.localScale.x, newScale * transform.localScale.y);
	}
}
