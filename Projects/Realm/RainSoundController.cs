using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSoundController : MonoBehaviour {

	public static RainSoundController instance = null;

    void Awake ()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
			//GameObject.DontDestroyOnLoad(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
