using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzle6 : MonoBehaviour
{

    [Header("Puzle de Hanoi")]
    [SerializeField]
    int piezasColocadas;
    public GameObject hanoi;

    [Header("Varillas del puzle")]
    public Varilla varilla1;
    public Varilla varilla3;


    [SerializeField] 
    Donut discoSeleccionado;


    [Header("Puzle de gatos")]
    bool gatosAlimentados;
    public GameObject gatos;

    [SerializeField]
    bool sePuedeMoverDisco;
    bool estaResuelto;

    Inventario inventario;
    GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }


    public void ComprobarEstadoHanoi()
    {
        bool resuelto = true;
        if (varilla3.GetDiscos().Count == 4)
        {

            for (int i = 0; i < varilla3.GetDiscos().Count; i++)
            {
                int tamaño = 4;
                if (varilla3.GetDiscos()[i].GetSize() != tamaño - i)
                {
                    resuelto = false;
                    break;
                }
            }

        }
        else
        {
            resuelto = false;
            Debug.Log("No está resuelto");
        }

        estaResuelto = resuelto;

        if (manager != null)
        {
            manager.SetPuzleResuelto(5, estaResuelto);
        }
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

            varilla1.GetDiscos()[piezasColocadas].gameObject.SetActive(true);
            piezasColocadas++;
            inventario.EliminarObjeto(inventario.GetObjetos().IndexOf(inventario.GetObjetoSeleccionado()));
            inventario.DeseleccionarObjeto();
        }

    }

    public void SeleccionarDisco(Donut disco)
    {
        discoSeleccionado = disco;
    }

    public void DeseleccionarDisco()
    {
        discoSeleccionado = null;
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
