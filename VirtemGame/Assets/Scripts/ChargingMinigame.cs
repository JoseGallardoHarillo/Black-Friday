using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChargingMinigame : WorkMinigame
{
    void Start()
    {
    }

    void Update()
    {
        
        if(SystemInfo.batteryStatus == BatteryStatus.Charging){
            FinishWork();
        }
    }

    public override void SetupWork()
    {
        base.SetupWork();
    }   
}