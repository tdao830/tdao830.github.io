using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(BoxCollider))]
public class pickup : MonoBehaviour {
    public float increaseAmount = 25f;
	public AudioClip taken;
	AudioSource audio;
    void Start() {
        audio = GetComponent<AudioSource>();
        increaseAmount = 25f;

    }


    void OnTriggerEnter(Collider other) {
    	if(other.tag == "Player")	{       
            playAudio();
			Destroy(this.gameObject, taken.length);
        }
    }

	void playAudio()	{
		audio.PlayOneShot(taken, 0.2f);
	}


	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {

    }
}
