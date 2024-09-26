using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorkManagerUI : MonoBehaviour
{
    public static WorkManagerUI Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI currentMoneyText;
    [SerializeField] private TextMeshProUGUI workInstructionsText;
    [SerializeField] private List<Transform> minigameTransforms;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.Instance.OnModifyMoney += Instance_OnModifyMoney;

        ChooseRandomMinigame();
    }

    private void Instance_OnModifyMoney(object sender, EventArgs e)
    {
        currentMoneyText.text = $"{GameManager.Instance.CurrentMoney}€";
    }

    public void ChooseRandomMinigame()
    {
        int randomIndex = UnityEngine.Random.Range(0, minigameTransforms.Count);
        //Si esta en el minijuego de carga y ya esta cargando se cambia de minijuego
        if((randomIndex == 3) && (SystemInfo.batteryStatus == BatteryStatus.Charging)) randomIndex = randomIndex - 1;
        minigameTransforms[randomIndex].GetComponent<WorkMinigame>().SetupWork();
        workInstructionsText.text = minigameTransforms[randomIndex].GetComponent<WorkMinigame>().WorkDescription;
        minigameTransforms[randomIndex].gameObject.SetActive(true);
    }
}
