using UnityEngine;
using System.Collections;

public class ShojiDisabler : MonoBehaviour {

	[SerializeField]
	private GameObject shojiFolder;

	[SerializeField]
	private PlayerState playerState;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (playerState.isLanding)
		{
			shojiFolder.SetActive(false);
		}
	}
}
