using UnityEngine;
using System.Collections;

/// <summary>
/// プレイヤーの頭の位置が最初の立っている状態よりどのくらい低いか高いかで
/// 操作キャラクターのアクションを決める。
/// lowerLimitよりも低い姿勢を取れば滑走状態となり、lowerLimitを下回った状態で
/// upperLimitを上回ればジャンプすることができる。
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerState : MonoBehaviour {

	[SerializeField]
	private GameObject mainCamera;

	[SerializeField]
	private GameObject windEffect;


	[SerializeField]
	private AudioSource windAudio;

	[SerializeField]
	private AudioSource jumpAudio;


	[SerializeField]
	private float upperLimit = 0.0f;

	[SerializeField]
	private float lowerLimit = -0.2f;

	[SerializeField]
	private float jumpPower = 10;

	[SerializeField]
	private float slidingSpeed = 200; // 滑走速度

	private Vector3 initialCameraPosition;
	private Rigidbody playerRigid;
	private bool isSliding; // 滑走状態か

	// Use this for initialization
	void Start () {
		initialCameraPosition = mainCamera.transform.localPosition;
		isSliding = false;
		windEffect.SetActive(false);
		playerRigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		var cameraPos = mainCamera.transform.localPosition;
		Debug.Log("initPosY=" + initialCameraPosition.y + ", posY=" + cameraPos.y);

		// Main Cameraが初期位置よりlowerLimitだけ下がっていたら滑走状態となる
		if (cameraPos.y - initialCameraPosition.y < lowerLimit)
		{
			isSliding = true;
			if(!windAudio.isPlaying) windAudio.Play();
			windEffect.SetActive(true);
			// 滑走状態の加速
			//playerRigid.AddForce(new Vector3(0, -slidingSpeed, -slidingSpeed), ForceMode.Acceleration);

			Vector3 dir = playerRigid.velocity.normalized;
			Debug.Log(dir);
			playerRigid.AddForce(dir * slidingSpeed, ForceMode.Acceleration);
		}
		// 滑走状態のときにMain Cameraの高さが初期位置よりupperLimitだけ挙がっていたらジャンプできる
		else if (isSliding && 
		         cameraPos.y - initialCameraPosition.y >= upperLimit)
		{
			isSliding = false;
			windAudio.Stop();
			windEffect.SetActive(false);
			jumpAudio.Play();
			// ジャンプ
			playerRigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.VelocityChange);
		}
	}
}
