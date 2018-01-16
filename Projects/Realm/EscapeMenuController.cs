using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenuController : MonoBehaviour {

	private Rect DialogRect = new Rect((Screen.width/2 - 125), (Screen.height/2 - 100), 250, 150);
	public GameObject player;
    private bool ShowDialog;

    private void Start()
    {
        ShowDialog = false;
    }

    private void OnGUI()
    {
        if (ShowDialog)
        {
            DialogRect = GUI.Window(0, DialogRect, DialogBox, "Menu");
        }
    }

    private void save()	{
    	string currentScene = SceneManager.GetActiveScene().name;
    	PlayerPrefs.SetString("scene", currentScene);
    	PlayerPrefs.SetFloat("xPos", player.transform.position.x);
		PlayerPrefs.SetFloat("yPos", player.transform.position.y);
		PlayerPrefs.SetFloat("zPos", player.transform.position.z);
		PlayerPrefs.SetInt("savedKeys", PlayerPrefs.GetInt("keys", 0));
    }

    private void load()	{
    	if(!(PlayerPrefs.GetString("scene", "Main Menu") == "Main Menu"))	{
			PlayerPrefs.SetInt("keys", PlayerPrefs.GetInt("savedKeys", 0));
			PlayerPrefs.SetInt("load", 1);
    		SceneManager.LoadScene(PlayerPrefs.GetString("scene", "Main Menu"));
    	}
    }

    void DialogBox(int windowID)    
    {
		if (GUI.Button(new Rect(10, 20, DialogRect.width - 20, 25), "Save"))
        {
        	save();
            ShowDialog = false;
        }
		if (GUI.Button(new Rect(10, 50, DialogRect.width - 20, 25), "Load"))
        {
            ShowDialog = false;
            load();
        }
		if (GUI.Button(new Rect(10, 80, DialogRect.width - 20, 25), "Exit"))
        {
            Application.Quit();
            ShowDialog = false;
        }
        if (GUI.Button(new Rect(10, 110, DialogRect.width - 20, 25), "Cancel"))
        {
            ShowDialog = false;
        }

    }

    void Update () { 		
    	if(Input.GetKeyDown(KeyCode.Escape))	{
    		ShowDialog = !ShowDialog;
    	}
	}
}
