using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private GameSoundsSO gameSoundsSO;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        StoreManager.Instance.OnSpawnPopup += Instance_OnSpawnPopup;
    }

    private void Instance_OnSpawnPopup(object sender, StoreManager.OnSpawnPopupEventArgs e)
    {
        PlaySFX("popup");
    }

    public void PlaySFX(string tag)
    {
        switch (tag)
        {
            case "popup":
                sfxSource.PlayOneShot(gameSoundsSO.popupAppear);
                break;
            case "purchase":
                sfxSource.PlayOneShot(gameSoundsSO.purchaseItem);
                break;
            case "cantAfford":
                sfxSource.PlayOneShot(gameSoundsSO.cantAfford);
                break;
            case "expire":
                sfxSource.PlayOneShot(gameSoundsSO.offerExpire);
                break;
            case "complete":
                sfxSource.PlayOneShot(gameSoundsSO.completeJob);
                break;
            case "coding":
                sfxSource.PlayOneShot(gameSoundsSO.codingKeystroke);
                break;
            case "box":
                sfxSource.PlayOneShot(gameSoundsSO.boxArrived);
                break;
            case "open":
                sfxSource.PlayOneShot(gameSoundsSO.openBox);
                break;
            default:
                break;
        }
    }
}
