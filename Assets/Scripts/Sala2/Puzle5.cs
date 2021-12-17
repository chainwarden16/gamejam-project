using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Puzle5 : MonoBehaviour
{
    [Header("Puzle de tubos")]
    const int anchoPanel = 4;
    const int largoPanel = 5;
    public List<PiezaTubo> gridTubos;
    public List<PiezaTubo> piezasSolucion;
    public List<int> estadosGiroSolucion;
    public GameObject tubos;

    bool estaResuelto;
    GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public void CerrarTubos()
    {
        Initiate.Fade("Sala2", Color.black, 1f);
    }

    public void ComprobarEstadoPuzle()
    {
        bool resuelto = true;

        for(int i = 0; i < piezasSolucion.Count; i++)
        {
            PiezaTubo estadoFinal = piezasSolucion[i];

            int indice = gridTubos.IndexOf(estadoFinal);

            PiezaTubo piezaActual = gridTubos[indice];

            if(piezaActual.GetEstadoGiro() != estadosGiroSolucion[i])
            {
                resuelto = false;
                Debug.Log("La pieza " + piezaActual.gameObject.name + " no coincide con el índice. Debería de tener índice: " + estadosGiroSolucion[i] + " y tiene: " + piezaActual.GetEstadoGiro());
                break;
            }
            else
            {
                Debug.Log("Coindicen en el índice "+i);
            }
        }

        if (resuelto)
        {
            estaResuelto = true;
            if(manager != null)
            {
                manager.SetPuzleResuelto(4, true);
            }
        }
        else
        {
            estaResuelto = false;
        }
    }

    public bool HaResueltoPuzle()
    {
        return estaResuelto;
    }

    public void SaltarPuzle()
    {
        estaResuelto = true;
        //aparece el objeto en el inventario del jugador
    }

}
