using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using static UnityEditor.Progress;

public class StoreManager : MonoBehaviour
{
    public EventHandler<OnSpawnPopupEventArgs> OnSpawnPopup;

    public class OnSpawnPopupEventArgs : EventArgs
    {
        public Offer offer;
    }

    public EventHandler<OnSpawnBoxEventArgs> OnSpawnBox;

    public class OnSpawnBoxEventArgs : EventArgs
    {
        public float basePrice;
        public String CapsuleType;
    }

    public static StoreManager Instance;


    [SerializeField] private ItemListSO itemListSO;
    [SerializeField] private GameSettingsSO gameSettingsSO;


    private float popupSpawnTimer = 0f;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one StoreManager in scene!");
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        popupSpawnTimer = gameSettingsSO.GetRandomPopupSpawnTime();
    }

    private void Update()
    {
        popupSpawnTimer -= Time.deltaTime;
        if (popupSpawnTimer <= 0f)
        {
            int popupsToSpawn = UnityEngine.Random.Range(gameSettingsSO.minPopupNumber, gameSettingsSO.maxPopupNumber);
            for (int i = 0; i < popupsToSpawn; i++)
            {
                OnSpawnPopup?.Invoke(this, new OnSpawnPopupEventArgs
                {
                    offer = GetOffer()
                });
            }
            popupSpawnTimer = gameSettingsSO.GetRandomPopupSpawnTime();
        }
    }

    private ItemSO GetRandomItem()
    {
        return itemListSO.itemSOList[UnityEngine.Random.Range(0, itemListSO.itemSOList.Count)];
    }

    public Offer GetOffer()
    {
        ItemSO itemSO = GetRandomItem();
        float price = UnityEngine.Random.Range(itemSO.itemPriceMin, itemSO.itemPriceMax);
        price = Mathf.Round(price * 100f) / 100f;
        int discount = UnityEngine.Random.Range(gameSettingsSO.discountMin, gameSettingsSO.discountMax);
        float secondsLeft = UnityEngine.Random.Range(gameSettingsSO.secondsLeftMin, gameSettingsSO.secondsLeftMax);
        return new Offer(itemSO, price, discount, secondsLeft);
    }

    public bool CanBuyItem(float price)
    {
        return (GameManager.Instance.CurrentMoney >= price);
    }

    public void BuyItem(ItemSO itemSO, float price, float basePrice)
    {
        GameManager.Instance.ModifyMoney(-price);
        StartCoroutine(WaitAndSpawnBox(basePrice, itemSO.itemName));
    }

    private IEnumerator WaitAndSpawnBox(float basePrice, string capsuleType)
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(2f,5f));

        OnSpawnBox?.Invoke(this, new OnSpawnBoxEventArgs
        {
            basePrice = basePrice,
            CapsuleType = capsuleType
        });
    }
}

public class Offer
{
    public ItemSO itemSO;
    public float basePrice;
    public int discount;
    public float finalPrice;
    public float secondsLeft;

    public Offer(ItemSO itemSO, float basePrice, int discount, float secondsLeft)
    {
        this.itemSO = itemSO;
        this.basePrice = basePrice;
        this.discount = discount;
        finalPrice = basePrice * (1f - discount / 100f);
        finalPrice = Mathf.Round(finalPrice * 100f) / 100f;
        this.secondsLeft = secondsLeft;
    }
}
