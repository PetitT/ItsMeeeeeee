using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    public float currentScore;

    public void AddScore(float score)
    {
        currentScore += score;
    }
}
