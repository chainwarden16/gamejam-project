using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{

    #region Variables
    [Header("UI")]
    public GameObject uiMenuOpciones;
    public GameObject uiMenuPausa;


    [Header("Comprobador menú activo")]
    public bool estaViendoOpciones;
    public bool estaPausado;

    OpcionesGameplay menuOpciones;

    GameManager manager;

    [Header("Audio")]
    AudioController contAudio;
    public AudioClip moverCursor;
    public AudioClip seleccionar;

    #endregion

    void Start()
    {

        menuOpciones = GetComponent<OpcionesGameplay>();
        manager = FindObjectOfType<GameManager>();

        uiMenuPausa.SetActive(false);
        uiMenuOpciones.SetActive(false);

        contAudio = FindObjectOfType<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {


            if (Input.GetKeyDown(KeyCode.Escape) && !estaViendoOpciones) //pausa el juego
            {

                estaPausado = !estaPausado;
                if (estaPausado)
                {

                    Time.timeScale = 0;
                    uiMenuPausa.SetActive(true);
                }
                else //se devuelve todo al estado original
                {

                    Time.timeScale = 1;
                    uiMenuPausa.SetActive(false);
                    //colocar el cursor en su lugar dentro del canvas
                }
            }

    }

    public void SetestaViendoOpciones(bool estaHaciendolo)
    {
        estaViendoOpciones = estaHaciendolo;
    }

    public void SetEstaPausado(bool loEsta)
    {
        estaPausado = loEsta;
    }
        
}
