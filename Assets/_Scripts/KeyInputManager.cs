using UnityEngine;
using System.Collections;

public class KeyInputManager : MonoBehaviour {

	[SerializeField]
	private GameObject escMenuObject;

	private ESCMenu escMenu;
	// Use this for initialization
	void Start () {
		escMenu = escMenuObject.GetComponent<ESCMenu>();
	}
	
	// Update is called once per frame
	void Update () {

		// ESCキーが押されたときはポーズメニューの表示/非表示を行う
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			escMenu.TogglePauseMenu();
		}
	}
}
