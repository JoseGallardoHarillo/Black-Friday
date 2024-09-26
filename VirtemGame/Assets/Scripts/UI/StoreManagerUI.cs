using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeLeftText;
    [SerializeField] private Transform container;
    [SerializeField] private Transform baseOfferTemplate;
    [SerializeField] private Transform popupPrefab;
    [SerializeField] private Canvas canvas;

    private void Start()
    {
        StoreManager.Instance.OnSpawnPopup += Instance_OnSpawnPopup;
        baseOfferTemplate.gameObject.SetActive(false);

        for (int i = 0; i < 4; i++)
        {
            StoreManagerSingleUI baseOfferUI = Instantiate(baseOfferTemplate, container).GetComponent<StoreManagerSingleUI>();
            baseOfferUI.gameObject.SetActive(true);
            baseOfferUI.SetOfferUI(StoreManager.Instance.GetOffer());
        }
    }

    private void Instance_OnSpawnPopup(object sender, StoreManager.OnSpawnPopupEventArgs e)
    {
        StoreManagerSingleUI popupUI = Instantiate(popupPrefab, canvas.transform).GetComponent<StoreManagerSingleUI>();
        popupUI.transform.position = new Vector3(UnityEngine.Random.Range(200, Screen.width - 200), UnityEngine.Random.Range(200, Screen.height - 200), 0f);
        popupUI.gameObject.SetActive(true);
        popupUI.SetOfferUI(e.offer);
    }

    void Update()
    {
        float timeLeft = GameManager.Instance.CurrentRealSecondsLeft;
        int hours = (int)(timeLeft / 3600);
        int minutes = (int)((timeLeft % 3600) / 60);
        int seconds = (int)(timeLeft % 60);
        timeLeftText.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }
}
