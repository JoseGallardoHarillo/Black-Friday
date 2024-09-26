using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodingMinigame : WorkMinigame
{
    

    [SerializeField] private TextMeshProUGUI codeText;
    [SerializeField] private int charactersPerKeyPress = 1;

    private int currentCharacterIndex = 0;

    private List<string> codeString = new List<string>()
    {
        "# Solve the quadratic equation ax**2 + bx + c = 0\r\n\r\n# import complex math module\r\nimport cmath\r\n\r\na = 1\r\nb = 5\r\nc = 6\r\n\r\n# calculate the discriminant\r\nd = (b**2) - (4*a*c)\r\n\r\n# find two solutions\r\nsol1 = (-b-cmath.sqrt(d))/(2*a)\r\nsol2 = (-b+cmath.sqrt(d))/(2*a)\r\n\r\nprint('The solution are {0} and {1}'.format(sol1,sol2))",
        "import random\r\n\r\ndef juego_adivinanza():\r\n    numero_secreto = random.randint(1, 100)\r\n    intentos = 0\r\n\r\n    print(\"Bienvenido al juego de adivinanza. Adivina el número secreto entre 1 y 100.\")\r\n\r\n    while True:\r\n        intento_usuario = int(input(\"Introduce tu intento: \"))\r\n        intentos += 1\r\n\r\n        if intento_usuario == numero_secreto:\r\n            print(f\"¡Felicidades! Adivinaste el número secreto {numero_secreto} en {intentos} intentos.\")\r\n            break\r\n        elif intento_usuario < numero_secreto:\r\n            print(\"El número es mayor. Intenta de nuevo.\")\r\n        else:\r\n            print(\"El número es menor. Intenta de nuevo.\")\r\n\r\nif _name_ == \"_main_\":\r\n    juego_adivinanza()",
        "import random\r\n\r\ndef reemplazar_con_numeros(texto):\r\n    texto_codificado = \"\"\r\n    for caracter in texto:\r\n        if caracter.isalpha():\r\n            # Reemplazar letras con números aleatorios\r\n            numero_random = random.randint(1, 26)\r\n            nuevo_caracter = str(numero_random)\r\n            texto_codificado += nuevo_caracter\r\n        else:\r\n            # Mantener otros caracteres sin cambios\r\n            texto_codificado += caracter\r\n    return texto_codificado\r\n\r\n# Ejemplo de uso\r\ntexto_original = \"Hola, mundo!\"\r\ntexto_codificado = reemplazar_con_numeros(texto_original)\r\n\r\nprint(\"Texto original:\", texto_original)\r\nprint(\"Texto codificado:\", texto_codificado)"
    };

    private int currentCodeIndex = 0;

private void Update()
    {
        if (Input.anyKeyDown 
            && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2))
        {
            for (int i = 0; i < charactersPerKeyPress; i++)
            {
                if (currentCharacterIndex < codeString[currentCodeIndex].Length)
                {
                    AudioManager.Instance.PlaySFX("coding");
                    codeText.text += codeString[currentCodeIndex][currentCharacterIndex];
                    currentCharacterIndex++;
                }
                else
                {
                    currentCharacterIndex=0;
                    FinishWork();
                }
            }
        }
    }

    public override void SetupWork()
    {
        base.SetupWork();

        currentCharacterIndex = 0;
        currentCodeIndex = Random.Range(0, codeString.Count);
        codeText.text = "";
    }
}
