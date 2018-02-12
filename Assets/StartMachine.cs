using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMachine : MonoBehaviour
{

	public AudioSource music;

	public Camera[] cameras;

	public GameObject specialRectangle;

	private bool justOnce = true;
	private bool secondFlag = true;
	public GameObject bigSphere;

	private bool thirdFlag = true;
	// Use this for initialization
	void Start () {
		
	}

	public int i = 1;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Space))
		{
			GetComponent<Rigidbody>().useGravity = true;
			music.Play();
		}

		if (transform.position.y< 90)
		{
			Debug.Log("Should be goign down");
			cameras[1].transform.Translate(0,-.05f,0);
		}

		if (transform.position.x > 30 && cameras[2].enabled)
		{
			cameras[2].transform.Translate(0,0,.1f);
		}
		if (specialRectangle.transform.rotation.eulerAngles.y > 91 && justOnce)
		{
			cameras[3].enabled = false;
			cameras[4].enabled = true;
			justOnce = false;
		}

		if (bigSphere.transform.position.y < 58 && secondFlag)
		{
			cameras[4].enabled = false;
			cameras[5].enabled = true;
			secondFlag = false;
		}

		if (cameras[4].enabled)
		{
			cameras[4].transform.Translate(-.05f,0,0,Space.World);
		}
		if (cameras[5].enabled)
		{
			cameras[5].transform.Translate(0,-.05f,0);
		}

		if (bigSphere.transform.position.x < -160 && thirdFlag)
		{
			cameras[5].enabled = true;
			cameras[6].enabled = true;
			thirdFlag = false;
		}
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Next"))
		{

				cameras[i - 1].enabled = false;
				cameras[i].enabled = true;
			i++;
		}


	}
}
