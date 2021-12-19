using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DespSala2 : MonoBehaviour
{
    GameManager manager;
    public TextMeshProUGUI textoMicro;
    public TextMeshProUGUI textoReloj;


    public GameObject pc1, pc2;
    public Button botonP4, botonP5, botonP6, botonMic, botonDenMic, botonSalida, botonAtras;

    MovRegreso2 regreso;

    Camera camara;

    [Header("Audio")]
    AudioController audioC;
    public AudioClip abrirPuerta;

    private void Start()
    {
        audioC = FindObjectOfType<AudioController>();
        camara = Camera.main;
        manager = FindObjectOfType<GameManager>();
        regreso = FindObjectOfType<MovRegreso2>();

    }

    public void MoverseAMicro()
    {
        botonAtras.interactable = true;
        textoReloj.gameObject.SetActive(false);
        textoMicro.gameObject.SetActive(true);
        camara.transform.position = pc1.transform.position;
        camara.transform.rotation = pc1.transform.rotation;
        regreso.SetNivelPosicion(1);
        botonDenMic.interactable = true;
        //se desactivan todos menos el de regresar
        DesctivarBotonesPuzles();
    }

    public void MoverseDentroMicro()
    {

        textoMicro.gameObject.SetActive(false);
        camara.transform.position = pc2.transform.position;
        camara.transform.rotation = pc2.transform.rotation;
        regreso.SetNivelPosicion(2);
        //se desactivan todos menos el de regresar
        DesactivarBotonMicro();
    }

   

    public void PasarASiguienteSala()
    {
        if (manager != null)
        {

            if (manager.GetPuzlesResueltos()[3] && manager.GetPuzlesResueltos()[4] && manager.GetPuzlesResueltos()[5])
            {
                manager.GuardarSalaCompletada(SceneManager.GetActiveScene().buildIndex + 4, "Sala3");

                if (audioC != null)
                {
                    audioC.PlaySFX(abrirPuerta);
                }

            }

        }

    }

    private void DesctivarBotonesPuzles()
    {
        botonP4.interactable = false;
        botonP5.interactable = false;
        botonP6.interactable = false;
        botonMic.interactable = false;
        botonSalida.interactable = false;
    }

    private void DesactivarBotonMicro()
    {
        botonDenMic.interactable = false;
    }
}
