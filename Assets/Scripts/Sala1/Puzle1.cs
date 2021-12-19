using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class Puzle1 : MonoBehaviour
{
    public GameObject laberintoTablero;
    Vector2 posicionInicialBola = new Vector2(0.75f, -9.5f);
    string numeroRevelado;

    public List<TextMeshProUGUI> textoMarcadores;
    public List<GameObject> marcadores;
    public List<bool> marcadoresActivados;

    public GameObject bolaMetal;
    bool estaResuelto = false;

    //public DesplSala1 desp;
    //public Button botonAtras;

    //Camera camara;
    public Button abrirPuzle;
    public Button cerrarPuzle;
    GameManager manager;
    //public GameObject posicionRetorno;
    //public GameObject posicionVerPuzle;

    [Header("Audio")]
    AudioController audioC;
    public AudioClip cancelar, correcto, completado, error;

    private void Start()
    {
        //camara = Camera.main;
        manager = FindObjectOfType<GameManager>();

        audioC = FindObjectOfType<AudioController>();

        numeroRevelado = Random.Range(1000, 10000).ToString();
        for (int i = 0; i < 4; i++)
        {

            textoMarcadores[i].text = numeroRevelado[i].ToString();
            marcadores[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            textoMarcadores[i].gameObject.SetActive(false);

        }
    }

    public void CerrarLaberinto()
    {


        audioC = FindObjectOfType<AudioController>();

        if (audioC != null)
        {
            audioC.PlaySFX(cancelar);
        }

        Initiate.Fade("Sala1 old", Color.black, 1f);

    }

    public void ReiniciarMarcadores()
    {
        //Si el jugador lleva la bola a la salida, se reinician los contadores y se devuelve la pelota al punto de inicio
        for (int i = 0; i < marcadores.Count; i++)
        {
            marcadores[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            marcadoresActivados[i] = false;
            //textoMarcadores[i].gameObject.SetActive(false);
        }
        bolaMetal.transform.position = posicionInicialBola;
        audioC = FindObjectOfType<AudioController>();

        if (audioC != null)
        {
            audioC.PlaySFX(error);
        }
    }

    public void MostrarCombinacion()
    {
        bool yaEstanTodos = true;
        for (int i = 0; i < marcadoresActivados.Count; i++)
        {
            if (marcadoresActivados[i] == false)
            {
                yaEstanTodos = false;
                break;
            }

        }

        if (yaEstanTodos)
        {
            estaResuelto = true;
            if (manager != null)
            {
                manager.SetPuzleResuelto(0, true);

            }

            audioC = FindObjectOfType<AudioController>();

            if (audioC != null)
            {
                audioC.sourceSFX.PlayOneShot(completado);
            }
        }

    }

    public string GetNumeroRevelado()
    {
        return numeroRevelado;
    }

    public void SetMarcadorActivado(int inde)
    {
        marcadoresActivados[inde] = true;
        marcadores[inde].GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 1);
        audioC = FindObjectOfType<AudioController>();

        if (audioC != null)
        {
            audioC.PlaySFX(correcto);
        }
    }

    public void SetPosicionBolaInicio()
    {
        bolaMetal.transform.position = posicionInicialBola;
    }

    public bool GetEstaResuelto()
    {
        return estaResuelto;
    }

}
