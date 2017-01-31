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
	private GameObject recordingStartLine;

	[SerializeField]
	private GameObject heightLimitArea;

	[SerializeField]
	private AudioSource windSE;

	[SerializeField]
	private AudioSource jumpSE;

	[SerializeField]
	private AudioSource landSE;


	[SerializeField]
	private float upperLimit = 0.0f; // ジャンプの判定に用いる高さの閾値

	[SerializeField]
	private float lowerLimit = -0.2f;// 滑走状態の判定に用いる低さの閾値

	[SerializeField]
	private float jumpPower = 10;

	[SerializeField]
	private float slidingSpeed = 200; // 滑走速度

	private Rigidbody playerRigid;
	private Vector3 initialCameraPosition; // カメラの初期位置。この位置を基準に滑走状態やジャンプ判定をする
	private bool isSliding;                // 滑走状態か
	private bool isPassed;                 // RecordingStartLineを越えたか
	private bool isOver;                 // 高度制限を越えたか

	// プレイヤーが着地したかどうか
	public bool isLanding
	{
		get;
		private set;
	}

	// Use this for initialization
	void Start () 
	{
		initialCameraPosition = mainCamera.transform.localPosition;
		isSliding = false;
		windEffect.SetActive(false);
		playerRigid = GetComponent<Rigidbody>();
		playerRigid.constraints = RigidbodyConstraints.FreezeRotation;
		isPassed = false;
		isLanding = false;
		isOver = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		var cameraPos = mainCamera.transform.localPosition;

		// Main Cameraが初期位置よりlowerLimitだけ下がっていたら滑走状態となる
		if (!isLanding &&
			cameraPos.y - initialCameraPosition.y < lowerLimit)
		{
			isSliding = true;
			if (!windSE.isPlaying) windSE.Play();
			windEffect.SetActive(true);

			//速度出ている方向に加速する
			Vector3 dir = playerRigid.velocity.normalized;
			playerRigid.AddForce(dir * slidingSpeed, ForceMode.Acceleration);
		}
		// 滑走状態のときにMain Cameraの高さが初期位置よりupperLimitだけ挙がっていたらジャンプできる
		else if (isSliding && !isLanding &&
				 cameraPos.y - initialCameraPosition.y >= upperLimit)
		{
			isSliding = false;
			windSE.Stop();
			windEffect.SetActive(false);
			jumpSE.Play();

			// 高度制限以下ならジャンプ
			if (!isOver)
			{
				
				playerRigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.VelocityChange);
			}
		}
		// 計測開始後の着地をしているとき
		else if (isLanding)
		{
			windSE.Stop();
			windEffect.SetActive(false);
		}
	}


	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject == recordingStartLine)
		{
			isPassed = true;
		}
		else if (col.gameObject == heightLimitArea)
		{
			isOver = true;
		}
	}
	void OnTriggerExit(Collider col)
	{
		if (col.gameObject == heightLimitArea)
		{
			isOver = false;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		// Record Start Lineを超えた後に着地したらPlayerが動かないようにする
		if (isPassed)
		{
			isLanding = true;
			playerRigid.isKinematic = true;
			// 着地効果音再生
			landSE.Play();
		}
	}
}
