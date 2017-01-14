using UnityEngine;
using System.Collections;

public class chakuti : MonoBehaviour {

    public GameObject gameObject;
	public GameObject chakuchiParticle;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision col)
    {
        if (kesoku.f==1) {
            // 移動しない設定
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

            gameObject.SetActive(true);
			chakuchiParticle.SetActive(true);
        }
    }
}
