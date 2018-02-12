using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGate : MonoBehaviour {
    public GameObject gate1; 
    public GameObject gate2;
	private bool beginRotate;

	public Camera finalCam;

	public Camera secondToLast;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (beginRotate)
		{
			gate1.transform.Rotate(0, -1, 0);
			gate2.transform.Rotate(0,1,0);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Blocky"))
		{
			beginRotate = true;
			secondToLast.enabled = false;

			finalCam.enabled = true;

		}
	}
}
