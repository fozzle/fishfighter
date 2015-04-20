using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	private int[] scores;
	private GameObject[] scoreTexts;
	private Text ourComponent;   
	// Use this for initialization
	void Start () {
		scores = new int[] {0,0};
		scoreTexts = new GameObject[] {GameObject.Find("Player1ScoreText"), GameObject.Find("Player2ScoreText")};
		refreshScores ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void modifyScore(int index, int modifier){
		scores[index] = scores[index] + modifier;
		refreshScores ();
	}	

	public void refreshScores(){
		for (int i = 0; i < scores.Length; i++) {
			scoreTexts [i].GetComponent<Text> ().text = scores [i].ToString ();
		}
	}
}
