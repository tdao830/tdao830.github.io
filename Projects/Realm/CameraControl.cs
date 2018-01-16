using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    [SerializeField]
    private float distanceAway;
    [SerializeField]
    private float distanceUp;
    [SerializeField]
    private float Smooth;
    [SerializeField]
    private Transform follow;
    private Vector3 targetPosition;
    private void Start() {
        follow = GameObject.FindGameObjectWithTag("follow").transform;
    }

    private void Update() {

    }
    private void LateUpdate() {
        targetPosition = follow.position + Vector3.up * distanceUp - follow.forward * distanceAway;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * Smooth);
        transform.LookAt(follow);

    }
}