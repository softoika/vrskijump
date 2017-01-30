using UnityEngine;
using System.Collections;

public class JumpTestMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.TransformDirection(Vector3.up) * 0.1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += transform.TransformDirection(Vector3.down) * 0.1f;
        }
    }
}
