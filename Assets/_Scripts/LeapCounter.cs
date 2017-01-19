using UnityEngine;
using System.Collections;

/// <summary>
/// 飛距離(leap)を数える。
/// プレイヤーは負のz軸方向に進んでいくので、Recording Start Lineのz座標からプレイヤーのz座標
/// を引いた差を飛距離とする
/// </summary>
public class LeapCounter : MonoBehaviour {

	[SerializeField]
	private GameObject recordingStartLine;

	public float leap // 飛距離
	{
		get;
		private set;
	}

	// Use this for initialization
	void Start ()
	{
		leap = -1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// 飛距離を計算
		leap = recordingStartLine.transform.position.z - transform.position.z;
	}
}
