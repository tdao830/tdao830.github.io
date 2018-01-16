using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject loadButton;

	public void Awake()	{
		if(PlayerPrefs.GetString("scene", "Main Menu") == "Main Menu")	{
			loadButton.SetActive(false);
		}	
	}

	public void changeScene(string scene)	{
		SceneManager.LoadScene(scene);
	}

	public void quitGame()	{
		Application.Quit();
	}

	public void reset()	{
		PlayerPrefs.SetInt("keys", 0);
	}

	public void load()	{
    	if(!(PlayerPrefs.GetString("scene", "Main Menu") == "Main Menu"))	{
			PlayerPrefs.SetInt("keys", PlayerPrefs.GetInt("savedKeys", 0));
			PlayerPrefs.SetInt("load", 1);
    		SceneManager.LoadScene(PlayerPrefs.GetString("scene", "Main Menu"));
    	}
    }

}
