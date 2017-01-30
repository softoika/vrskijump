using UnityEngine;
using System.Collections;

/// <summary>
/// Oculus Riftを装着してないPCで動作確認をするための代用品
/// ESCキーでマウス操作をオフにする
/// 左クリックでマウス操作をオンにする
/// </summary>
[RequireComponent(typeof(Camera))]
public class OculusCameraMock : MouseController {

	[SerializeField]
	private float sensitivity = 1f;
	[SerializeField]
	private float yMinLimit = -90f;
	[SerializeField]
	private float yMaxLimit = 90f;

	/// <summary>
	/// マウス操作で視点の操作をする
	/// </summary>
	public override IEnumerator UpdateRotation(){
		float rotationY = 0f;
		yield return null;

		while (true) {
			float rotationX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * sensitivity;
			rotationY -= Input.GetAxis ("Mouse Y") * sensitivity;
			rotationY = ClampAngle (rotationY, yMinLimit, yMaxLimit);

			transform.localEulerAngles = new Vector3 (rotationY, rotationX, 0f);

			yield return null;
		}
	}

	private float ClampAngle(float angle, float min, float max){
		if (angle < -360f) angle += 360;
		if (angle > 360f)  angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
}
