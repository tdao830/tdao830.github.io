using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordSoundController : MonoBehaviour {

	public AudioClip voice;
	public static bool canPlay;
	AudioSource audio; 

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		canPlay = false;
	}

	void playAudio()	{
		audio.PlayOneShot(voice, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		if(canPlay)	{
			playAudio();
			canPlay = false;
		}
	}
}
