using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    
    GameObject refObj;

    public GameObject a;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    }
    void OnTriggerEnter(Collider col)
    {
        // 別のオブジェクトのスクリプトを参照する場合
        Score sco = refObj.GetComponent<Score>();
        Debug.Log("hit");
        if (col.gameObject.CompareTag("tama"))
        {
            Debug.Log("desu");
            sco.score += 1;
            Destroy(a);
        }
    }
}