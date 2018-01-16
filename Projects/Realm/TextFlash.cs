using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlash : MonoBehaviour {

	public Text[] flashingText = new Text[1];
	private int textArrayIndex;
	private float fadeTime = 1.5f;
	private float waitTime = 1.5f;

	// Use this for initialization
	void Start () {
		textArrayIndex = 0;
		flashingText[textArrayIndex].CrossFadeAlpha(0f, 0.01f, false);
		//flashingText[++textArrayIndex].CrossFadeAlpha(0f, 0.01f, false);
		//flashingText[++textArrayIndex].CrossFadeAlpha(0f, 0.01f, false);
		textFade();
		StartCoroutine(textFade());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator textFade()	{
		while(true)	{
			textArrayIndex = 0;
			flashingText[textArrayIndex].CrossFadeAlpha(1f, fadeTime, false);
			yield return new WaitForSeconds(waitTime);
			flashingText[textArrayIndex].CrossFadeAlpha(0f, fadeTime, false);
			yield return new WaitForSeconds(waitTime);
			//flashingText[++textArrayIndex].CrossFadeAlpha(1f, fadeTime, false);
			//yield return new WaitForSeconds(waitTime);
			//flashingText[textArrayIndex].CrossFadeAlpha(0f, fadeTime, false);
			//yield return new WaitForSeconds(waitTime);
			//flashingText[++textArrayIndex].CrossFadeAlpha(1f, fadeTime, false);
			//yield return new WaitForSeconds(waitTime);
			//flashingText[textArrayIndex].CrossFadeAlpha(0f, fadeTime, false);
			//yield return new WaitForSeconds(waitTime);
		}
	}

}
