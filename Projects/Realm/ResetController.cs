using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetController : MonoBehaviour {

	private Rect DialogRect = new Rect((Screen.width/2 - 125), (Screen.height/2 - 100), 250, 200);
    private bool ShowDialog;

    private void Start()
    {
        ShowDialog = false;
    }

    private void OnGUI()
    {
        if (ShowDialog)
        {
            DialogRect = GUI.Window(0, DialogRect, DialogBox, "Exit/Restart");
        }
    }

    void DialogBox(int windowID)    
    {
        GUI.Label(new Rect(10, 20, DialogRect.width - 20, 25), "Do you wish to Restart or Exit?");

        if(GUI.Button(new Rect(10, 50, DialogRect.width - 20, 25), "Restart"))
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            ShowDialog = false;
        }
        if (GUI.Button(new Rect(10, 80, DialogRect.width - 20, 25), "Exit"))
        {
            Application.Quit();
            ShowDialog = false;
        }
        if (GUI.Button(new Rect(10, 110, DialogRect.width - 20, 25), "Cancel"))
        {
            ShowDialog = false;
            Cursor.visible = !Cursor.visible;
        }

    }

    void Update () {
   		
    	if(Input.GetKey(KeyCode.Escape))	{
    		ShowDialog = true;
    	}

        if (Input.GetButtonUp("Exit/Restart"))	{
	        {
	            ShowDialog = !ShowDialog;
	            Cursor.visible = !Cursor.visible;
	        }
        }
	}
}
