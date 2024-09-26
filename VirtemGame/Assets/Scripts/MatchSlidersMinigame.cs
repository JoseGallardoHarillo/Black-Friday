using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchSlidersMinigame : WorkMinigame
{
    [SerializeField] private TextMeshProUGUI codeText;
    [SerializeField] private Slider modelo1;
    [SerializeField] private Slider match1;
    [SerializeField] private Slider modelo2;
    [SerializeField] private Slider match2;
    [SerializeField] private Slider modelo3;
    [SerializeField] private Slider match3;
    [SerializeField] private float strictness;
    private List<bool> resultados = new List<bool>();

    private void Start() 
    {
    }

    private void Update()
    {

        if (AbsoluteValueDiff(modelo1.value,match1.value,0)<strictness) {
            resultados[0]=true;
        } else {
            resultados[0]=false;
        }
        if (AbsoluteValueDiff(modelo2.value,match2.value,0)<strictness) {
            resultados[1]=true;
        } else {
            resultados[1]=false;
        }
        if (AbsoluteValueDiff(modelo3.value,match3.value,0)<strictness) {
            resultados[2]=true;
        } else {
            resultados[2]=false;
        }
        if (!resultados.Contains(false)) {
            resultados.Clear();
            FinishWork();
        }
    }

    private float AbsoluteValueDiff(float value1, float value2, float res) {
        res = value1-value2;
        if (res>0) {
            return res;
        } else {
            return -res;
        }
    }
    public override void SetupWork()
    {
        base.SetupWork();
        resultados.Clear();
        resultados.Add(false);
        resultados.Add(false);
        resultados.Add(false);
        modelo1.value = Random.Range((float)0, 1);
        modelo2.value = Random.Range((float)0, 1);
        modelo3.value = Random.Range((float)0, 1);
        match1.value=(float)0;
        match2.value=(float)0;
        match3.value=(float)0;
    }
}
