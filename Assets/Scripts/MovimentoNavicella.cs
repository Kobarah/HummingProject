using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{

	public float xMin, xMax, zMin, zMax;

}


public class MovimentoNavicella : MonoBehaviour {

	public float MinSpeed;
	public float MaxSpeed;
	[SerializeField]
	private float speed;
	public float tilt;
	public Boundary boundary;
	public Rigidbody rb;
	public float zPos = 20f;
	private bool sprint = false;


	void Awake()
	{

		speed = MinSpeed;

	}

	// Update is called once per frame
	void FixedUpdate () 
	{

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		rb.position = new Vector3 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			zPos,
			Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
		);
			
		rb.rotation = Quaternion.Euler (0.0f, 180.0f, rb.velocity.x * -tilt);

		//attivo lo sprint se premo W
		if (Input.GetKeyDown (KeyCode.W) == true) 
		{

			sprint = true;

		}

		//disattivo lo sprint se premo W
		if (Input.GetKeyUp (KeyCode.W) == true)
		{

			sprint = false;

		}

		//controllo la gestione della velocità
		GestioneVelocita (sprint);


	}


	/// <summary>
	/// Metodo per la gestione della velocità
	/// </summary>
	/// <param name="sprint">If set to <c>true</c> sprint.</param>
	public void GestioneVelocita(bool sprint)
	{

		if (sprint == true) 
		{

			speed = Mathf.Lerp(speed,MaxSpeed,Time.deltaTime*10);

		} 
		else
		{

			speed = Mathf.Lerp(speed,MinSpeed,Time.deltaTime*10);

		}

	}

	//-------------- METODI DI GET------------
	public float GetSpeed()
	{

		return(speed);

	}

}


