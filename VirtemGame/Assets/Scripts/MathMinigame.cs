using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuintoJuego : WorkMinigame
{
    /*
    [SerializeField] private TextMeshProUGUI codeText;
    [SerializeField] private Slider barraCarga;
    [SerializeField] private Button boton;

    private bool semaforo = true;
    private bool cargando = false;
    private float tiempoCarga;

    private float divisor;

    void Start()
    {
        // Añade un listener al botón para que llame a tu método cuando se haga clic
        boton.onClick.AddListener(PulsarBoton);
    }

    public void PulsarBoton()
    {
        barraCarga.gameObject.SetActive(true);
        // Realiza acciones adicionales aquí

        if(semaforo) CargaDeBarra();
    }

    void Update()
    {

        if (cargando)
        {
            // Reduce el tiempo de carga y actualiza el valor de la barra
            tiempoCarga -= Time.deltaTime;
            float progreso = 1.0f - (tiempoCarga / divisor); // Normaliza el tiempo de carga a un valor entre 0 y 1
            barraCarga.value = progreso;

            // Comprueba si la carga ha terminado
            if (tiempoCarga <= 0.0f)
            {
                cargando = false;
                tiempoCarga=1.0f;
                FinishWork();
            }
        }
    }

    void CargaDeBarra(){
        cargando = true;
        tiempoCarga = ObtenerTiempoAleatorio();
        semaforo = false;
    }

    float ObtenerTiempoAleatorio()
    {
        // Crea una instancia de Random
        System.Random random = new System.Random();

        // Genera un número decimal aleatorio en el rango [0, 1)
        double randomDouble = random.NextDouble();

        // Escala el número al rango [10, 60) segundos
        float tiempoCarga = Mathf.Lerp(10f, 60f, (float)randomDouble);

        divisor = tiempoCarga;
        return tiempoCarga;
    }

        public override void SetupWork()
    {
        base.SetupWork();
        semaforo = true;
        cargando = false;
        barraCarga.value=0;
    }
*/

    
}