using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class kesoku : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject Pleyer;

    public float hikyori = 0;
    public Text hikyoriText;

    Vector3 kabe = Vector3.zero;
    Vector3 pos;

    public static int f = 0;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        pos = Pleyer.transform.position;

        hikyori = kabe.z - pos.z;
        hikyoriText.text = hikyori + "m";
    }

    void OnTriggerEnter(Collider col)
    {
        kabe = this.transform.position;
        
        if (col.gameObject.CompareTag("keisoku"))
		{
            //hikyori = kabe.z - pos.z;

            // gameObject.SetActive(true);

            f = 1;
        }

    }
}
