using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

	bool level1PortalStatus = false;
	public AudioClip transport;
	AudioSource audio;

	void Awake()	{
		
	}

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Movement.hasKey)	{
			level1PortalStatus = true;
			transform.Rotate (new Vector3 (0, 50, 0) * Time.deltaTime);
		}
	}

	void playAudio()	{
		audio.PlayOneShot(transport, 0.2f);
	}

	void loadStartingArea()	{
		SceneManager.LoadScene("Starting Area");
	}

	void OnTriggerEnter(Collider other) {
			if((level1PortalStatus))	{
				playAudio();
				Invoke("loadStartingArea", 2f);
			}

	}
}
