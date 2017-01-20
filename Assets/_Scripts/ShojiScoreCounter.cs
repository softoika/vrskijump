using UnityEngine;
using System.Collections;

public class ShojiScoreCounter : MonoBehaviour {

	[SerializeField]
	private AudioSource shojiSE;

	[SerializeField]
	private int scoreUnit = 30; // 1つ障子を破るごとに獲得できるスコア

	public int totalCount // 破った障子の数
	{
		get;
		private set;
	}

	public int totalScore // 障子を破ることによって得られた合計スコア
	{
		get;
		private set;
	}

	// Use this for initialization
	void Start () {
		totalScore = 0;
		totalCount = 0;
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Shoji")
		{
			totalScore += scoreUnit;
			totalCount++;

			col.gameObject.SetActive(false); // 障子を消す
			shojiSE.Play();               // 障子が破れるときの効果音
		}
	}
}
