using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class Movement : MonoBehaviour {

    Animator anime;
    public static float health;
    public static Slider healthBar;
    public static float decreaseAmount;
    public static bool canMove;
    public static float damage = 0.02f;
    public static float overTime = 0.2f;
    bool underCover = false;
    bool isWalking = false;
    public static bool hasKey = false;
    public Text instruction;
    public bool isDead = false;
    
    void Awake() {
        anime = GetComponent<Animator>();
        healthBar = GetComponentInChildren<Slider>();
        if(PlayerPrefs.GetInt("keys") > 0 || PlayerPrefs.GetInt("load", 0) == 1)	{
        	anime.runtimeAnimatorController = Resources.Load("Beta2") as RuntimeAnimatorController;
        }
        if(PlayerPrefs.GetInt("load", 0) == 1)	{
        	float xPos = PlayerPrefs.GetFloat("xPos", 150.0f);
			float yPos = PlayerPrefs.GetFloat("yPos", 0f);
			float zPos = PlayerPrefs.GetFloat("xPos", 40.0f);
        	this.gameObject.transform.position = new Vector3(xPos, yPos, zPos);	
        	PlayerPrefs.SetInt("load", 0);
        }
    }

    void OnTriggerEnter(Collider other)	{
    	if((other.tag == "health"))	{
            IncreaseHealth(25f);
            //hasKey = true;
            //instruction.gameObject.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("key")) {
            //hasKey = true;
            //instruction.gameObject.SetActive(false);

        }
    }

    void OnParticleCollision(GameObject other) {
        Debug.Log("HIT");
        ReduceHealth();
    }

    // Use this for initialization
    void Start () {
    	health = 300;
        healthBar.maxValue = health;
    	damage = 1;
		decreaseAmount = 2;
    	hasKey = false;
		underCover = false;
    	isWalking = false;
        isDead = false;
        InvokeRepeating("increaseDamage", 1, 3);
        //instruction.gameObject.SetActive(false);
        canMove = true;
    }
	
	void Update () {
        if (canMove) {
            Turning();
            Walking();
            Move();
            Jump();
        }
    }

  
    private void ReduceHealth() {
        Debug.Log("HIT2");
        health = health - (decreaseAmount * damage);
        healthBar.value = health;
        Debug.Log(health);
        if (health <= 0 && isDead == false) {
            isDead = true;
            if (anime != null) {

                //Reset all static bool when reloading level

                // KeyScript.gotKey = false;
                //KeyScript.played = false;
                //hasKey = false;
                //CutScenceController.onlyOnce = false;
                //CutScenceController.canStart = false;
                //PlaneFade.cutScence = true;
                //PlaneFade.playedOnce = false;
                //PlaneFade.timer = 5f;
                Debug.Log("HIT4");
                anime.SetTrigger("Death");
				if(SceneManager.GetActiveScene().name == "Level 1")	{
					PlayerPrefs.SetInt("keys", 0);
					Invoke("loadLevel1", 3);		
				} else {
					Invoke("loadLevel2", 3);	
				}
            }
            else {
              Debug.Log("ERROR");
            }
            //Debug.Log(anime);
            //loadLevel1();

            
            //Debug.Log(anime);
        }
    }

    public void IncreaseHealth(float value) {
        health = health + value;
        healthBar.value = health ;


    }

    private void loadLevel1()	{
		SceneManager.LoadScene("Level 1");
    }

	private void loadLevel2()	{
		SceneManager.LoadScene("Level 2");
    }

    private void Turning() {
        anime.SetFloat("Turn", Input.GetAxis("Horizontal"));
    }

    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space)){
            anime.SetTrigger("Jump");
        }
    }

    private void Walking() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            isWalking =! isWalking;
            anime.SetBool("Walk", isWalking);
        }
    }
    private void Move() {
        anime.SetFloat("Forward", Input.GetAxis("Vertical"));
    }

    private void increaseDamage() {
        damage =+ overTime;
    }


}
