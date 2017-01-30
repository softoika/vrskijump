using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Canvas))]
public class ESCMenu : MonoBehaviour{

	[SerializeField]
	private GameObject mainCamera;

	private OculusCameraMock oculusCameraMock;
	private Canvas menuCanvas;

	public void Start()
	{
		oculusCameraMock = mainCamera.GetComponent<OculusCameraMock>();
		menuCanvas = GetComponent<Canvas>();
		// メニューを閉じた状態で開始
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		menuCanvas.enabled = false;
	}

	/// <summary>
	/// Restartボタンが押されたときの処理
	/// </summary>
	public void OnClickRestart()
	{
		// 現在のシーンの再読込み
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	/// <summary>
	/// Quitボタンが押されたときの処理
	/// </summary>
	public void OnClickQuit()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#endif
		Application.Quit();
	}

	/// <summary>
	/// ポーズメニューを開く。ポーズメニューが開かれるとマウスのロックが解除されマウスカーソルを表示する
	/// ポーズメニューが開かれている状態では、マウスによる視点操作は無効となる
	/// →OculusCameraMock.OnOpenPauseMenu()
	/// </summary>
	public void OpenPauseMenu()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		menuCanvas.enabled = true;
		oculusCameraMock.OnOpenPauseMenu();
	}

	/// <summary>
	/// ポーズメニューを閉じる。ポーズメニューが閉じられるとマウスカーソルが画面中央にロックされ、
	/// マウスカーソルが非表示となる。
	/// 同時にマウスによる視点の操作が有効となる。→OculusCameraMock.OnClosePauseMenu()
	/// </summary>
	public void ClosePauseMenu()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		menuCanvas.enabled = false;
		oculusCameraMock.OnClosePauseMenu();
	}

	/// <summary>
	/// メニューが表示されていたらClosePauseMenu()を呼び出す。
	/// 表示されていなければOpenPauseMenu()を呼び出す
	/// </summary>
	public void TogglePauseMenu()
	{
		if (menuCanvas.enabled)
		{
			ClosePauseMenu();
		}
		else {
			OpenPauseMenu();
		}
	}
}
