using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// https://unity3d.com/learn/tutorials/topics/scripting/using-interfaces-make-state-machine-ai
/// </summary>
public class PatrolState : IAnimalState {

    private readonly StatePatternAnimal animal;
    private int nextWayPoint;
    public PatrolState(StatePatternAnimal statePatternAnimal) {
        animal = statePatternAnimal;
    }
    public void UpdateState() {

        Look();
        Patrol();

    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
            ToAlertState();
    }

    public void ToPatrolState() {
        Debug.Log("Can't transition to same state");
    }

    public void ToAlertState() {
        animal.currentState = animal.alertState;
    }

    public void ToRunawayState() {
        animal.currentState = animal.runAwayState;
    }

    private void Look() {
        RaycastHit hit;
        if (Physics.Raycast(animal.eyes.transform.position, animal.eyes.transform.forward, out hit, animal.sightRange)) {
            animal.runAwayTarget = hit.transform;

        }
    }
    void Patrol() {
        animal.navMeshAgent.speed = 2;
        animal.meshRendererFlag.material.color = Color.green;
        animal.navMeshAgent.destination = animal.wayPoints[nextWayPoint].position;
        animal.navMeshAgent.Resume();

        if (animal.navMeshAgent.remainingDistance <= animal.navMeshAgent.stoppingDistance && !animal.navMeshAgent.pathPending) {
            nextWayPoint = (nextWayPoint + 1) % animal.wayPoints.Length;

        }


    }
}
