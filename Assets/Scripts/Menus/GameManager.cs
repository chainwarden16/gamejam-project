using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Progreso del oponente")]
    [SerializeField]
    float contadorOponente = 240f;
    [SerializeField]
    int salaOponente;
    const float minimoTiempo = 280f;
    const float maximoTiempo = 400f;

    [Header("Progreso del jugador")]
    [SerializeField]
    bool estaReiniciandoSala = false;
    float contadorGameOver = 4f; //a los 4 segundos, el juego terminará

    [Header("Puzle actual para comodín")]
    int puzleActual;

    [Header("Puzles ya resueltos")]
    [Tooltip("Van del 1 al 9,empezando por el 0. Una vez todos estén resueltos se irá a la pantalla de victoria")]
    [SerializeField]
    List<bool> puzlesResueltos = new List<bool>() { false, false, false, false, false, false, false, false, false };

    #region Métodos de Unity

    public static GameManager _instance;

    private void Awake()
    {
        if (_instance == null)
        {

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        PlayerPrefs.DeleteAll();
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

    #endregion

    public void GuardarSalaCompletada(int numero, string nombreEscena)
    {
        PlayerPrefs.SetInt("EscenaActual", numero);
        SceneManager.LoadScene(nombreEscena);
    }

    //Detiene el contador de tiempo y lo resetea dependiendo de la cantidad
    public void ReiniciarEstadoContador()
    {
        contadorOponente = Random.Range(minimoTiempo, maximoTiempo);
    }

    public void GuardarProgresoOponente()
    {
        PlayerPrefs.SetInt("SalaActualOponente", salaOponente);
    }

    public int GetPuzleActual()
    {
        return puzleActual;
    }

    public void SetPuzleActual(int numero)
    {
        puzleActual = numero;
    }

    public List<bool> GetPuzlesResueltos()
    {
        return puzlesResueltos;
    }

    public void SetPuzleResuelto(int indice, bool resultado)
    {
        if (indice <= puzlesResueltos.Count - 1)
        {

            puzlesResueltos[indice] = resultado;

        }
    }

}
