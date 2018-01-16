using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	private int counter;
	public AudioClip voice;
	AudioSource audio;
	public Renderer rend;
	public Material blue;
	public Material red;
	private bool check;

	void Awake()	{
		counter = 0;
		check = true;
		audio = GetComponent<AudioSource>();
		rend.material = blue;
	}

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
					
	}

	void playAudio()	{
		audio.PlayOneShot(voice, 0.05f);
	}

	void OnCollisionEnter(Collision collision)	{
		if(collision.gameObject.tag == "Player")	{
			rend.material = red;
			if(counter >= 2)	{
				Destroy(gameObject);		
			}
		}	
	}

	void OnCollisionExit(Collision collisionInfo)	{
		if(collisionInfo.gameObject.tag == "Player")	{
			counter++;
			if(check)	{
				WinController.cubeCounter++;
				check = false;
				playAudio();
			}
		}
	}

}
