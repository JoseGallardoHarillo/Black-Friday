using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ScoreText;

    // Update is called once per frame
    void Update() {
        ScoreText.text = "Nivel de Felicidad: " + GameManager.Instance.currentScore;
    }
}
