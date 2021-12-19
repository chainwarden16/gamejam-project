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
        PlayerPrefs.DeleteAll();
        if(audioJuego != null)
        {
            audioJuego.PlaySFX(confirmar);
            audioJuego.PlaySong(audioJuego.musicaSala1);
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

    public void Creditos()
    {
        if (audioJuego != null)
        {
            audioJuego.PlaySFX(confirmar);
        }
        Initiate.Fade("Creditos", Color.black, 1f);
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
        int numeroEscena = PlayerPrefs.GetInt("EscenaActual", 2);
        if(audioJuego != null)
        {
            audioJuego.PlaySFX(confirmar);
        }
        ReproducirMusicaSala();
        SceneManager.LoadScene(numeroEscena);

    }

    public void IrAlTitulo()
    {
        audioJuego.PlaySong(audioJuego.musicaTitulo);
        if (audioJuego != null)
        {
            audioJuego.PlaySFX(confirmar);
        }
        Initiate.Fade("Titulo", Color.black, 1f);
    }

    public void ReproducirMusicaSala()
    {
        switch (PlayerPrefs.GetInt("EscenaActual"))
        {
            case 7:

                audioJuego.PlaySong(audioJuego.musicaSala2);

                break;

            case 11:

                audioJuego.PlaySong(audioJuego.musicaSala3);

                break;

            case 16:

                audioJuego.PlaySong(audioJuego.musicaVictoria);
            break;

            default:

                audioJuego.PlaySong(audioJuego.musicaSala1);

                break;
        }
    }
}
