using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPerspectiveCamFOV : MonoBehaviour
{
    private Camera mainCam;
    private Camera backgroundCam;

    private void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        backgroundCam = GetComponent<Camera>();
    }

    private void Update()
    {
        float orthoSize = mainCam.orthographicSize;
        float distanceFromOrigin = mainCam.gameObject.transform.position.z;
        
        backgroundCam.fieldOfView = GetFieldOfView(orthoSize, distanceFromOrigin);
        
        // print(backgroundCam.fieldOfView);
        // print("orthoSize" + orthoSize);
    }

    public float GetFieldOfView(float orthoSize, float distanceFromOrigin)
    {
        // orthoSize
        float a = orthoSize;
        // distanceFromOrigin
        float b = Mathf.Abs(distanceFromOrigin);

        float fieldOfView = Mathf.Atan(a / b)  * Mathf.Rad2Deg * 2f;
        return fieldOfView;
    }
}
