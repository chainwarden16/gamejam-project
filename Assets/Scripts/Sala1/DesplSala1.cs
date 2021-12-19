using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DesplSala1 : MonoBehaviour
{

    public GameObject pc1, pc2, pc3, pc4, fondoSala;
    public List<Button> botones; // son 6 elementos
    public Button abrirPuzle1, abrirPuzle2, abrirPuzle3;

    MovRegreso1 regreso;

    Camera camara;
    [SerializeField]
    GameManager manager;
    AbrirPuzles mecanismoAbrirPuzles;

    private void Start()
    {
        camara = Camera.main;
        manager = FindObjectOfType<GameManager>();
        regreso = FindObjectOfType<MovRegreso1>();
        mecanismoAbrirPuzles = FindObjectOfType<AbrirPuzles>();

    }

    public void MoverseAPC1()
    {
        camara.transform.position = pc1.transform.position;
        camara.transform.rotation = pc1.transform.rotation;
        regreso.SetNivelPosicion(1);
        if (!mecanismoAbrirPuzles.ComprobarSiEstaResuelto(0))
        {

            abrirPuzle1.interactable = true;

        }
        //se desactivan todos menos el de regresar
        DesctivarBotones();
    }

    public void MoverseAPC2()
    {
        camara.transform.position = pc2.transform.position;
        camara.transform.rotation = pc2.transform.rotation;
        regreso.SetNivelPosicion(1);
        //se desactivan todos menos el de regresar
        DesctivarBotones();
    }

    public void MoverseAPC3()
    {
        camara.transform.position = pc3.transform.position;
        camara.transform.rotation = pc3.transform.rotation;
        regreso.SetNivelPosicion(1);
        //se desactivan todos menos el de regresar
        DesctivarBotones();
    }

    public void MoverseAPC4()
    {
        camara.transform.position = pc4.transform.position;
        camara.transform.rotation = pc4.transform.rotation;
        regreso.SetNivelPosicion(1);

        if (!mecanismoAbrirPuzles.ComprobarSiEstaResuelto(1))
        {

            abrirPuzle2.interactable = true;

        }

        //se desactivan todos menos el de regresar
        DesctivarBotones();
    }

    public void MoverseAMiniSala()
    {
        camara.transform.position = fondoSala.transform.position;
        camara.transform.rotation = fondoSala.transform.rotation;
        regreso.SetNivelPosicion(1);
        abrirPuzle3.interactable = true;
        //se desactivan todos menos el de regresar
        DesctivarBotones();
        //se activa el de la puerta
        botones[botones.Count - 1].interactable = true;
    }

    public void PasarASiguienteSala()
    {
        if (manager != null)
        {

            if (manager.GetPuzlesResueltos()[0] && manager.GetPuzlesResueltos()[1] && manager.GetPuzlesResueltos()[2])
            {
                manager.GuardarSalaCompletada(SceneManager.GetActiveScene().buildIndex + 4, "Sala2");
            }

        }

    }

    public List<Button> GetBotonesSala()
    {
        return botones;
    }

    /*
    public void SetB1(bool haSuperadoPuzle)
    {
        puzle1Resuelto = haSuperadoPuzle;
    }

    public void SetB2(bool haSuperadoPuzle)
    {
        puzle2Resuelto = haSuperadoPuzle;
    }

    public void SetB3(bool haSuperadoPuzle)
    {
        puzle3Resuelto = haSuperadoPuzle;
    }
    */

    private void DesctivarBotones()
    {
        foreach (Button boto in botones)
        {
            boto.interactable = false;
        }
    }



}
