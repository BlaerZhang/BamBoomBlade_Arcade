using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrailManager : MonoBehaviour
{
    private List<TrailRenderer> trails;

    private Vector3 lastPosition = Vector3.zero;

    private float weaponSpeed = 0;

    void Start()
    {
        trails = GetComponentsInChildren<TrailRenderer>().ToList();
    }
    
    void Update()
    {
        if (weaponSpeed > 7.5f)
        {
            foreach (var trailRenderer in trails)
            {
                trailRenderer.emitting = true;
            }
        }
        else
        {
            foreach (var trailRenderer in trails)
            {
                trailRenderer.emitting = false;
            }
        }
    }

    private void FixedUpdate()
    {
        weaponSpeed = (transform.position - trails[0].transform.position - lastPosition).magnitude /
                      Time.fixedDeltaTime;
        lastPosition = transform.position - trails[0].transform.position;
        // print(weaponSpeed);
    }
}
