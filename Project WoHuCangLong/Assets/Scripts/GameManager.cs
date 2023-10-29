using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public bool isInRound = true;

    [HideInInspector]
    public bool isInMatch = true;

    [HideInInspector]
    public bool isInTitle = true;
    
    [HideInInspector]
    public bool isGameStart = false;

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

    [HideInInspector]
    public CinemachineVirtualCamera titleCam;

    // public float countDownTime = 3f;

    // private float timer;

    private TextMeshProUGUI countDownText;
    
    // private Sequence countDownSequence;

    private void Awake()
    {
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
        isInRound = false;
        isInMatch = false;
        isGameStart = false;
        // timer = countDownTime;
        player1HP = player2HP;
        jipoUI.transform.localScale = Vector3.zero;

        bodyHitMultiplier.Add("Head", headMultiplier);
        bodyHitMultiplier.Add("Body", bodyMultiplier);
        bodyHitMultiplier.Add("Hand", handMultiplier);
        bodyHitMultiplier.Add("Leg", legMultiplier);

        countDownText = GameObject.Find("Count Down Text").GetComponent<TextMeshProUGUI>();
        titleCam = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (isInTitle)
        {
            titleCam.Priority = 11;
        }
        else
        {
            titleCam.Priority = 9;
            if (!isGameStart)
            {
                isGameStart = true;
                Invoke("PlayCountDownAnimation", 1.5f);
                print("First Animation Played");
                // timer = countDownTime + 1.5f;
            }
        }
        
        // if (timer >= 0 && !isInTitle) 
        // {
        //     RoundStartCountDown();
        // }
        
        if (player1HP <= 0 && isInRound)
        {
            isInRound = false;
            player2WinsCount += 1;
            if (player2WinsCount == targetWinsCount)
            {
                // endingText.text = "Right Wins";
                Invoke("PlayUIAnimation", 0.1f);
                isInMatch = false;
            }
            else
            {
                // endingText.text = "Right Wins the Round";
                Invoke("PlayUIAnimation", 0.1f);
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
                Invoke("PlayUIAnimation", 0.1f);
                isInMatch = false;
            }
            else
            {
                // endingText.text = "Left Wins the Round";
                Invoke("PlayUIAnimation", 0.1f);
                Invoke("ResetRound", 8f);
            }
        }
    }

    public void ResetRound()
    {
        isInRound = false;
        isInMatch = false;
        // timer = countDownTime;
        player1HP = player2HP = 100;
        endingText.text = "";
        jipoUI.transform.localScale = Vector3.zero;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Invoke("CanvasGetMainCam",0.01f);
        Invoke("PlayCountDownAnimation", 0.01f);
        // Invoke("PlayStartMusic", 0.01f);
    }

    // public void RoundStartCountDown()
    // {
    //     timer -= Time.deltaTime;
    //
    //     if (timer <= 3 & timer >= 0) 
    //     {
    //         if (!countDownSequence.IsPlaying()) countDownSequence.Play();
    //     }
    //
    //
    //     if (timer >= 2)
    //     {
    //         countDownText.text = "bam";
    //     }
    //
    //     if (timer >= 1 && timer < 2) 
    //     {
    //         countDownText.text = "boom";
    //     }
    //
    //     if (timer > 0 && timer < 1)
    //     {
    //         countDownText.text = "blade!";
    //     }
    //
    //     if (timer <= 0)
    //     {
    //         isInMatch = true;
    //         isInRound = true;
    //         countDownText.text = "";
    //     }
    // }

    // public void PlayStartMusic()
    // {
    //     
    // }

    public void PlayCountDownAnimation()
    {
        if (!isInTitle)
        {
            Sequence countDownSequence = DOTween.Sequence();
            countDownSequence
                .Append(countDownText.transform.DOScale(0, 0))
                .Append(countDownText.DOText("BAM",0))
                .Append(countDownText.transform.DOScale(1, 0.5f))
                .AppendInterval(0.5f)
                .Append(countDownText.transform.DOScale(0, 0))
                .Append(countDownText.DOText("BOOM",0))
                .Append(countDownText.transform.DOScale(1, 0.5f))
                .AppendInterval(0.5f)
                .Append(countDownText.transform.DOScale(0, 0))
                .Append(countDownText.DOText("BLADE!",0))
                .Append(countDownText.transform.DOScale(1, 0.5f))
                .AppendInterval(0.5f)
                .Append(countDownText.DOText("",0))
                .OnComplete((() =>
                {
                    isInMatch = true;
                    isInRound = true;
                }));
        
            if (!countDownSequence.IsPlaying()) countDownSequence.Play();
            // print("Animation Played");
        
            GameObject.Find("612").GetComponent<AudioSource>().Play();
        }
    }

    public void PlayTutorialAnimation()
    {
        Sequence tutorialSequence = DOTween.Sequence();
        SpriteRenderer tutorial = GameObject.Find("Tutorial").GetComponent<SpriteRenderer>();
        tutorialSequence
            .Append(tutorial.DOFade(0,0))
            .Append(tutorial.DOFade(1, 1f))
            .AppendInterval(3)
            .Append(tutorial.DOFade(0, 1f))
            .OnComplete((() =>
            {
                isInTitle = false;
                isInMatch = true;
            }));

        if (!tutorialSequence.IsPlaying()) tutorialSequence.Play();
    }

    public void PlayUIAnimation()
    {
        Tween jipoTween = jipoUI.transform.DOScale(Vector3.one, 1f).SetUpdate(true);
        jipoTween.Play();
    }

    public void CanvasGetMainCam()
    {
        GetComponentInChildren<Canvas>().worldCamera = Camera.main;
    }
}
