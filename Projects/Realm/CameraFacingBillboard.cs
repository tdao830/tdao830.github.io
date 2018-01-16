using UnityEngine;
using System.Collections;

public class CameraFacingBillboard : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        //cam = GameObject.Find("Beta").GetComponentInChildren<Camera>();
        transform.LookAt(cam.transform.position);
    }
}