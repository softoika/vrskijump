using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameResult : MonoBehaviour {

	[SerializeField]
	private List<GameObject> removableObjects = new List<GameObject>();

	[SerializeField]
	private GameObject scoreBoard;

	[SerializeField]
	private GameObject fireworks;

	[SerializeField]
	private AudioSource fanfare;

	public void ShowGameResult()
	{
		// 視界の邪魔にならないよう指定のオブジェクトをすべて消す
		foreach (GameObject ro in removableObjects)
		{
			ro.SetActive(false);
		}

		//scoreBoardCanvas.enabled = true; // スコアボードを表示する
		scoreBoard.SetActive(true);
		fireworks.SetActive(true); // 花火エフェクトオン
		fanfare.Play();
	}
}
