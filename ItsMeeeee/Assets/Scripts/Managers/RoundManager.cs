using LowTeeGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : IUpdatable
{
    int rounds;
    public float timePerRound;
    float endRoundTime = 2;

    bool waitingForEnd;
    bool isTargetActive;
    int currentRound;
    public float remainingTimeInRound;
    float remainingEndRoundTime;

    public RoundManager(int rounds, float timePerRound)
    {
        this.rounds = rounds;
        this.timePerRound = timePerRound;

        currentRound = 1;
        remainingTimeInRound = timePerRound;
        remainingEndRoundTime = endRoundTime;

        OnTargetAppearedEvent.RegisterListener(OnTargetAppeared);
        OnClickedEvent.RegisterListener(OnClicked);
        isTargetActive = false;
    }

    private void OnClicked(OnClickedEvent info)
    {
        if (info.target == TargetType.Target)
        {
            float score = remainingTimeInRound / timePerRound * 10;
            GameManager.Instance.scoreManager.AddScore(score);
        }

        EndRound();
    }

    private void OnTargetAppeared(OnTargetAppearedEvent info)
    {
        isTargetActive = true;
    }

    public void Update()
    {
        if (isTargetActive && currentRound <= rounds)
        {
            Timer.CountDown(ref remainingTimeInRound, EndRound);
        }

        if (waitingForEnd)
        {
            Timer.CountDown(ref remainingEndRoundTime, BeginRound);
        }
    }

    private void EndRound()
    {
        isTargetActive = false;
        foreach (var item in GameObject.FindObjectsOfType<Spawnable>())
        {
            item.gameObject.SetActive(false);
        }
        waitingForEnd = true;
        OnRoundEndEvent onRoundEndEvent = new OnRoundEndEvent();
        onRoundEndEvent.FireEvent();
    }

    private void BeginRound()
    {
        waitingForEnd = false;
        remainingTimeInRound = timePerRound;
        currentRound++;
        if (currentRound <= rounds)
        {
            OnRoundBeginEvent onRoundBeginEvent = new OnRoundBeginEvent() { newRound = currentRound };
            onRoundBeginEvent.FireEvent();
            remainingEndRoundTime = endRoundTime;
        }
        else
        {
            OnGameOverEvent onGameOverEvent = new OnGameOverEvent();
            onGameOverEvent.FireEvent();
        }
    }
}
