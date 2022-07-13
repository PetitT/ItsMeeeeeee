using LowTeeGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : IUpdatable
{
    GameObject target;
    GameObject decoy;
    Vector2 spawnDelay;
    int initialProbability = 5;

    float remainingSpawnDelay;
    int remainingProbability;

    bool isSpawning = true;

    public SpawnManager(GameObject target, GameObject decoy, Vector2 spawnDelay)
    {
        this.target = target;
        this.decoy = decoy;
        this.spawnDelay = spawnDelay;

        OnRoundEndEvent.RegisterListener(EndRound);
        OnRoundBeginEvent.RegisterListener(BeginNewRound);
        ResetRound();
    }

    private void EndRound(OnRoundEndEvent info)
    {
        isSpawning = false;
    }

    private void ResetRound()
    {
        isSpawning = true;
        remainingSpawnDelay = spawnDelay.RandomRange();
        remainingProbability = initialProbability;
    }

    private void BeginNewRound(OnRoundBeginEvent info)
    {
        ResetRound();
    }

    public void Update()
    {
        if (!isSpawning) return;
        Timer.CountDown(ref remainingSpawnDelay, SpawnMinion);
    }

    private void SpawnMinion()
    {
        int random = UnityEngine.Random.Range(0, remainingProbability);
        GameObject spawnedObject;
        if (random == 0)
        {
            spawnedObject = target;
        }
        else
        {
            spawnedObject = decoy;
            remainingProbability--;
            remainingSpawnDelay = spawnDelay.RandomRange();
        }

        Pool.Instance.GetItemFromPool(spawnedObject, GameManager.Instance.cameraBorderManager.GetRandomPointInScreenBounds(2), Quaternion.identity);
    }
}
