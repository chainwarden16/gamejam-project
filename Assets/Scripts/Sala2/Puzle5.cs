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

    private void Start()
    {
        
    }

    public void AbrirTubos()
    {


    }

    public void CerrarTubos()
    {

    }

    public bool ComprobarEstadoPuzle()
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
                Debug.Log("La pieza " + piezaActual.gameObject.name + " no coincide con el �ndice. Deber�a de tener �ndice: " + estadosGiroSolucion[i] + " y tiene: " + piezaActual.GetEstadoGiro());
                break;
            }
            else
            {
                Debug.Log("Coindicen todas.");
            }
        }

        return resuelto;
    }

    public bool HaResueltoPuzle()
    {
        return estaResuelto;
    }
}
