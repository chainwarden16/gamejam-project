using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzle6 : MonoBehaviour
{

    [Header("Puzle de Hanoi")]
    [SerializeField]
    int piezasColocadas;
    public GameObject hanoi;
    public TextMeshProUGUI textoIndicador;

    [Header("Varillas del puzle")]
    public Varilla varilla1;
    public Varilla varilla3;


    [SerializeField] 
    Donut discoSeleccionado;

    [SerializeField]
    bool sePuedeMoverDisco;
    bool estaResuelto;

    Inventario inventario;
    GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    public void CerrarPuzleHanoi()
    {
        Initiate.Fade("sala2", Color.black, 1f);
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

        switch (disco.GetSize())
        {
            case 1:
                textoIndicador.text = "Green";
                break;
            case 2:
                textoIndicador.text = "Red";
                break;
            case 3:
                textoIndicador.text = "Yellow";
                break;
            case 4:
                textoIndicador.text = "White";
                break;
            case 10:
                textoIndicador.text = "Blue";
                break;
        }
    }

    public void DeseleccionarDisco()
    {
        discoSeleccionado = null;
        textoIndicador.text = "None";
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
