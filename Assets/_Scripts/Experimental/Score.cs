using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	public int score = 0;
	public Text scoreText;
	// Use this for initialization
	void Start () {
		Debug.Log(scoreText.text);
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score:" + score;
	}
}
