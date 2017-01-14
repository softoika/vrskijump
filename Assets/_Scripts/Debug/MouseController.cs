using UnityEngine;
using System.Collections;

public abstract class MouseController : MonoBehaviour {

	protected IEnumerator update;

	private bool isActivated; // マウス操作が有効かどうか

	public void Start(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		isActivated = true;
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
			StopCoroutine (update);
		}
		else if (Input.GetButtonDown("Cancel") && !isActivated) // マウス操作無効状態でESC押された
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			isActivated = true;
			StartCoroutine (update);
		}
	}
}
