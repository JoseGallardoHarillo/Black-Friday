using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreManagerSingleUI : MonoBehaviour
{
    [SerializeField] private bool isPopUp = false;
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemPriceText;
    [SerializeField] private TextMeshProUGUI itemBasePriceText;
    [SerializeField] private TextMeshProUGUI timeLeftText;
    [SerializeField] private TextMeshProUGUI discountText;
    [SerializeField] private Button buyButton;
    [SerializeField] private Animator animator;
    [SerializeField] private Button closeButton;

    private float secondsLeft;
    private bool isHidden = false;
    private Offer currentOffer;

    private void Start()
    {
        buyButton.onClick.AddListener(() => 
        {
            if (StoreManager.Instance.CanBuyItem(currentOffer.finalPrice))
            {
                StoreManager.Instance.BuyItem(currentOffer.itemSO, currentOffer.finalPrice, currentOffer.basePrice);
                AudioManager.Instance.PlaySFX("purchase");
                Hide();
            }
            else
            {
                // TODO: Shake offer and play SFX
                AudioManager.Instance.PlaySFX("cantAfford");
            }
        });

        if (isPopUp)
        {
            closeButton.onClick.AddListener(() => Hide());
        }
    }

    public void SetOfferUI(Offer offer)
    {
        currentOffer = offer;
        itemImage.sprite = offer.itemSO.itemSprite;
        itemBasePriceText.text = $"{offer.basePrice}€";
        itemPriceText.text = $"{offer.finalPrice}€";
        secondsLeft = offer.secondsLeft;
        discountText.text = $"-{offer.discount}%";

        int hours = (int)(offer.secondsLeft / 3600);
        int minutes = (int)((offer.secondsLeft % 3600) / 60);
        int seconds = (int)(offer.secondsLeft % 60);

        timeLeftText.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        isHidden = false;

        Show();
    }

    private void Update()
    {
        if (!isHidden)
        {
            secondsLeft -= Time.deltaTime;
            timeLeftText.text = $"{secondsLeft:F0}";

            if (secondsLeft <= 0)
            {
                ExpireOffer();
            }
        }
    }

    private void ExpireOffer()
    {
        AudioManager.Instance.PlaySFX("expire");
        Hide();
    }

    private void Show()
    {
        animator.SetTrigger("Show");
    }

    private void Hide()
    {
        animator.SetTrigger("Hide");
        isHidden = true;

        if (!isPopUp)
            StartCoroutine(WaitAndGetOffer());
        else
            Destroy(gameObject, 2f);
    }

    private IEnumerator WaitAndGetOffer()
    {
        yield return new WaitForSeconds(3f);

        SetOfferUI(StoreManager.Instance.GetOffer());
    }
}
