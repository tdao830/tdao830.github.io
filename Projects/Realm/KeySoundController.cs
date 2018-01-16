using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySoundController : MonoBehaviour {

	public AudioClip unlock;
	public static float audioLength;
	public static bool canPlay = false;
	AudioSource audio; 

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		audioLength = unlock.length;
	}

	void playAudio()	{
		audio.PlayOneShot(unlock, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if(canPlay)	{
			playAudio();
			canPlay = false;
		}
	}
}
