using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using JetBrains.Annotations;
using Unity.VisualScripting;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager Instance;

    [SerializeField] private ItemListSO itemListSO;
    [SerializeField] private GameSettingsSO gameSettingsSO;

    [SerializeField] private GameObject quad;
    [SerializeField] private GameObject Caja;



    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one SpawnManager in scene!");
            return;
        }
        Instance = this;
    }

    public void Start() {
        StoreManager.Instance.OnSpawnBox += Instance_OnSpawnBox;
    }

    private void Instance_OnSpawnBox(object sender, StoreManager.OnSpawnBoxEventArgs e) {
        AudioManager.Instance.PlaySFX("box");
        GameObject ObjetoNuevo = Instantiate(Caja);
        TipoCapsula aux = ObjetoNuevo.GetComponent<TipoCapsula>();
        aux.Tipo = e.CapsuleType;
        aux.basePrice=e.basePrice;
        Vector3 posicionInicial = new Vector3 (UnityEngine.Random.Range(-6.5f,6.5f),UnityEngine.Random.Range(0,9.5f),UnityEngine.Random.Range(-16,-4f));
        ObjetoNuevo.transform.position = posicionInicial;
        ObjetoNuevo.transform.localScale = new Vector3(UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(1f, 2f), UnityEngine.Random.Range(1f, 2f));
        ObjetoNuevo.transform.rotation = Quaternion.Euler(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360));
    }

    private void Update()
    {

    }


}

