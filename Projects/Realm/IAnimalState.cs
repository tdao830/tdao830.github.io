using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// https://unity3d.com/learn/tutorials/topics/scripting/using-interfaces-make-state-machine-ai
/// </summary>
public interface IAnimalState  {


    void UpdateState();

    void OnTriggerEnter(Collider other);

    void ToPatrolState();

    void ToAlertState();

    void ToRunawayState();




}
