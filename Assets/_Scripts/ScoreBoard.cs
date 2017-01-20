using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Canvas))]
public class ScoreBoard : MonoBehaviour {

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private Text scoreText;

	private PlayerState playerState;
	private LeapCounter leapCounter;
	private Canvas scoreBoardCanvas;

	// Use this for initialization
	void Start ()
	{
		playerState = player.GetComponent<PlayerState>();
		leapCounter = player.GetComponent<LeapCounter>();
		scoreBoardCanvas = GetComponent<Canvas>();
		scoreBoardCanvas.enabled = false; // スコアボードを隠しておく
	}
	
	// Update is called once per frame
	void Update ()
	{
		// 着地後ならスコアボードを表示する
		if (playerState.isLanded)
		{
			scoreText.text = string.Format("{0:F1}m", leapCounter.leap);
			scoreBoardCanvas.enabled = true;
		}
	}
}
