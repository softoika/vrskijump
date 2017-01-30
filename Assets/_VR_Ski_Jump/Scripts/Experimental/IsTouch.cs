using UnityEngine;
using System.Collections;

public class IsTouch : MonoBehaviour {

	public AudioSource SE;

    private bool hitFlag = false; 
    private void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Shoji")
		{
			hitFlag = true;
		}
    }
   
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (hitFlag)
        {
            Debug.Log("hit!");
            hitFlag = false;
				
			SE.Play();
        }

    }
}
