using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PortalMaterialControl : MonoBehaviour {


    public Material closePortal;
    public Material openPortal;
    public static bool isLock;
    public GameObject light;
    public Renderer render;
    // Use this for initialization
    void Start () {
		isLock = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isLock) {
            render.material = closePortal;
            light.SetActive(false);
        }
        else {
            render.material = openPortal;
			light.SetActive(true);
        }

	}
}
