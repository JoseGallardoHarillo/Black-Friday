using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkMinigame : MonoBehaviour
{
    [Header("Work Settings")]
    [SerializeField] [TextArea(15,25)] private string workDescription;
    [SerializeField] private float workPayMin;
    [SerializeField] private float workPayMax;

    public string WorkDescription => workDescription;

    private float workPay;

    public virtual void SetupWork()
    {
        workPay = Random.Range(workPayMin, workPayMax);
    }

    public void FinishWork()
    {
        AudioManager.Instance.PlaySFX("complete");
        GameManager.Instance.ModifyMoney(workPay);
        gameObject.SetActive(false);
        WorkManagerUI.Instance.ChooseRandomMinigame();
    }
}
