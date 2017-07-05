using UnityEngine;
using System.Collections;

public class LightningBolt : MonoBehaviour
{

	private Renderer rend;

	// Use this for initialization
	void Start ()
	{		

		rend = GetComponent<Renderer> ();
		rend.enabled = true;

		Material newMat = rend.material;
		newMat.SetFloat("_StartSeed",Random.value*1000);
		rend.material = newMat;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}

