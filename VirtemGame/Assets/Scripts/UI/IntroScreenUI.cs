using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class IntroScreenUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMessage;
    private float timer = 0f;
    private int counter = 0;

    private void Start()
    {
        timer = 1f;
        counter = 0;
        textMessage.text = "3";
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            counter++;
            timer = 1f;

            if (counter == 1)
                textMessage.text = "2";
            if (counter == 2)
                textMessage.text = "1";
            if (counter == 3)
                textMessage.text = "COMPRA";
            if (counter == 4)
                textMessage.text = "TODO";
            if (counter == 5)
                gameObject.SetActive(false);
        }
    }
}
