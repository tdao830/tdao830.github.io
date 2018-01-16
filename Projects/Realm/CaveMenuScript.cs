using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveMenuScript : MonoBehaviour {

	private Rect DialogRect = new Rect((Screen.width/2 - 125), (Screen.height/2 - 100), 250, 125);
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

    void DialogBox(int windowID)    
    {
		if (GUI.Button(new Rect(10, 25, DialogRect.width - 20, 25), "Reset"))
        {	
        	SceneManager.LoadScene("Cave");
            ShowDialog = false;
        }
		if (GUI.Button(new Rect(10, 50, DialogRect.width - 20, 25), "Exit"))
        {
            Application.Quit();
            ShowDialog = false;
        }
        if (GUI.Button(new Rect(10, 80, DialogRect.width - 20, 25), "Cancel"))
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
