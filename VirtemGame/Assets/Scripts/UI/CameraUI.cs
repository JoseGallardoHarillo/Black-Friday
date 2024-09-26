using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUI : MonoBehaviour
{
    [SerializeField] private Camera habitacion;
    [SerializeField] private  Camera UI;

    [SerializeField] private Canvas CanvasUI;
    [SerializeField] private Canvas ScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        UI.enabled= true;
        habitacion.enabled=false;
    }

    // Update is called once per frame
    public void PasaraHabitacion() {
        UI.enabled = false;
        habitacion.enabled = true;
        CanvasUI.enabled = false;
        ScoreUI.enabled = true;
    }
    public void PasaraUI() {
        UI.enabled=true;
        habitacion.enabled=false;
        CanvasUI.enabled = true;
        ScoreUI.enabled = false;
    }
}
