using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GameSettingsSO : ScriptableObject
{
    [Header("General")]
    public float secondsPerGame = 180f;
    public float initialMoney = 1000f;

    [Header("Store")]
    public float secondsLeftMin = 5f;
    public float secondsLeftMax = 30f;
    public int discountMin = 5;
    public int discountMax = 95;
    public float popupSpawnTimeMin = 10f;
    public float popupSpawnTimeMax = 30f;
    public int minPopupNumber = 1;
    public int maxPopupNumber = 3;

    public float GetRandomPopupSpawnTime()
    {
        return UnityEngine.Random.Range(popupSpawnTimeMin, popupSpawnTimeMax);
    }
}
