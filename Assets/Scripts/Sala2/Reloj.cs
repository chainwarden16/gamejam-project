using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reloj : MonoBehaviour
{

    [Header("Atributos para manipulación de texto")]
    public TextMeshProUGUI textoMicro;

    [Header("Puzle del reloj")]
    [SerializeField]
    int numeroMinutos;
    [SerializeField]
    int numeroHoras;
    void Start()
    {
        numeroHoras = PlayerPrefs.GetInt("HoraPuzle4", -1); //para cargarlo en la pista del microondas. se debe repetir ahí por si es lo primero que ve
        numeroMinutos = PlayerPrefs.GetInt("MinutoPuzle4", -1);

        if (numeroHoras == -1 || numeroMinutos == -1)
        {
            numeroHoras = UnityEngine.Random.Range(0, 23);
            numeroMinutos = UnityEngine.Random.Range(0, 59);

            PlayerPrefs.SetInt("HoraPuzle4", numeroHoras);
            PlayerPrefs.SetInt("MinutoPuzle4", numeroMinutos);

        }

        textoMicro.text = numeroHoras.ToString() + ":";
        if (numeroMinutos < 10)
        {
            textoMicro.text += "0";
        }

        textoMicro.text += numeroMinutos.ToString();

        gameObject.SetActive(false);
    }

}
