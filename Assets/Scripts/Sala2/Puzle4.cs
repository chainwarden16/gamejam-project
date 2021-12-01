using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Puzle4 : MonoBehaviour
{
    [Header("Atributos para manipulación de texto")]
    public TextMeshProUGUI textoMicro;
    public TextMeshProUGUI textoReloj;

    [Header("Puzle del reloj")]
    int numeroMinutos;
    int numeroHoras;
    [SerializeField]
    int horaActual;
    [SerializeField]
    int minutoActual;

    [Header("Indicador de si el cuarto puzle entero está completo")]
    [SerializeField]
    bool estaResuelto;

    void Start()
    {

        numeroHoras = UnityEngine.Random.Range(0, 23);
        numeroMinutos = UnityEngine.Random.Range(0, 59);
        textoMicro.text = numeroHoras.ToString() + ":";
        textoReloj.text = "0:00";
        if (numeroMinutos < 10)
        {
            textoMicro.text += "0";
        }

        textoMicro.text += numeroMinutos.ToString();

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
        else
        {
            Debug.Log("Puzle 4 resuelto");
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
        else
        {
            Debug.Log("Puzle 4 resuelto");
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
        else
        {
            Debug.Log("Puzle 4 resuelto");
        }

    }

    public void CambiarMinutoMenos()
    {
        if (!estaResuelto)
        {
            if(minutoActual > 0)
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
        else
        {
            Debug.Log("Puzle 4 resuelto");
        }

    }

    public void ComprobarEstadoReloj()
    {
        if (minutoActual == numeroMinutos && horaActual == numeroHoras)
        {
            estaResuelto = true;
        }
    }

    public void AbrirReloj()
    {

    }

    public void CerrarReloj()
    {

    }

    public bool HaResueltoPuzle()
    {
        return estaResuelto;
    }



}
