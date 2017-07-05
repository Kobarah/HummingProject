using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotazioneCilindro : MonoBehaviour {

	public Rigidbody rb;

	
	// Update is called once per frame
	void Update () 
	{

		rb.transform.localRotation *= Quaternion.Euler (0.0f,0.0f, 2 * Time.deltaTime);

	}
}
