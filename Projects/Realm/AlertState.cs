using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// https://unity3d.com/learn/tutorials/topics/scripting/using-interfaces-make-state-machine-ai
/// </summary>
public class AlertState : IAnimalState {

    private readonly StatePatternAnimal animal;
    private float searchTimer;

    public AlertState(StatePatternAnimal statePatternAnimal) {
        animal = statePatternAnimal;
    }

    public void UpdateState() {
        Look();
        Search();
    }

    public void OnTriggerEnter(Collider other) {

    }

    public void ToPatrolState() {
        animal.currentState = animal.patrolState;
        searchTimer = 0f;
    }

    public void ToAlertState() {
        Debug.Log("Can't transition to same state");
    }

    public void ToRunawayState() {
        animal.currentState = animal.runAwayState;
        searchTimer = 0f;

    }

    private void Look() {
        RaycastHit hit;
        if (Physics.Raycast(animal.eyes.transform.position, animal.eyes.transform.forward, out hit, animal.sightRange)) {
            animal.runAwayTarget = hit.transform;
            ToRunawayState();
        }
    }
    private void Search() {
        animal.meshRendererFlag.material.color = Color.yellow;
        animal.navMeshAgent.Stop();
        animal.transform.Rotate(0, animal.searchingTurnSpeed * Time.deltaTime, 0);
        searchTimer += Time.deltaTime;

        if (searchTimer >= animal.searchingDuration)
            ToPatrolState();
    }
}
