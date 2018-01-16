using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditControl : MonoBehaviour {

    public TextAsset textFile;
    public string[] textLines;
    public int introTime = 10;
    private int currentLine;
    private int endAtLine = 3;
    public Text intro;
    private float fadeTime = 1.5f;
    private float waitTime = 1.5f;

    void Start() {
        currentLine = 0;
        if (textLines != null) {
            textLines = (textFile.text.Split('\n'));
        }
        StartCoroutine(Intro());

        StartCoroutine(textFade());
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("Main Menu");
        }

    }

    IEnumerator Intro() {
        // Do intro stuff. Play animations, move gameobjects, load preloaders ect
        yield return new WaitForSeconds(introTime); // Or however long you want
        SceneManager.LoadScene("Main Menu");

    }
    IEnumerator textFade() {
        int i = 0;
        while (i < textLines.Length) {

            intro.text = textLines[i];
            i++;
            intro.CrossFadeAlpha(1f, fadeTime, false);
            yield return new WaitForSeconds(waitTime);

            intro.CrossFadeAlpha(0f, fadeTime, false);
            yield return new WaitForSeconds(waitTime);
        }
        SceneManager.LoadScene("Main Menu");

    }
}
