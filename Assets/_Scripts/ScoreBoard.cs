using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Canvas))]
public class ScoreBoard : MonoBehaviour {

	[SerializeField]
	private GameObject player;
	[SerializeField]
	private Text scoreText;

	private LeapCounter leapCounter;
	private Canvas scoreBoardCanvas;

	// Use this for initialization
	void Start ()
	{
		leapCounter = player.GetComponent<LeapCounter>();
		scoreBoardCanvas = GetComponent<Canvas>();
		scoreBoardCanvas.enabled = false; // スコアボードを隠しておく
	}
	
	// Update is called once per frame
	void Update ()
	{
		// 着地後ならスコアボードを表示する
		if (leapCounter.isLanded)
		{
			scoreText.text = string.Format("{0:F1}m", leapCounter.leap);
			scoreBoardCanvas.enabled = true;
		}
	}
}
