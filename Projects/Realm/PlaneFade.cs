using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFade : MonoBehaviour {
    public Renderer renderer;
    public static float timer = 5f;
    public Color defaultColor;
    private bool fadeOutComplete = false;
    private bool fadeInComplete = false;
    public static bool cutScence = true;
    public static bool playedOnce = false;

        // Use this for initialization
    void Start () {
        defaultColor = renderer.material.color;
        cutScence = true;
        playedOnce = false;
        timer = 5f;
        //Debug.Log(defaultColor);
    }
	
	// Update is called once per frame
	void Update () {
        if (Movement.hasKey == false) {
            
            fadeOut();
            //Debug.Log(1);
        }
        else if (Movement.hasKey == true && cutScence == true) {

            Movement.canMove = false;
            fadeIn();
            
        }
        else if (Movement.hasKey == true && cutScence == false) {
            Movement.canMove = true;
            fadeOut();
            
        }


    }


    void fadeOut() {
        timer = timer - Time.deltaTime;

        if (timer >= 0) {
            Color color = renderer.material.color;
            color.a -= 0.15f * Time.deltaTime;
            renderer.material.color = color;

        }
        if (timer <= 0 && playedOnce == true) {
            Movement.decreaseAmount = 2f;

        }
        else if (timer <= 0) {
            gameObject.active = false;
        }

    }

    void fadeIn() {
        timer = timer - Time.deltaTime;

        if (timer >= 0) {
            Color color = renderer.material.color;
            color.a += 0.15f * Time.deltaTime;
            renderer.material.color = color;

        }
        if (timer <= 0 && playedOnce == false) {
            playedOnce = true;
            CutScenceController.canStart = true;
            Movement.decreaseAmount = 0f;
        }
    }
}
