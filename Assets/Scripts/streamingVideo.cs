using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class streamingVideo : MonoBehaviour {


	public WWW wwwData;
	public string url = "";
	public GUITexture gt;
	public Material stupidoMaterial;

	void Start() 
	{
		wwwData = new WWW(url);
		gt = GetComponent<GUITexture>();
		gt.texture = wwwData.GetMovieTexture();
	}


	void Update() 
	{
		Debug.Log(wwwData.progress);
		if (wwwData.progress >= 1) {
			MovieTexture m = gt.texture as MovieTexture;
			stupidoMaterial.mainTexture = m;
			m.Play ();
		}

	}
}
