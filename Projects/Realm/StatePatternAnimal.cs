using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
///  https://unity3d.com/learn/tutorials/topics/scripting/using-interfaces-make-state-machine-ai
/// </summary>
public class StatePatternAnimal : MonoBehaviour {

    public float searchingTurnSpeed = 120f;
    public float searchingDuration = 4f;
    public float sightRange = 8f;
    public Transform[] wayPoints;
    public Transform eyes;
    public Vector3 offset = new Vector3(0, .5f, 0);
    public MeshRenderer meshRendererFlag;

    [HideInInspector]
    public Transform runAwayTarget;
    [HideInInspector]
    public IAnimalState currentState;
    [HideInInspector]
    public RunawayState runAwayState;
    [HideInInspector]
    public AlertState alertState;
    [HideInInspector]
    public PatrolState patrolState;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;


    private void Awake() {
        runAwayState = new RunawayState(this);
        alertState = new AlertState(this);
        patrolState = new PatrolState(this);

        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Start () {
        currentState = patrolState;
    }

	void Update () {
        currentState.UpdateState();
    }

    private void OnTriggerEnter(Collider other) {
        currentState.OnTriggerEnter(other);
    }
}
