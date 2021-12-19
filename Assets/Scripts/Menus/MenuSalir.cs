using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSalir : MonoBehaviour
{
    #region Variables

    [Header("Elemento de menú para cerrar")]
    public GameObject uiMenu;
    bool estaQueriendoSalir = false;


    [Header("Audio")]
    AudioSource sourceMusica, sourceSFX;
    AudioController audioC;

    public AudioClip confirmar, cancelar;

    #endregion

    void Start()
    {
        uiMenu.SetActive(false);

        //operaciones del menú de pausa

        audioC = FindObjectOfType<AudioController>();
        sourceMusica = audioC.sourceMusica;
        sourceSFX = audioC.sourceSFX;

    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            audioC = FindObjectOfType<AudioController>();

            if (!estaQueriendoSalir)
            {
                MostrarOpciones();
            }
            else
            {
                CerrarOpciones();
            }

            estaQueriendoSalir = !estaQueriendoSalir;
        }
    }

    #region Operaciones del menú de pausa

    public void ReanudarJuego()
    {
        audioC.PlaySFX(cancelar);
        uiMenu.SetActive(false);
        estaQueriendoSalir = false;
    }

    public void CerrarOpciones()
    {
        audioC.PlaySFX(cancelar);
        uiMenu.SetActive(false);
    }

    public void CerrarAplicacion()
    {
        audioC.PlaySFX(confirmar);
        Application.Quit();
    }

    public void MostrarOpciones()
    {
        audioC.PlaySFX(confirmar);
        uiMenu.SetActive(true);

    }

    #endregion


}
