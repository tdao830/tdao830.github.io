using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSoundController : MonoBehaviour {

	public static WindSoundController instance = null;

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
