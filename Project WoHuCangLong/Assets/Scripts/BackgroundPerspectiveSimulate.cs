using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPerspectiveSimulate : MonoBehaviour
{
    public int layer;
    private GameObject mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 revisedCamPos = -mainCamera.transform.position;
        gameObject.transform.position = revisedCamPos * 0.2f / (layer * layer);
        gameObject.transform.localScale = new Vector3(1 / MathF.Sqrt(layer), 1 / MathF.Sqrt(layer), 1 / MathF.Sqrt(layer));
    }
    

}
