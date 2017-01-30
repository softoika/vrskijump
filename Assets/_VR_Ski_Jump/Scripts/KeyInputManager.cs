using UnityEngine;
using System.Collections;

public class KeyInputManager : MonoBehaviour {

	[SerializeField]
	private GameObject escMenuObject;
	[SerializeField]
	private GameObject mainCamera;

	[SerializeField]
	private GameObject startingFloor;

	private ESCMenu escMenu;
	// Use this for initialization
	void Start () {
		escMenu = escMenuObject.GetComponent<ESCMenu>();
	}

	// Update is called once per frame
	void Update()
	{
		var pos = mainCamera.transform.localPosition;

		// ESCキーが押されたときはポーズメニューの表示/非表示を行う
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			escMenu.TogglePauseMenu();
		}
		// スペースキーを押すと頭の位置が下がる(滑走状態に入る)
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			pos.y -= 0.3f;
		}
		// スペースキーを話すと頭の位置が上がる(ジャンプする)
		else if (Input.GetKeyUp(KeyCode.Space))
		{
			pos.y += 0.3f;
		}
		else if (Input.GetKeyDown(KeyCode.Return))
		{
			startingFloor.SetActive(false);
		}

		mainCamera.transform.localPosition = pos;
	}
}
