using UnityEngine;
using System.Collections;

/// <summary>
/// Oculus Riftを装着してないPCで動作確認をするための代用品
/// ESCキーでマウス操作をオフにする
/// 左クリックでマウス操作をオンにする
/// </summary>
public class OculusCameraMock : MouseController {

	[SerializeField]
	private GameObject mainCamera;
	[SerializeField]
	private float sensitivity = 1f;
	[SerializeField]
	private float yMinLimit = -90f;
	[SerializeField]
	private float yMaxLimit = 90f;

	public override IEnumerator UpdateRotation(){
		float rotationY = 0f;
		yield return null;

		while (true) {
			float rotationX = mainCamera.transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * sensitivity;
			rotationY -= Input.GetAxis ("Mouse Y") * sensitivity;
			rotationY = ClampAngle (rotationY, yMinLimit, yMaxLimit);

			mainCamera.transform.localEulerAngles = new Vector3 (rotationY, rotationX, 0f);

			yield return null;
		}
	}

	private float ClampAngle(float angle, float min, float max){
		if (angle < -360f) angle += 360;
		if (angle > 360f)  angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
}
