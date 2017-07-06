using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {

    public float speed;
    //private Rigidbody rb;
    public GameObject[] spawnCubes; //array di copia del "cubes" dello script Equalizzatore
    public GameObject obj; //contenitore per la telecamera
    private Equalizzatore eq; //contenitore di istanza per Equalizzatore
    public float limiteSpawn = 5; //valore regolabile di "tolleranza" sullo spawn dei nemici
    public GameObject enemy; //contenitore nemici spawnabili

    void Awake ()
    {
        obj = GameObject.FindGameObjectWithTag("MainCamera");
        enemy = GameObject.FindGameObjectWithTag("enemy"); //assegnazione nemico e camera nei contenitori
    }
    
    void Start ()
    {
        eq = obj.GetComponent<Equalizzatore>();
        spawnCubes = eq.cubes; //crea oggetto Equalizzatore ed estrapola array cubes
            
        //rb = GetComponent<Rigidbody>();
        //rb.velocity = transform.forward * speed;
    }
	
	void Update ()
    {
        for (int i = 0; i < spawnCubes.Length; i++) //cicla cubes
        {
            Vector3 indiceSpawn = spawnCubes[i].transform.localScale; //istanzia Vector3 uguale alla posizione del cubo in esame
            if (indiceSpawn.y > limiteSpawn) //se l'altezza del cubo in esame è maggiore del trigger dello spawn, il nemico viene istanziato
            {
                Instantiate(enemy, indiceSpawn, Quaternion.identity);
            }
        }
    }
}
