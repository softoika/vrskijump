using UnityEngine;
using System.Collections;

/// <summary>
/// 飛距離(leap)を数える。Recording Start Lineを超えた後に計測開始。
/// プレイヤーは負のz軸方向に進んでいくので、Recording Start Lineのz座標からプレイヤーのz座標
/// を引いた差を飛距離とする
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class LeapCounter : MonoBehaviour {

	[SerializeField]
	private GameObject recordingStartLine;

	private bool isPassed; // プレイヤーがRecordingStartLineを超えたかどうか
	private Rigidbody rig;

	public float leap // 飛距離
	{
		get;
		private set;
	}

	// プレイヤーが着地したかどうか
	public bool isLanded
	{
		get;
		private set;
	}

	// Use this for initialization
	void Start ()
	{
		isPassed = false;
		isLanded = false;
		leap = -1;
		rig = GetComponent<Rigidbody>();
		rig.constraints = RigidbodyConstraints.FreezeRotation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// 飛距離を計算
		leap = recordingStartLine.transform.position.z - transform.position.z;
	}

	void OnTriggerEnter(Collider col)
	{
		// Recording Start Lineを超えたら計測開始
		if (col.gameObject == recordingStartLine)
		{
			isPassed = true;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		// Record Start Lineを超えた後に着地したらPlayerが動かないようにする
		if (isPassed)
		{
			isLanded = true;
			rig.isKinematic = true;
		}
	}
}
