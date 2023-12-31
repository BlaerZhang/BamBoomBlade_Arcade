using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Grounded : MonoBehaviour
{
    public MMF_Player groundFeedback;

    private bool isGrounded = false;
    
    private TextMeshProUGUI subText;

    private TextMeshProUGUI scoreText;
    
    void Start()
    {
        subText = GameObject.Find("Sub Text").GetComponent<TextMeshProUGUI>();
        scoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (isGrounded == false)
        {
            isGrounded = true;
            groundFeedback.PlayFeedbacks();
            Invoke("ShowResult",0.5f);
        }
    }

    private void ShowResult()
    {
        scoreText.text += GameManager.instance.player1WinsCount + "-" + GameManager.instance.player2WinsCount;
        if (GameManager.instance.isInMatch)
        {
            subText.text += "Get Ready for the Next Round";
        }
        else
        {
            subText.text += "Press A or Space to Start a New Match";
        }
    }
}
