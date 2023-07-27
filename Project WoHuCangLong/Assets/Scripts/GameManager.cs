using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // public static GameObject gameManager;

    [HideInInspector]
    public bool isInRound = true;

    [HideInInspector]
    public bool isInMatch = true;

    public int player1WinsCount = 0;

    public int player2WinsCount = 0;

    public int targetWinsCount = 3;
    
    public TextMeshProUGUI endingText;

    public float player1HP = 100;

    public float player2HP = 100;
    
    public Dictionary<string, float> bodyHitMultiplier = new Dictionary<string, float>();

    public float bodyMultiplier;

    public float headMultiplier;

    public float handMultiplier;

    public float legMultiplier;

    public GameObject jipoUI;

    // public HingeJoint2D player1FootJoint;
    //
    // public HingeJoint2D player1HandJoint;
    //
    // public HingeJoint2D player2FootJoint;
    //
    // public HingeJoint2D player2HandJoint;


    private void Awake()
    {
        // endingText = GameObject.Find("Ending Text").GetComponent<TextMeshProUGUI>();
        
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        isInRound = true;
        isInMatch = true;
        player1HP = player2HP;
        jipoUI.transform.localScale = Vector3.zero;

        bodyHitMultiplier.Add("Head", headMultiplier);
        bodyHitMultiplier.Add("Body", bodyMultiplier);
        bodyHitMultiplier.Add("Hand", handMultiplier);
        bodyHitMultiplier.Add("Leg", legMultiplier);
    }

    private void FixedUpdate()
    {
        if (player1HP <= 0 && isInRound)
        {
            isInRound = false;
            player2WinsCount += 1;
            if (player2WinsCount == targetWinsCount)
            {
                // endingText.text = "Right Wins";
                PlayUIAnimation();
                isInMatch = false;
            }
            else
            {
                // endingText.text = "Right Wins the Round";
                PlayUIAnimation();
                Invoke("ResetRound", 8f);
            }
        }
        
        if (player2HP <= 0 && isInRound)
        {
            isInRound = false;
            player1WinsCount += 1;
            if (player1WinsCount == targetWinsCount)
            {
                // endingText.text = "Left Wins";
                PlayUIAnimation();
                isInMatch = false;
            }
            else
            {
                // endingText.text = "Left Wins the Round";
                PlayUIAnimation();
                Invoke("ResetRound", 8f);
            }
        }
    }

    public void ResetRound()
    {
        isInRound = true;
        isInMatch = true;
        player1HP = player2HP = 100;
        endingText.text = "";
        jipoUI.transform.localScale = Vector3.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Invoke("CanvasGetMainCam",0.1f);
    }

    public void PlayUIAnimation()
    {
        Tween jipoTween = jipoUI.transform.DOScale(Vector3.one, 1f);
        jipoTween.Play();
    }

    public void CanvasGetMainCam()
    {
        GetComponentInChildren<Canvas>().worldCamera = Camera.main;
    }
}
