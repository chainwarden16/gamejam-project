using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DespSala3 : MonoBehaviour
{
    GameManager manager;
    public Material cielo;

    [Header("Puntos de teletransporte del mapa")]
    public GameObject puntoOrigen, pasilloArriba, pasilloDerecha, jaula1Ar, jaula2Ar, jaula3Ar, jaula4Ar, bajoEscalera,
        jaula1Ab, jaula2Ab, jaula3Ab, jaula4Ab, fondoSalida;

    [Header("Botones del mapa")]
    [Tooltip("pArB, j1ArB, j2ArB, j3ArB, j4ArB, pasilloDerB, p8, BajoEscB, jaulaAb1, jaulaAb2, jaulaAb3, jaulaAb4, fondoB, p9, p7, botonSalida, botonAtras")]
    public List<Button> botonesMapa; //pArB, j1ArB, j2ArB, j3ArB, j4ArB, pasilloDerB, p8, BajoEscB, jaulaAb1, jaulaAb2, jaulaAb3, jaulaAb4,  fondoB, p9, p7, botonSalida, botonAtras;

    MovRegreso3 regreso;

    Camera camara;

    [Header("Audio")]
    AudioController audioC;
    public AudioClip abrirPuertaGrande;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        camara = Camera.main;
        RenderSettings.skybox = cielo;
        regreso = FindObjectOfType<MovRegreso3>();
    }

    #region Nivel 1

    public void MoverseAOrigen()
    {

        camara.transform.position = puntoOrigen.transform.position;
        camara.transform.rotation = puntoOrigen.transform.rotation;
        regreso.SetNivelPosicion(0);

        DesctivarBotonesPuzles();

        ActivarBoton(0);

        botonesMapa[botonesMapa.Count - 1].interactable = false; //botonAtras

        //se desactivan todos menos el de regresar

    }

    public void MoverseAPasillo()
    {

        camara.transform.position = pasilloArriba.transform.position;
        camara.transform.rotation = pasilloArriba.transform.rotation;
        regreso.SetNivelPosicion(1);

        DesctivarBotonesPuzles();

        ActivarBoton(1);
        ActivarBoton(2);
        ActivarBoton(3);
        ActivarBoton(4);
        ActivarBoton(5);

        botonesMapa[botonesMapa.Count - 1].interactable = true; //botonAtras

        //se desactivan todos menos el de regresar

    }

    public void MoverseDerecha()
    {
        DesctivarBotonesPuzles();

        ActivarBoton(7);

        camara.transform.position = pasilloDerecha.transform.position;
        camara.transform.rotation = pasilloDerecha.transform.rotation;
        regreso.SetNivelPosicion(2);
        //se desactivan todos menos el de regresar

    }

    #endregion

    #region Nivel 2

    public void MoverseAJ1Arriba()
    {

        camara.transform.position = jaula1Ar.transform.position;
        camara.transform.rotation = jaula1Ar.transform.rotation;

        regreso.SetNivelPosicion(2);

        DesctivarBotonesPuzles();

        botonesMapa[botonesMapa.Count - 1].interactable = true; //botonAtras

        //se desactivan todos menos el de regresar

    }

    public void MoverseAJ2Arriba()
    {

        camara.transform.position = jaula2Ar.transform.position;
        camara.transform.rotation = jaula2Ar.transform.rotation;

        regreso.SetNivelPosicion(2);

        DesctivarBotonesPuzles();

        botonesMapa[botonesMapa.Count - 1].interactable = true; //botonAtras

        //se desactivan todos menos el de regresar

    }

    public void MoverseAJ3Arriba()
    {

        camara.transform.position = jaula3Ar.transform.position;
        camara.transform.rotation = jaula3Ar.transform.rotation;

        regreso.SetNivelPosicion(2);

        DesctivarBotonesPuzles();

        botonesMapa[botonesMapa.Count - 1].interactable = true; //botonAtras

        //se desactivan todos menos el de regresar

    }

    public void MoverseAJ4Arriba()
    {

        camara.transform.position = jaula4Ar.transform.position;
        camara.transform.rotation = jaula4Ar.transform.rotation;

        regreso.SetNivelPosicion(2);

        DesctivarBotonesPuzles();

        ActivarBoton(6); //p8

        botonesMapa[botonesMapa.Count - 1].interactable = true; //botonAtras

        //se desactivan todos menos el de regresar

    }

    #endregion

    #region Nivel 3

    public void MoverseBajoEscalera()
    {

        DesctivarBotonesPuzles();

        ActivarBoton(8); //jaula 1 abajo
        ActivarBoton(9); //jaula 2 abajo
        ActivarBoton(10); //jaula 3 abajo
        ActivarBoton(11); //jaula 4 abajo
        ActivarBoton(12); //fondo



        camara.transform.position = bajoEscalera.transform.position;
        camara.transform.rotation = bajoEscalera.transform.rotation;

        regreso.SetNivelPosicion(3);
        //se desactivan todos menos el de regresar

    }

    #endregion

    #region Nivel 4

    public void MoverseAFondo()
    {

        DesctivarBotonesPuzles();

        ActivarBoton(15);//Puerta
        ActivarBoton(14);//Puzle 7

        camara.transform.position = fondoSalida.transform.position;
        camara.transform.rotation = fondoSalida.transform.rotation;

        regreso.SetNivelPosicion(4);
        //se desactivan todos menos el de regresar

    }

    #endregion

    #region Nivel 5

    public void MoverseAJ1Abajo()
    {

        camara.transform.position = jaula1Ab.transform.position;
        camara.transform.rotation = jaula1Ab.transform.rotation;

        regreso.SetNivelPosicion(5);

        DesctivarBotonesPuzles();

        botonesMapa[botonesMapa.Count - 1].interactable = true; //botonAtras
        ActivarBoton(13); //p9

        //se desactivan todos menos el de regresar

    }

    public void MoverseAJ2Abajo()
    {

        camara.transform.position = jaula2Ab.transform.position;
        camara.transform.rotation = jaula2Ab.transform.rotation;

        regreso.SetNivelPosicion(5);

        DesctivarBotonesPuzles();

        botonesMapa[botonesMapa.Count - 1].interactable = true; //botonAtras

        //se desactivan todos menos el de regresar

    }

    public void MoverseAJ3Abajo()
    {

        camara.transform.position = jaula3Ab.transform.position;
        camara.transform.rotation = jaula3Ab.transform.rotation;

        regreso.SetNivelPosicion(5);

        DesctivarBotonesPuzles();

        botonesMapa[botonesMapa.Count - 1].interactable = true; //botonAtras

        //se desactivan todos menos el de regresar

    }

    public void MoverseAJ4Abajo()
    {

        camara.transform.position = jaula4Ab.transform.position;
        camara.transform.rotation = jaula4Ab.transform.rotation;

        regreso.SetNivelPosicion(5);

        DesctivarBotonesPuzles();

        botonesMapa[botonesMapa.Count - 1].interactable = true; //botonAtras

        //se desactivan todos menos el de regresar

    }

    #endregion

    public void TerminarPartida()
    {
        if (manager != null)
        {
            if (manager.GetPuzlesResueltos()[6] && manager.GetPuzlesResueltos()[7] && manager.GetPuzlesResueltos()[8])
            {
                audioC = FindObjectOfType<AudioController>();
                if (audioC != null)
                {
                    audioC.PlaySFX(abrirPuertaGrande);
                }
                manager.GuardarSalaCompletada(SceneManager.GetActiveScene().buildIndex + 5, "Fin");
            }
        }
    }

    private void DesctivarBotonesPuzles()
    {
        for (int i = 0; i < botonesMapa.Count - 2; i++)
        {
            botonesMapa[i].interactable = false;
            botonesMapa[i].gameObject.SetActive(false);
        }
    }

    private void ActivarBoton(int indice)
    {
        botonesMapa[indice].gameObject.SetActive(true);
        botonesMapa[indice].interactable = true;
    }
}
