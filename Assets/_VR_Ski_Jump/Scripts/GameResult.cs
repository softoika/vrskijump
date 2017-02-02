using UnityEngine;
using System.Collections;

public class GameResult : MonoBehaviour {

	[SerializeField]
	private GameObject shojiFolder;

	[SerializeField]
	private Canvas scoreBoardCanvas;

	[SerializeField]
	private GameObject fireworks;

	[SerializeField]
	private AudioSource fanfare;

	// Use this for initialization
	void Start () {
		scoreBoardCanvas.enabled = false;
	}

	public void ShowGameResult()
	{
		shojiFolder.SetActive(false); // 視界の邪魔にならないように障子をすべて消す
		scoreBoardCanvas.enabled = true; // スコアボードを表示する
		fireworks.SetActive(true); // 花火エフェクトオン
		fanfare.Play();
	}
}
