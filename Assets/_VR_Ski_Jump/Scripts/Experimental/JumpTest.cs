using UnityEngine;
using System.Collections;

public class JumpTest : MonoBehaviour
{

    public GameObject cameraObject;
	public GameObject colorCube;
	public GameObject playerSphere;
	public GameObject Particle;

	public AudioSource BGM;
	public AudioSource SE;
	private CubeColor cubeColor;
	private Rigidbody psRigid;

	public float jougen = 0.3f;
	public float kagen = -0.3f;
	public float jumpPower = 50;
	public float syagamiSpeed = 10;
	private float startPosY;

    int f = 0;
    
    // Use this for initialization
    void Start () {
		startPosY = cameraObject.transform.localPosition.y;
		Debug.Log("startPosY:" + startPosY);
		psRigid = playerSphere.GetComponent<Rigidbody>();
		Particle.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		var pos = cameraObject.transform.localPosition;

        switch (f)
        {
            case 0:
				if (pos.y - startPosY < kagen)
                {
                    f = 1;
					Debug.Log("しゃがんだ" + pos.y + ":" + kagen);
					psRigid.AddForce(new Vector3(0, -syagamiSpeed, -syagamiSpeed), ForceMode.Acceleration);
					cubeColor.ChangeColor(Color.blue);

					Particle.SetActive(true);
					BGM.Play();
                }
                break;

            case 1:
				if (pos.y  -startPosY > jougen)
                {
                    f = 0;
                    Debug.Log("jump!!");
					cubeColor.ChangeColor(Color.red);
					psRigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.VelocityChange);
					//startPosY = cameraObject.transform.localPosition.y;// ジャンプすると初期位置がずれるため
					Debug.Log("startPosY:" + startPosY);

					Particle.SetActive(false);
					BGM.Stop();
					SE.Play();
                }
                break;

            case 2:

                break;

            default:
                break;
        }
    }
}
