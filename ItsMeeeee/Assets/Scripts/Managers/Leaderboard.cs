using LootLocker.Requests;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class Leaderboard : MonoBehaviour
{
    public TMP_InputField player;

    public List<TMP_Text> names;
    public List<TMP_Text> scores;

    public int ID;
    private string playerID;

    private void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Start Session");
                playerID = response.player_id.ToString();
                DisplayScores();
            }

            else
            {
                Debug.LogWarning("FAILED TO CONNECT");
            }
        });
    }

    public void SubmitScore()
    {
        LootLockerSDKManager.SetPlayerName(player.text, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Set player name");
                Submit();
            }
            else
            {
                Debug.LogWarning("COULD NOT SET PLAYER NAME");
            }
        });
    }

    private void Submit()
    {
        int score = Mathf.CeilToInt(GameManager.Instance.scoreManager.currentScore);
        LootLockerSDKManager.SubmitScore(playerID, score, ID, (response) =>
         {
             if (response.success)
             {
                 Debug.Log($"Submitted {score}");
                 DisplayScores();
             }
             else
             {
                 Debug.LogWarning("FAILED TO SUBMIT SCORE");
             }
         });

    }

    public void DisplayScores()
    {
        LootLockerSDKManager.GetScoreList(ID, names.Count, 0, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < names.Count; i++)
                {
                    if (i < members.Length)
                    {
                        names[i].text = members[i].player.name.ToString();
                        scores[i].text = members[i].score.ToString();
                    }
                    else
                    {
                        names[i].text = "";
                        scores[i].text = "";
                    }
                }
            }
            else
            {
                Debug.Log("FAILED TO GET SCORES");
            }
        });
    }
}
