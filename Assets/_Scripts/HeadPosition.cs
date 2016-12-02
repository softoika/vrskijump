using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class HeadPosition : MonoBehaviour {
	private Text text;
	public GameObject cam;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "" + cam.transform.localPosition.y;
	}
}
