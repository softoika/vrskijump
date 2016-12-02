using UnityEngine;
using System.Collections;

public class PlayerSideMove : MonoBehaviour {
	public GameObject cam;
	public GameObject playerSphere;
	public float moveThreshold = 0.2f;
	public float movePower = 1;

	private Rigidbody psRigid;
	private float startPosX;

	// Use this for initialization
	void Start () {
		startPosX = cam.transform.localPosition.x;
		Debug.Log("startPoxX:" + startPosX);
		psRigid = playerSphere.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float posX = transform.localPosition.x;
		if (posX - startPosX > moveThreshold)//左
		{
			Debug.Log("左:" + posX);
			Debug.Log("左境界:" + moveThreshold);
			psRigid.AddForce(new Vector3(movePower, 0, 0), ForceMode.VelocityChange);
		}
		else if (posX - startPosX < -moveThreshold)//右
		{
			Debug.Log("右:" + (posX-startPosX));
			Debug.Log("右境界:" + -moveThreshold);
			psRigid.AddForce(new Vector3(-movePower, 0, 0), ForceMode.VelocityChange);
		}
	}
}
