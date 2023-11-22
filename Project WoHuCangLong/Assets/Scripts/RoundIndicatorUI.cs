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

    public Sprite noPointIcon;

    public Sprite pointIcon;

    [Range(0, 1)] public float noPointOpacity;

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
            leftIndicators[i].sprite = noPointIcon;
            leftIndicators[i].color = new Color(1, 1, 1, noPointOpacity);
            
            rightIndicators[i].enabled = true;
            rightIndicators[i].sprite = noPointIcon;
            rightIndicators[i].color = new Color(1, 1, 1, noPointOpacity);
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
            leftIndicators[i].color = Color.white;
            leftIndicators[i].sprite = pointIcon;
        }
        for (int i = GameManager.instance.player1WinsCount; i < leftIndicators.Count; i++)
        {
            leftIndicators[i].color = new Color(1, 1, 1, noPointOpacity);
            leftIndicators[i].sprite = noPointIcon;
        }

        for (int i = 0; i < GameManager.instance.player2WinsCount; i++)
        {
            rightIndicators[i].color = Color.white;
            rightIndicators[i].sprite = pointIcon;
        }
        for (int i = GameManager.instance.player2WinsCount; i < rightIndicators.Count; i++)
        {
            rightIndicators[i].color = new Color(1, 1, 1, noPointOpacity);
            rightIndicators[i].sprite = noPointIcon;
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
