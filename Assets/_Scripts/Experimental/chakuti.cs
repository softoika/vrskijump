using UnityEngine;
using System.Collections;

public class chakuti : MonoBehaviour {

    public GameObject scoreBoard;
	public GameObject chakuchiParticle;
	private Rigidbody rig;
	private Canvas scoreBoardCanvas;

    // Use this for initialization
    void Start () {
		rig = GetComponent<Rigidbody>();
		scoreBoardCanvas = scoreBoard.GetComponent<Canvas>();
		scoreBoardCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision col)
    {
        if (kesoku.f==1) {
			// 移動しない設定
			rig.isKinematic = true;

			scoreBoardCanvas.enabled = true;
			chakuchiParticle.SetActive(true);
        }
    }
}
