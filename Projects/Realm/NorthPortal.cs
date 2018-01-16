using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NorthPortal : MonoBehaviour {

    bool level2PortalStatus = false;
    public AudioClip transport;
    AudioSource audio;
    public GameObject light;
	public GameObject light1;
	public GameObject light2;
	public Material closeMaterial;
	public Material openMaterial;
	public Renderer rend;

    void Awake() {
		if(PlayerPrefs.GetInt("keys", 0) >= 1)	{
        	level2PortalStatus = true;
        	light.SetActive(true);
			light1.SetActive(true);
			light2.SetActive(true);
			rend.material = openMaterial;
        } else {
			level2PortalStatus = false;
			light.SetActive(false);
			light1.SetActive(false);
			light2.SetActive(false);
			rend.material = closeMaterial;	
		}	
    }

    // Use this for initialization
    void Start() {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if(level2PortalStatus)	{
			transform.Rotate (new Vector3 (0, 50, 0) * Time.deltaTime);
        }
    }

    void playAudio() {
        audio.PlayOneShot(transport, 0.2f);
    }

	void loadLevel1() {
        SceneManager.LoadScene("Level 1");
    }

    void loadExitScreen()	{
		SceneManager.LoadScene("EndText");
    }

    void loadLevel2() {
        SceneManager.LoadScene("Level 2");
    }

    void loadCave()	{
		SceneManager.LoadScene("Cave");	
    }

    void OnTriggerEnter(Collider other) {
        if (level2PortalStatus) {
            playAudio();
            Invoke("loadLevel2", 2f);
        }
    }
}
