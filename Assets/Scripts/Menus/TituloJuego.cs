using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TituloJuego : MonoBehaviour
{

    AudioController audioJuego;
    public AudioClip confirmar, cancelar;

    private void Start()
    {
        audioJuego = FindObjectOfType<AudioController>();
    }

    public void EmpezarPartida()
    {
        if(audioJuego != null)
        {
            audioJuego.PlaySFX(confirmar);
            audioJuego.PlaySong(audioJuego.musicaIntro);
        }
        Initiate.Fade("Intro", Color.black, 1f);
    }

    public void MenuOpciones()
    {
        if (audioJuego != null)
        {
            audioJuego.PlaySFX(confirmar);
        }
        Initiate.Fade("Opciones", Color.black, 1f);
    }

    public void CerrarJuego()
    {
        if (audioJuego != null)
        {
            audioJuego.PlaySFX(cancelar);
        }
        Application.Quit();
    }

    public void CargarPartida()
    {
        //En la escena se cargará en qué estado estaban los puzles
        string nombreEscena = PlayerPrefs.GetString("EscenaActual");
        Initiate.Fade(nombreEscena, Color.black, 1f);
    }
}
