using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionController : MonoBehaviour {

	public GameObject player;

	void Awake()	{
        int keys = PlayerPrefs.GetInt("keys", 0);
        Debug.Log("keys: " + keys);
		switch(keys)	{
			case 1:
				player.transform.position = new Vector3(97.0f, 0f, 165.0f);
				break;

			default:
				break;
		}	
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
