using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour {

	private AudioSource source;

	public AudioClip[] clips;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void digitButton(int i){
		source.PlayOneShot(clips[i]);
	}
}
