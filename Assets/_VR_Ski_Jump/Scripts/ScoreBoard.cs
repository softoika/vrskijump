using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBoard : MonoBehaviour {

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private Text scoreText;

	private PlayerState playerState;
	private LeapCounter leapCounter;
	private ShojiScoreCounter shojiScoreCounter;

	// Use this for initialization
	void Start ()
	{
		playerState = player.GetComponent<PlayerState>();
		leapCounter = player.GetComponent<LeapCounter>();
		shojiScoreCounter = player.GetComponent<ShojiScoreCounter>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// スコアを計算してテキストに入れておく
		int shojiCount = shojiScoreCounter.totalCount;
		int shojiScore = shojiScoreCounter.totalScore;
		float leap = leapCounter.leap;
		int totalScore = (int)leap + shojiScore;

		scoreText.text = string.Format
		(
			"飛距離　　　{0, -4:F1}m\n" +
            "障子の数　　 {1, -4}枚\n" +
            "障子スコア     {2, -4}点\n" +
			"合計スコア     {3, -4}点"
			, leap, shojiCount, shojiScore, totalScore
     	);
	}
}
