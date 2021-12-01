using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzle6 : MonoBehaviour
{

    [Header("Puzle de Hanoi")]
    [SerializeField]
    int piezasColocadas;
    public GameObject hanoi;


    [Header("Puzle de gatos")]
    bool gatosAlimentados;
    public GameObject gatos;

    bool estaResuelto;

    Inventario inventario;

    public void AbrirGatos()
    {

    }

    public void CerrarGatos()
    {

    }

    public void ComprobarEstadoGatos()
    {

    }

    public void CerrarHanoi()
    {

    }

    public void AbrirHanoi()
    {


    }

    public void AñadirDisco()
    {
        foreach (Objeto obje in inventario.GetObjetos())
        {
            if (obje.GetNombre() == "Donut")
            {
                //Se añade al montón de donuts. Si son 4, empieza el puzle
            }
        }
    }

    public bool HaResueltoPuzle()
    {
        return estaResuelto;
    }

}
