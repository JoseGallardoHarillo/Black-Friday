using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EventHandler OnModifyMoney;

    public static GameManager Instance { get; private set; }

    [SerializeField] private GameSettingsSO gameSettingsSO;

    private float currentGameSecondsLeft;
    private float currentRealSecondsLeft;
    private float secondsPerSecond;

    private float currentMoney;

    public float currentScore;

    public float CurrentGameSecondsLeft => currentGameSecondsLeft;
    public float CurrentRealSecondsLeft => currentRealSecondsLeft;
    public float CurrentMoney => currentMoney;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentGameSecondsLeft = 24f * 60f * 60f; // Seconds in a day
        currentRealSecondsLeft = gameSettingsSO.secondsPerGame;

        secondsPerSecond = currentGameSecondsLeft / currentRealSecondsLeft;

        currentMoney = 0;
        ModifyMoney(gameSettingsSO.initialMoney);
        currentScore = 0;
    }

    void Update()
    {
        currentGameSecondsLeft -= Time.deltaTime * secondsPerSecond;
        currentRealSecondsLeft -= Time.deltaTime;
    }

    public void ModifyMoney(float amount)
    {
        currentMoney += amount;
        currentMoney = Mathf.Round(currentMoney * 100f) / 100f;
        OnModifyMoney?.Invoke(this, EventArgs.Empty);
    }

    public void AddScore(float amount)
    {
        currentScore += amount;
    }
}
