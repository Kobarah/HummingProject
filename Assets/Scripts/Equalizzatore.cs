using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equalizzatore : MonoBehaviour {


	public GameObject prefab;
	public int numberOfObjects = 20;
	public float radius = 5f;
	public GameObject[] cubes;
	public int hight;

	void Start() {
		for (int i = 0; i < numberOfObjects; i++) {
			float angle = i * Mathf.PI * 2 / numberOfObjects;
			Vector3 pos = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 1.58f) * radius;
			Instantiate(prefab, pos, Quaternion.identity);
		}

		cubes = GameObject.FindGameObjectsWithTag ("cubes");

	}

	//public GameObject prefab;
	public int gridX = 5;
	public int gridY = 5;
	public int spacing = 2;
	public GameObject[,] cubesM;
	public GameObject[] cubesV;
	//public float numberOfObjects;
	//public int hight = 30;
	public Material prova;

	void Awake()
	{

		cubesM = new GameObject[gridX,gridY];

	}

/*	void Start() 
	{

		//istanziamo gli oggetti a matrice nella scena
		for (int y = 0; y < gridY; y++) 
		{
			for (int x = 0; x < gridX; x++) 
			{
				
				Vector3 pos = new Vector3(x, 0, y) * spacing;
				Instantiate(prefab, pos, Quaternion.identity);

			}
		}/*


		numberOfObjects = gridX * gridY;

		/*for (int y = 0; y < gridY; y++) 
		{

			for (int x = 0; x < gridX; x++) 
			{

				cubesM[y,x] = GameObject.FindGameObjectWithTag ("cubes");


			}

		}*/

		//cubesV = GameObject.FindGameObjectsWithTag ("cubes");

	//} 

	void Update()
	{


		//ModificaCubiVettore (cubesV);

		/*
		float[] spectrum = AudioListener.GetSpectrumData (1024, 0, FFTWindow.Hamming);

		for (int i = 0; i < gridY; i++) 
		{

			//Debug.Log (i);

			for (int j = 0; j < gridX; j++) 
			{
				//Debug.Log (j);
				Vector3 previousScale = cubes [i,j].transform.localScale;
				previousScale.y = Mathf.Lerp (previousScale.y, spectrum [i] * hight, Time.deltaTime * 30);
				//previousScale.z = Mathf.Lerp (previousScale.z, spectrum [i] * hight, Time.deltaTime * 30);
				cubes [i,j].transform.localScale = previousScale;
			}

		}*/

	}

	public void ModificaCubiVettore(GameObject[] vettore)
	{

		int GrandezzaVettore = vettore.Length;
		float[] spectrum = AudioListener.GetSpectrumData (1024, 0, FFTWindow.Hamming);

		for (int j = 0; j < GrandezzaVettore; j = j+gridX) 
		{

			for (int i = 0; i < gridX; i++)
			{
				if (i == 5) 
				{

					prova.SetTextureOffset("_MainTex", new Vector2(spectrum [i]*15,-1.04f));

				}
				Vector3 previousScale = vettore [i+j].transform.localScale;
				previousScale.y = Mathf.Lerp (previousScale.y, spectrum [i] * hight, Time.deltaTime * 30);
				//previousScale.z = Mathf.Lerp (previousScale.z, spectrum [i] * hight, Time.deltaTime * 30);
				vettore [i+j].transform.localScale = previousScale;

				float random = Random.Range (0f, 1f);

				/*if (random >= 0.5f) {
					vettore [i + j].SetActive (true);
				} else {
					vettore [i + j].SetActive (false);
				}*/

			}

		}

	}

}
