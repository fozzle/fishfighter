using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public int score;
	private GameObject myTextgameObject;
	private Text ourComponent;   
	// Use this for initialization
	void Start () {
		myTextgameObject = GameObject.Find("ScoreText");
		ourComponent = myTextgameObject.GetComponent<Text>();
		score = 10;
		ourComponent.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void modifyScore(int modifier){
		score += modifier;
		ourComponent.text = score.ToString();
	}
}
