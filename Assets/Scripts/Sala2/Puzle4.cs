using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Puzle4 : MonoBehaviour
{
    [Header("Atributos para manipulación de texto")]
    public TextMeshProUGUI textoReloj;

    [Header("Puzle del reloj")]
    [SerializeField]
    int numeroMinutos;
    [SerializeField]
    int numeroHoras;
    [SerializeField]
    int horaActual;
    [SerializeField]
    int minutoActual;

    [Header("Indicador de si el cuarto puzle entero está completo")]
    [SerializeField]
    bool estaResuelto;
    GameManager manager;

    [Header("Audio")]
    AudioController audioC;
    public AudioClip completo, cancelar;

    void Start()
    {


        manager = FindObjectOfType<GameManager>();

        numeroHoras = PlayerPrefs.GetInt("HoraPuzle4", -1); //para cargarlo en la pista del microondas. se debe repetir ahí por si es lo primero que ve
        numeroMinutos = PlayerPrefs.GetInt("MinutoPuzle4", -1);

        if (numeroHoras == -1 || numeroMinutos == -1)
        {
            numeroHoras = UnityEngine.Random.Range(0, 23);
            numeroMinutos = UnityEngine.Random.Range(0, 59);

            PlayerPrefs.SetInt("HoraPuzle4", numeroHoras);
            PlayerPrefs.SetInt("MinutoPuzle4", numeroMinutos);
        }



        textoReloj.text = "0:00";
        /*
         * textoMicro.text = numeroHoras.ToString() + ":";
        if (numeroMinutos < 10)
        {
            textoMicro.text += "0";
        }

        textoMicro.text += numeroMinutos.ToString();
        */
    }

    private void Update()
    {
        ComprobarEstadoReloj();
    }

    public void CambiarHoraMas()
    {
        if (!estaResuelto)
        {
            if (horaActual < 23)
            {
                horaActual++;
            }
            else
            {
                horaActual = 0;
            }

            textoReloj.text = horaActual.ToString() + ":";

            if (minutoActual < 10)
            {
                textoReloj.text += "0";
            }

            textoReloj.text += minutoActual.ToString();

        }
 

    }

    public void CambiarHoraMenos()
    {
        if (!estaResuelto)
        {
            if (horaActual > 0)
            {

                horaActual--;

            }
            else
            {

                horaActual = 23;

            }

            textoReloj.text = horaActual.ToString() + ":";
            if (minutoActual < 10)
            {
                textoReloj.text += "0";
            }
            textoReloj.text += minutoActual.ToString();

        }


    }

    public void CambiarMinutoMas()
    {
        if (!estaResuelto)
        {
            if (minutoActual < 59)
            {
                minutoActual++;

            }
            else
            {
                minutoActual = 0;
            }
            textoReloj.text = horaActual.ToString() + ":";
            if (minutoActual < 10)
            {
                textoReloj.text += "0";
            }
            textoReloj.text += minutoActual.ToString();

        }

    }

    public void CambiarMinutoMenos()
    {
        if (!estaResuelto)
        {
            if (minutoActual > 0)
            {
                minutoActual--;
            }
            else
            {

                minutoActual = 59;

            }
            textoReloj.text = horaActual.ToString() + ":";
            if (minutoActual < 10)
            {
                textoReloj.text += "0";
            }
            textoReloj.text += minutoActual.ToString();

        }


    }

    public void ComprobarEstadoReloj()
    {
        if (minutoActual == numeroMinutos && horaActual == numeroHoras)
        {
            estaResuelto = true;

            audioC = FindObjectOfType<AudioController>();

            if (audioC != null)
            {
                audioC.PlaySFX(completo);
            }

            if (manager != null)
            {
                manager.SetPuzleResuelto(3, true);
                this.enabled = false;
            }
        }
    }

    public void CerrarReloj()
    {
        audioC = FindObjectOfType<AudioController>();
        if (audioC != null)
        {
            audioC.PlaySFX(cancelar);
        }
        Initiate.Fade("Sala2", Color.black, 1f);
    }

    public bool HaResueltoPuzle()
    {
        return estaResuelto;
    }

    public void SaltarPuzle()
    {
        estaResuelto = true;
        //aparece la llave en el inventario del jugador
    }

}
