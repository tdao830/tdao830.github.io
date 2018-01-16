using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxController : MonoBehaviour {
    public GameObject dialogBox;
    public Text dialog;
    public TextAsset textFile;
    public string[] textLines;
    private int currentLine;
    private int endAtLine = 3;
    private bool isTyping;
    private bool cancelTyping;
    public float typeSpeed;
    public bool isActive;
    private bool onlyOnce = true;
    private string familiar;
    // Use this for initialization
    void Start() {
        familiar = "Why does this number look so familiar?";
        currentLine = 0;
        isTyping = false;
        cancelTyping = false;
        if (textLines != null) {
            textLines = (textFile.text.Split('\n'));
        }
        if (isActive) {
            EnableDialogBox();
        }
        else {
            DisableDialogBox();
        }
    }

    // Update is called once per frame
    void Update() {
        if (!isActive) {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Return) && currentLine < endAtLine ) {
            if (!isTyping) {
                currentLine++;
                if (currentLine >= endAtLine) {
                    DisableDialogBox();
                }
                else {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if (isTyping && !cancelTyping) {
                cancelTyping = true;
            }
        }
    }

    private IEnumerator TextScroll(string lineOfText) {
        int letter = 0;
        dialog.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1)) {
            dialog.text += lineOfText[letter];
            letter++;
            yield return new WaitForSeconds(typeSpeed);
        }
        dialog.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableDialogBox() {
        dialogBox.SetActive(true);
        isActive = true;
        currentLine = 0;
        /*
        if (Movement.hasKey) {
            currentLine = endAtLine + 1;
            StartCoroutine(TextScroll(familiar));
           	dialog.text = "";
        }

        else {*/
            StartCoroutine(TextScroll(textLines[currentLine]));
        //}
    }


    public void DisableDialogBox() {
            dialogBox.SetActive(false);
            isActive = false;
            dialog.text = "";
    }

}