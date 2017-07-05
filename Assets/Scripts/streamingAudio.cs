using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class streamingAudio : MonoBehaviour {

	public string url;
	public AudioSource source;
	void Start() {
		WWW www = new WWW(url);
		source = GetComponent<AudioSource>();
		source.clip = www.GetAudioClip();
	}
	void Update() 
	{
		
		if(!source.isPlaying && source.clip.isReadyToPlay)
			source.Play();

	}
}
