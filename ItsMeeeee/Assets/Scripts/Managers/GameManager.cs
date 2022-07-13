using LowTeeGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public GameObject target;
    public GameObject decoy;
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
}
