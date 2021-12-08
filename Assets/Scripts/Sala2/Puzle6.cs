using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzle6 : MonoBehaviour
{

    [Header("Puzle de Hanoi")]
    [SerializeField]
    int piezasColocadas;
    public GameObject hanoi;
    public List<Donut> piezasHanoi1;
    public List<Donut> piezasHanoi2;
    public List<Donut> piezashanoi3;

    Donut discoSeleccionado;


    [Header("Puzle de gatos")]
    bool gatosAlimentados;
    public GameObject gatos;

    [SerializeField]
    bool sePuedeMoverDisco;
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
        bool resuelto = true;
        if (piezashanoi3.Count == 4)
        {

            for (int i = 0; i < piezashanoi3.Count; i++)
            {
                int tamaño = 4;
                if (piezashanoi3[i].GetSize() != tamaño - i)
                {
                    resuelto = false;
                    break;
                }
            }

        }
        else
        {
            resuelto = false;
        }

        estaResuelto = resuelto;

    }

    public void CerrarHanoi()
    {

    }

    public void AbrirHanoi()
    {


    }

    public List<List<Donut>> GetEstadoVarillas()
    {
        List<List<Donut>> varillas = new List<List<Donut>> { piezasHanoi1, piezasHanoi2, piezashanoi3 };

        return varillas;
    }

    public void SePuedeMoverDisco()
    {
        if (piezasColocadas == 4)
        {
            sePuedeMoverDisco = true;
        }
    }

    public void AñadirDisco()
    {
        if (inventario.GetObjetoSeleccionado().GetNombre() == "Donut" && piezasColocadas < 4)
        {

            piezasHanoi1[piezasColocadas].gameObject.SetActive(true);
            piezasColocadas++;
            inventario.EliminarObjeto(inventario.GetObjetos().IndexOf(inventario.GetObjetoSeleccionado()));
            inventario.DeseleccionarObjeto();
        }


    }

    public void SeleccionarDisco(Donut disco)
    {
        discoSeleccionado = disco;
    }

    public Donut GetDiscoSeleccionado()
    {
        return discoSeleccionado;
    }


    public bool HaResueltoPuzle()
    {
        return estaResuelto;
    }

    public bool ComprobarSePuedeMoverDisco()
    {
        return sePuedeMoverDisco;
    }

    public void SaltarPuzle()
    {
        estaResuelto = true;
        //se activa el texto y se mueven los discos
    }


}
