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
		updateScore(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void modifyScore(int modifier){
		updateScore(score + modifier);
	}

	void updateScore(int newScore){
		score = newScore;
		ourComponent.text = score.ToString();
	}
}
