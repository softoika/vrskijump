using UnityEngine;
using System.Collections;

public class CameraTest : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update()
	{
		var p = this.transform.position;
		var r = this.transform.rotation;
		Debug.Log("position.y=" + p.y);
		Debug.Log("rotation(" + r.x + ", " + r.y + ", " + r.z + ")");
	}
	/*
	void OnGUI()
	{
		var p = this.transform.position;
		var r = this.transform.rotation;
		GUI.TextField(new Rect(10, 10, 100, 100), ("position.y=" + p.y));
		GUI.TextField(new Rect(10, 110, 100, 100), "rotation(" + r.x + ", " + r.y + ", " + r.z + ")");
	}
	*/
}
