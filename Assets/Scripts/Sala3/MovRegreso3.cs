using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovRegreso3 : MonoBehaviour
{
    [SerializeField]
    int nivelPosicion;

    public GameObject nivel0, nivel1, nivel2, nivel3, nivel4;
    public GameObject botonAtras;
    DespSala3 desplazamiento;
    Camera camara;
    //[Header("Botones del mapa")]
    //[Tooltip("pArB, j1ArB, j2ArB, j3ArB, j4ArB, pasilloDerB, p8, BajoEscB, jaulaAb1, jaulaAb2, jaulaAb3, jaulaAb4, fondoB, p9, p7, botonSalida")]
    //public List<Button> botonesMapa;

    private void Start()
    {
        camara = Camera.main;

        desplazamiento = FindObjectOfType<DespSala3>();
    }

    public void SetNivelPosicion(int posicionNueva)
    {

        nivelPosicion = posicionNueva;
        if (nivelPosicion > 0 && botonAtras != null)
        {
            botonAtras.GetComponent<Button>().interactable = true;
            botonAtras.GetComponent<Button>().image.color = new Color(1, 1, 1, 1);
        }

    }

    public int GetPosicionNueva()
    {
        return nivelPosicion;
    }

    public void RegresarAtras()
    {

        switch (nivelPosicion)
        {
            case 1:

                desplazamiento.MoverseAOrigen();
                botonAtras.GetComponent<Button>().interactable = false;

                break;
            case 2:

                desplazamiento.MoverseAPasillo();

                break;
            case 3:
                if (nivel3 != null)
                {

                    desplazamiento.MoverseDerecha();

                }
                break;
            case 4:
                if (nivel3 != null)
                {

                    desplazamiento.MoverseBajoEscalera();

                }
                break;
            case 5:
                if (nivel4 != null)
                {
                    desplazamiento.MoverseBajoEscalera();

                }
                break;

        }

        //nivelPosicion--;
    }

    /*private void DesctivarBotonesPuzles()
    {
        for (int i = 0; i < botonesMapa.Count - 2; i++)
        {
            botonesMapa[i].interactable = false;
        }
    }*/
}
