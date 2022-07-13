using LowTeeGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public GameObject target;
    public GameObject decoy;
    public GameObject solarFlare;
    public Vector2 spawnDelay;
    public int rounds;
    public float timePerRound;
    enum GameState { Pause, Playing }
    GameState currentState = GameState.Playing;
    List<IUpdatable> updatables = new List<IUpdatable>();

    public SpawnManager spawnManager;
    public CameraBorderManager cameraBorderManager;
    public RoundManager roundManager;
    public InputManager inputManager;
    public ScoreManager scoreManager;

    private void Awake()
    {
        spawnManager = new SpawnManager(target, decoy, spawnDelay);
        roundManager = new RoundManager(rounds, timePerRound);
        cameraBorderManager = new CameraBorderManager();
        inputManager = new InputManager();
        scoreManager = new ScoreManager();

        updatables.Add(inputManager);
        updatables.Add(spawnManager);
        updatables.Add(roundManager);

        OnClickedEvent.RegisterListener(SpawnSolarFlare);
    }

    private void Update()
    {
        UpdateStateMachine();
    }

    private void UpdateStateMachine()
    {
        switch (currentState)
        {
            case GameState.Pause:
                break;
            case GameState.Playing:
                UpdateBehaviors();
                break;
            default:
                break;
        }
    }

    private void UpdateBehaviors()
    {
        updatables.ForEach(t => t.Update());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SpawnSolarFlare(OnClickedEvent info)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 spawnPos = new Vector3(mousePos.x, mousePos.y, 0);
        Pool.Instance.GetItemFromPool(solarFlare, spawnPos, Quaternion.identity);
    }
}
