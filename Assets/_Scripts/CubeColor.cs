using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class CubeColor : MonoBehaviour {
	private Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	public void ChangeColor(Color color)
	{
		rend.material.color = color;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
