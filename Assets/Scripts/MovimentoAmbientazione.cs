using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoAmbientazione : MonoBehaviour {


	public GameObject[] land;
	[SerializeField]
	private float[] Pos_Land;
	public GameObject navicella;
	private MovimentoNavicella ClassNav;

	void Awake()
	{

		ClassNav = navicella.GetComponent<MovimentoNavicella> ();


		land = GameObject.FindGameObjectsWithTag ("land");
		Pos_Land = new float[land.Length];

		//salviamo le poszioni del vettore Land
		for (int i = 0; i < land.Length; i++) 
		{

			Pos_Land [i] =  land [i].transform.position.z;

		}

	}

	
	// Update is called once per frame
	void Update () 
	{

		//Scorrimento (oggetto);

		for (int i = 0; i < land.Length; i++) 
		{
			
			LoopLand (land [i]);

		}


	}

	private int contatore=0;

	//controllo quando la navicella esce dall'oggetto per poterlo riposizionare nella scena in una determinata posizione 
	void OnTriggerExit(Collider other)
	{

		if (other.tag == "land") 
		{
			
			land [land.Length - 1 - contatore].transform.position = new Vector3 (land [land.Length - 1 - contatore].transform.position.x, land [land.Length - 1 - contatore].transform.position.y, Pos_Land [0]);
			contatore++;

			if (land.Length - 1 - contatore < 0) 
			{

				Debug.Log ("reset contatore");
				contatore = 0;

			}

		}

	}

	/// <summary>
	/// Metodo che permette di scorrere le land sull'asse delle Z
	/// </summary>
	/// <param name="oggetto">Oggetto.</param>
	private void LoopLand(GameObject oggetto)
	{
		
		oggetto.transform.Translate (Vector3.up * Time.deltaTime*ClassNav.GetSpeed());

	}

}
