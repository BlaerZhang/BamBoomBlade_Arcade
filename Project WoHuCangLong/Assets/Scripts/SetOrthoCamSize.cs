using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOrthoCamSize : MonoBehaviour
{
    private Camera vFXCam;

    private Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        vFXCam = GetComponent<Camera>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        vFXCam.orthographicSize = mainCam.orthographicSize;
    }
}
