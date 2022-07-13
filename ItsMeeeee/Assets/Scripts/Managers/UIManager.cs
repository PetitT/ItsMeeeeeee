using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public TMP_Text currentRound;
    public TMP_Text status;
    public TMP_Text lastStatus;
    public TMP_Text score;

    public GameObject scoreBoard;

    private void Start()
    {
        OnRoundBeginEvent.RegisterListener(OnRoundBegin);
        OnClickedEvent.RegisterListener(OnClick);
        OnRoundEndEvent.RegisterListener(OnRoundEnd);
        OnGameOverEvent.RegisterListener(OnGameOver);

        scoreBoard.SetActive(false);
    }

    private void Update()
    {
        UpdateSlider();
        UpdateScore();
    }

    private void UpdateScore()
    {
        score.text = $"Score : { Mathf.CeilToInt(GameManager.Instance.scoreManager.currentScore)}";
    }

    private void UpdateSlider()
    {
        float current = GameManager.Instance.roundManager.remainingTimeInRound;
        float total = GameManager.Instance.roundManager.timePerRound;
        float normalized = current / total;
        healthBar.value = normalized;

    }

    private void OnRoundEnd(OnRoundEndEvent info)
    {
        if (status.text == "")
        {
            status.text = "Twitch obliterated your team !";
        }
    }

    private void OnClick(OnClickedEvent info)
    {
        switch (info.target)
        {
            case TargetType.Nothing:
                status.text = "You missed, idiot";
                break;
            case TargetType.Decoy:
                status.text = "Wrong target, dumbass";
                break;
            case TargetType.Target:
                status.text = "Yeah fuck you, Twitch !";
                break;
            default:
                break;
        }


    }

    private void OnRoundBegin(OnRoundBeginEvent info)
    {
        currentRound.text = $"Round {info.newRound}";
        status.text = "";
    }


    private void OnGameOver(OnGameOverEvent info)
    {
        status.text = "";
        lastStatus.text = $"Final Score : { Mathf.CeilToInt(GameManager.Instance.scoreManager.currentScore)}/100";
        scoreBoard.SetActive(true);
    }

    private void CreateLeaderBoard()
    {
        Social.CreateLeaderboard();
    }
}
