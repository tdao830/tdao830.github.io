using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {
    private KeyCode[] sequence = new KeyCode[]{ KeyCode.Alpha5,
         KeyCode.Alpha1,
         KeyCode.Alpha1,
         KeyCode.Alpha0,
         KeyCode.Alpha9};
	private int sequenceIndex = 0;
	AudioSource audio;
	public AudioClip unlock;
    public GameObject panel;
    public static bool played = false;
    public static bool gotKey = false;
    void Start() {
        sequenceIndex = 0;
        audio = GetComponent<AudioSource>();
        gotKey = false;
        played = false;
    }



    /*
	void OnTriggerStay(Collider other)	{
		if(other.tag == "Player")	{
            Debug.Log("DEBUG 0");
			if(!Movement.hasKey)	{
	            if (Input.GetKeyDown(sequence[sequenceIndex])) {
                    displayInput();


                    if (++sequenceIndex == sequence.Length) {
                        Debug.Log("DEBUG 1");
                        sequenceIndex = 0;
						Movement.hasKey = true;
						PlayerPrefs.SetInt("keys", PlayerPrefs.GetInt("keys", 0)+1);
						playAudio();
	                    Destroy(this.gameObject, unlock.length);
	                }
	            }
	            else if (Input.anyKeyDown) {
	                sequenceIndex = 0;
                    Debug.Log("DEBUG 2");
                }
        	}
		}
	}
    */
    void OnTriggerEnter(Collider other)	{
		if(other.tag == "Player")	{
			PasswordTextController.canShow = true;
			PasswordSoundController.canPlay = true;
		}
	}

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            PasswordTextController.canShow = false;
            PasswordSoundController.canPlay = false;
        }
    }

    void playAudio()	{
		audio.PlayOneShot(unlock, 0.5f);
	}

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        if (gotKey && played == false) {
            played = true;
            Movement.hasKey = true;
            panel.SetActive(true);
            PlayerPrefs.SetInt("keys", PlayerPrefs.GetInt("keys", 0) + 1);
            PortalMaterialControl.isLock = false;
            playAudio();
            Destroy(this.gameObject, unlock.length);
            PlaneFade.timer = 5f;           
            PasswordTextController.canShow = false;
            PasswordSoundController.canPlay = false;
        }
	}
    void displayInput() {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode))) {
    
            if (Input.GetKey(key)) { 
            Debug.Log(key);
        }
        }
    }
}
