using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzle6 : MonoBehaviour
{

    [Header("Puzle de Hanoi")]
    [SerializeField]
    int piezasColocadas;
    public GameObject hanoi;
    public List<GameObject> piezasHanoi;


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

    public void ComprobarEstadoHanoi()
    {

    }

    public void CerrarHanoi()
    {

    }

    public void AbrirHanoi()
    {


    }

    public void MoverDisco()
    {
        if(piezasColocadas == 4 && !estaResuelto)
        {

        }
    }

    public void AñadirDisco()
    {
        if (inventario.GetObjetoSeleccionado().GetNombre() == "Donut" && piezasColocadas < 4)
        {

            piezasHanoi[piezasColocadas].SetActive(true);
            piezasColocadas++;
            inventario.EliminarObjeto(inventario.GetObjetos().IndexOf(inventario.GetObjetoSeleccionado()));
            inventario.DeseleccionarObjeto();
        }


    }


    public bool HaResueltoPuzle()
    {
        return estaResuelto;
    }

}
