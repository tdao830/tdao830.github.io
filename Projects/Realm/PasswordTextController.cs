using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordTextController : MonoBehaviour {

	public Text password;
	public AudioClip thunder;
	AudioSource audio;
	private char[] pass = new char[5];
	public GameObject panel;
	public static bool canShow;
	private bool check;
	private int passCounter;
    public string inputKey = "";
	void Awake()	{
		resetPass();
		check = true;
		insertPassword();
		panel.SetActive(false);
		canShow = false;
	}

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}

	void resetPass()	{
		passCounter = 0;
		for(int i = 0; i < pass.Length; i++)	{
			pass[i] = '_';
         
        }	
	}

	void insertPassword()	{
		string temp = "";
        inputKey = "";

        for (int i = 0; i < pass.Length; i++)	{
			temp += "\t";
			temp += pass[i];
            inputKey = inputKey + pass[i];
        }
		password.text = temp;
	}

	void displayInput()	{
		foreach (char c in Input.inputString)	{
            //(c >= 'a' && c <= 'z') ||
            if(c >= '0' && c <= '9')	{
               // if (c != 'a' && c != 's' && c != 'd' && c != 'w') {
                pass[passCounter++] = c;
                insertPassword();
                if (passCounter >= pass.Length) {
                    audio.PlayOneShot(thunder, 0.5f);
                    resetPass();
                }
               // }
			} 
		}	
	}
	
	// Update is called once per frame
	void Update () {
		if(canShow)	{
			panel.SetActive(true);
			displayInput();
            //Debug.Log(inputKey);
            if (inputKey.Equals("51109")) {
                KeyScript.gotKey = true;
            }
        } else {
			resetPass();
			insertPassword();
			panel.SetActive(false);
		}
        
	}
}
