using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// https://unity3d.com/learn/tutorials/topics/scripting/using-interfaces-make-state-machine-ai
/// </summary>
public class RunawayState : IAnimalState {

    private readonly StatePatternAnimal animal;
    

    public RunawayState(StatePatternAnimal statePatternAnimal) {
        animal = statePatternAnimal;
    }


    public void UpdateState() {
        Look();
        Run();
    }

    public void OnTriggerEnter(Collider other) {

    }

    public void ToPatrolState() {
        animal.currentState = animal.patrolState;
    }

    public void ToAlertState() {
        animal.currentState = animal.alertState;
    }

    public void ToRunawayState() {

    }
    private void Look() {
        RaycastHit hit;
        Vector3 enemyToTarget = (animal.runAwayTarget.position + animal.offset) - animal.eyes.transform.position;
        if (Physics.Raycast(animal.eyes.transform.position, enemyToTarget, out hit, animal.sightRange) && hit.collider.CompareTag("Player")) {
            animal.runAwayTarget = hit.transform;

        }
        else {
            ToAlertState();
        }

    }

    private void Run() {
        animal.meshRendererFlag.material.color = Color.red;

        Vector3 temp = new Vector3(animal.runAwayTarget.position.x + Random.Range(-50f,-30f), animal.runAwayTarget.position.y, animal.runAwayTarget.position.z + Random.Range(-50f, -30f));
        animal.navMeshAgent.speed = 8;
        animal.navMeshAgent.destination = temp;
        animal.navMeshAgent.Resume();
        if (Vector3.Distance(animal.transform.position, animal.runAwayTarget.transform.position) >= 50f) {
            ToPatrolState();
        }

    }
}

