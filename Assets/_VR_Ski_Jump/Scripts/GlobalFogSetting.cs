using UnityEngine;
using System.Collections;

/// <summary>
/// Starndard AssetsのGlobal Fogの設定
/// </summary>
public class GlobalFogSetting : MonoBehaviour {

	[SerializeField]
	private Color fogColor;
	void Start () {
		// フォグカラーの設定
		RenderSettings.fogColor = fogColor;
	}
}
