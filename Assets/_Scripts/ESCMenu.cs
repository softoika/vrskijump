using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ESCMenu : MonoBehaviour{

	public void OnClickRestart()
	{
		// 現在のシーンの再読込み
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void OnClickQuit()
	{
		
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
		Application.Quit();

	}
}
