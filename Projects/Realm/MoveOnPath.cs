using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour {

    public EditorPathScript PathToFollow;
    public int CurrentWayPointID = 0;
    public float speed;
    private float reachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string pathName;
    public bool playerInRange = false;

    Vector3 last_position;
    Vector3 current_position;

	// Use this for initialization
	void Start ()
    {
        //PathToFollow = GameObject.Find(pathName).GetComponent<EditorPathScript>();
        last_position = transform.position;	
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            playerInRange = true;
        }

    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            playerInRange = false;
        }
    }

    private void Update() {
        if (playerInRange == true) {

            float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);

            transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);

            if (distance <= reachDistance) {
                CurrentWayPointID++;
            }

            if (CurrentWayPointID >= PathToFollow.path_objs.Count) {
                CurrentWayPointID = 0;
            }
        }
    }
}
