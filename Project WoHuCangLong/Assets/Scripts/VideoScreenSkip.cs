using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoScreenSkip : MonoBehaviour
{
    bool holdingDown;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.anyKey) 
        {
            holdingDown = true;
        }

        if (!Input.anyKey && holdingDown) 
        {
            holdingDown = false;
            Invoke("LoadNextScene", 0.01f);
        }

    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
