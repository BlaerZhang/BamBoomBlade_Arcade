using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class RoundIndicatorUI : MonoBehaviour
{
    public List<Image> leftIndicators;

    public List<Image> rightIndicators;

    void Start()
    {
        foreach (var image in leftIndicators)
        {
            image.enabled = false;
        }
        
        foreach (var image in rightIndicators)
        {
            image.enabled = false;
        }
        
        for (int i = 0; i < GameManager.instance.targetWinsCount; i++)
        {
            leftIndicators[i].enabled = true;
            leftIndicators[i].color = Color.white;
            
            rightIndicators[i].enabled = true;
            rightIndicators[i].color = Color.white;
        }
    }
    
    void Update()
    {
        UpdateIndicator();
    }

    private void UpdateIndicator()
    {
        for (int i = 0; i < GameManager.instance.player1WinsCount; i++)
        {
            leftIndicators[i].color = new Color32(138, 16, 2, 255);
        }
        for (int i = GameManager.instance.player1WinsCount; i < leftIndicators.Count; i++)
        {
            leftIndicators[i].color = Color.white;
        }

        for (int i = 0; i < GameManager.instance.player2WinsCount; i++)
        {
            rightIndicators[i].color = new Color32(138, 16, 2, 255);
        }
        for (int i = GameManager.instance.player2WinsCount; i < rightIndicators.Count; i++)
        {
            rightIndicators[i].color = Color.white;
        }
    }

    private void OnEnable()
    {
        GetComponent<RectTransform>().DOAnchorPosY(0, 0.5f);
    }

    private void OnDisable()
    {
        GetComponent<RectTransform>().DOAnchorPosY(300, 0.5f);
    }
}
