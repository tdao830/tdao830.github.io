using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour {

	static public int cubeCounter;
	public GameObject fog;
	public GameObject exit;
	public GameObject coll;

	void Awake()	{
		cubeCounter = 0;
		exit.SetActive(false);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(cubeCounter >= 40)	{
			coll.SetActive(false);
			fog.SetActive(false);
			exit.SetActive(true);		
		}	
	}
}
