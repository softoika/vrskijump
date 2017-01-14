using UnityEngine;
using System.Collections;

public abstract class MouseController : MonoBehaviour {

	protected IEnumerator update;

	[SerializeField]
	private GameObject escMenu;

	private bool isActivated; // カメラのマウス操作が有効かどうか

	public void Start(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		isActivated = true;
		escMenu.SetActive(false);
		update = UpdateRotation ();
		StartCoroutine (update);
	}

	public abstract IEnumerator UpdateRotation ();

	public void Update(){
		// ESCトグル
		if (Input.GetButtonDown ("Cancel") && isActivated) // マウス操作有効状態でESC押された
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			isActivated = false;
			escMenu.SetActive(true);
			StopCoroutine (update);
		}
		else if (Input.GetButtonDown("Cancel") && !isActivated) // マウス操作無効状態でESC押された
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			isActivated = true;
			escMenu.SetActive(false);
			StartCoroutine (update);
		}
	}
}
