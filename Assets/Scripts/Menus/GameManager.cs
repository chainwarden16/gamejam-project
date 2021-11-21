using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Progreso del oponente")]
    [SerializeField]
    float contadorOponente = 0f;
    [SerializeField]
    int salaOponente;
    const float minimoTiempo = 240f;
    const float maximoTiempo = 360f;

    [Header("Progreso del jugador")]
    [SerializeField]
    bool estaReiniciandoSala = false;
    float contadorGameOver = 4f; //a los 4 segundos, el juego terminará

    private void Start()
    {

        salaOponente = PlayerPrefs.GetInt("SalaActualOponente", 1);
        ReiniciarEstadoContador();

    }

    private void Update()
    {
        //El jugador compite contra un npc al que no ve. Si el progreso del npc es tal que va a hacer que supere la sala antes que el jugador, habrá una pequeña alarma visual y sonora que te lo indique.
        /*
         * Si el npc superara la escena, entonces se reiniciaría la sala, lo que llevaría a que la escena se cargue de nuevo. Antes de que se reinicie, se guaradrá el progreso del oponente.
         * 
         * Importante: debido a esto, las soluciones del puzles se deberán recalcular en el start de cada puzle, no en este método
         */

        if (contadorOponente <= 0f && salaOponente < 4)
        {


            if (!estaReiniciandoSala)
                salaOponente++;

            estaReiniciandoSala = true;



            GuardarProgresoOponente();
            Initiate.Fade(SceneManager.GetActiveScene().name, Color.black, 1f);
        }
        else if (salaOponente == 4)
        {

            estaReiniciandoSala = true;
            //Aparece un mensaje que dice que estarás atrapado aquí para siempre, y luego Game Over
            if (contadorGameOver <= 0f)
            {

                Initiate.Fade("Fin", Color.black, 1f);
            }
            else
            {
                contadorGameOver -= Time.deltaTime;
            }

        }

        else
        {
            contadorOponente -= Time.deltaTime;
        }

    }

    public void GuardarSalaCompletada(int numero)
    {
        PlayerPrefs.SetInt("EscenaActual", numero + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Detiene el contador de tiempo y lo resetea dependiendo de la cantidad
    public void ReiniciarEstadoContador()
    {
        contadorOponente = Random.Range(minimoTiempo, maximoTiempo); //240, 360
    }

    public void GuardarProgresoOponente()
    {
        PlayerPrefs.SetInt("SalaActualOponente", salaOponente);
    }

}
