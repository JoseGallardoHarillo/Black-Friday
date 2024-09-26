using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu()]
public class GameSoundsSO : ScriptableObject
{
    [Header("Store")]
    public AudioClip popupAppear;
    public AudioClip purchaseItem;
    public AudioClip cantAfford;
    public AudioClip offerExpire;
    [Header("Jobs")]
    public AudioClip completeJob;
    public AudioClip codingKeystroke;
    [Header("Room")]
    public AudioClip boxArrived;
    public AudioClip openBox;
}
