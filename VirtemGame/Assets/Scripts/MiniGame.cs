using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{

    public Main main;
    public String GameType = "PROGRAMAR";
    public float progress = 0;
    public Canvas miniGameUI;
    private Slider ProgressBar = null;
    private Text Titulo = null;
    private Text Recompensa = null;
    private Array textos = null;
    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (main.inminigame) {
            miniGameUI.gameObject.SetActive(true);
            if (ProgressBar==null) {
                ProgressBar = miniGameUI.GetComponentInChildren<Slider>();
                textos = miniGameUI.GetComponentsInChildren<Text>();
                Titulo = (Text) textos.GetValue(0);
                Recompensa = (Text) textos.GetValue(1);
            } else {
            if (GameType=="PROGRAMAR") {
                Titulo.text = "PROGRAMA!";
                Recompensa.text = "Recompensa: "+100.ToString()+"€";
                if (Input.anyKeyDown) {
                    progress+=(float).02;
                }
                if (progress>=1) {
                    progress = 0;
                    main.inminigame=false;
                }
            }
            ProgressBar.value=progress;
            }
        } else {
            miniGameUI.gameObject.SetActive(false);
            ProgressBar=null;
        }
        
    }
}
