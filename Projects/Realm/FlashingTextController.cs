using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlashingTextController : MonoBehaviour {

	public Text flashingText;

	// Use this for initialization
	void Start () {
		StartCoroutine(BlinkText());	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))	{
			SceneManager.LoadScene("Main Menu");	
		}	
	}

	IEnumerator BlinkText()	{
		while(true)	{
			flashingText.text = "";
			yield return new WaitForSeconds(.4f);
			flashingText.text = "Press Esc to go back to Main Menu";
			yield return new WaitForSeconds(.4f);
		}
	}

}
