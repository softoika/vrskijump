using UnityEngine;
using System.Collections;

public abstract class MouseController : MonoBehaviour {

	protected IEnumerator update;

	private bool isActivated; // カメラのマウス操作が有効かどうか

	public void Start(){
		update = UpdateRotation ();
		StartCoroutine (update);
	}

	public abstract IEnumerator UpdateRotation ();

	public void OnOpenPauseMenu()
	{
		// UpdateRotation()の処理を中断させる=>マウスによる視点操作を無効にする
		StopCoroutine(update);
	}
	public void OnClosePauseMenu()
	{
		// UpdateRotation()の処理を再開させる=>マウスによる視点操作を有効にする
		StartCoroutine(update);
	}
}
