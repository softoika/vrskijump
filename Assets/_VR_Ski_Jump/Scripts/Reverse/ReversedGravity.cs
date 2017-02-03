using UnityEngine;
using System.Collections;

public class ReversedGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3(0, 9.8f, 0);
	}

}
